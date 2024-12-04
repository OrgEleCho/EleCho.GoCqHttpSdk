using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using EleCho.GoCqHttpSdk.Post;
using System.Reflection;
using System.Text.Json;

namespace AssmeblyCheck;

internal static class AssemblyCheckCore
{
    /// <summary>
    /// 对 EleCho.GoCqHttpSdk 的程序集进行基础测试
    /// </summary>
    /// <exception cref="Exception">有测试不通过的内容</exception>
    public static int Run()
    {
        int warningCount = 0;

        Console.WriteLine("程序集检查开始...");
        Assembly asm = typeof(CqSession).Assembly;

        Type[] allTypes = asm.GetTypes();

        Type typeCqActionParamsModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.Params.CqActionParamsModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");
        Type typeCqActionResultDataModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.ResultData.CqActionResultDataModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");

        Type[] cqActionTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqAction))).ToArray();
        Type[] cqActionParamsModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionParamsModel)).ToArray();
        Type[] cqActionResultTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqActionResult))).ToArray();
        Type[] cqActionResultDataModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionResultDataModel)).ToArray();
        Type[] cqPostContextTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqPostContext))).ToArray();

        Console.WriteLine("检查 Action...");
        foreach (var action in cqActionTypes)
        {
            if (!action.Name.EndsWith("Action"))
                throw new Exception($"{action.FullName} 名称不是 Action 结尾");
            if (!action.IsPublic)
                throw new Exception($"{action.FullName} 不是 public");
            foreach (var prop in action.GetProperties())
            {
                if (!prop.CanWrite && prop.Name != nameof(CqAction.ActionType))
                {
                    Console.WriteLine($"程序集检查警告: {action} 的 {prop} 属性没有 '写' 访问器");
                    warningCount++;
                }
            }
        }

        Console.WriteLine("检查 ActionParamsModel...");
        foreach (var actionParamsModel in cqActionParamsModelTypes)
        {
            if (!actionParamsModel.Name.EndsWith("ActionParamsModel"))
                throw new Exception($"{actionParamsModel.FullName} 不是 ActionParamsModel 结尾");
            if (actionParamsModel.IsPublic)
                throw new Exception($"{actionParamsModel.FullName} 是 public");
            foreach (var prop in actionParamsModel.GetProperties())
            {
                if (prop.CanWrite)
                {
                    Console.WriteLine($"程序集检查警告: {actionParamsModel} 的 {prop} 是可写的");
                    warningCount++;
                }
            }
        }

        Console.WriteLine("检查 ActionResult...");
        foreach (var actionResult in cqActionResultTypes)
        {
            if (!actionResult.Name.EndsWith("ActionResult"))
                throw new Exception($"{actionResult.FullName} 不是 ActionResult 结尾");
            if (!actionResult.IsPublic)
                throw new Exception($"{actionResult.FullName} 不是 public");
            if (actionResult.GetConstructors().Length > 0)
                throw new Exception($"{actionResult} 有公共的构造函数!");
            if (actionResult.Namespace?.StartsWith("EleCho.GoCqHttpSdk.Action.Result") ?? throw new Exception($"怪了, {actionResult} 没命名空间"))
                throw new Exception($"{actionResult.FullName} 在 EleCho.GoCqHttpSdk.Action.Result 命名空间下");
            foreach (var prop in actionResult.GetProperties())
            {
                if (prop.CanWrite && prop.SetMethod!.IsPublic)
                {
                    Console.WriteLine($"程序集检查警告: {actionResult} 的 {prop} 有公共的 '写' 访问器, 它不应该对用户暴露");
                    warningCount++;
                }
            }
        }

        Console.WriteLine("检查 ActionResultDataModel...");
        foreach (var actionResultDataModel in cqActionResultDataModelTypes)
        {
            if (!actionResultDataModel.Name.EndsWith("ActionResultDataModel"))
                throw new Exception($"{actionResultDataModel.FullName} 不是 ActionResultDataModel 后缀");
            if (actionResultDataModel.IsPublic)
                throw new Exception($"{actionResultDataModel.FullName} 是 public");
            if (actionResultDataModel.Namespace?.StartsWith("EleCho.GoCqHttpSdk.Action.Result") ?? throw new Exception($"怪了, {actionResultDataModel} 没命名空间"))
                throw new Exception($"{actionResultDataModel} 命名空间不对劲");
        }

        Console.WriteLine("检查 PostContext");
        foreach (var postContext in cqPostContextTypes)
        {
            foreach (var prop in postContext.GetProperties())
            {
                if (prop.CanWrite && prop.SetMethod!.IsPublic)
                {
                    Console.WriteLine($"程序集检查警告: {postContext} 的 {prop} 有公共的 '写' 访问器, 它不应该对用户暴露");
                    warningCount++;
                }
            }
        }

        Console.WriteLine("检查枚举...");
        Type? cqenum = asm.GetType("EleCho.GoCqHttpSdk.CqEnum", true, false);
        MethodInfo? cqenumtostring = cqenum?.GetMethod("GetString", new Type[] { typeof(CqActionType) });
        Func<CqActionType, string>? cqenumtostringfunc = (cqenumtostring?.CreateDelegate<Func<CqActionType, string>>()) ?? throw new Exception("找不到 CqEnum.GetString 方法");

        foreach (var actionType in Enum.GetValues<CqActionType>())
        {
            try
            {
                cqenumtostringfunc.Invoke(actionType);
            }
            catch
            {
                throw new Exception($"没有提供从 {actionType} 到字符串的转换实现");
            }
        }

        Console.WriteLine("检查 ActionResult 转换");
        Type actionResultType = typeof(CqActionResult);
        MethodInfo createActionResultFromActionTypeMethod = actionResultType.GetMethod("CreateActionResultFromActionType", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { typeof(string) })!;

        foreach (var actionType in Enum.GetValues<CqActionType>())
        {
            try
            {
                createActionResultFromActionTypeMethod.Invoke(null, new object[] { cqenumtostringfunc.Invoke(actionType) });
            }
            catch
            {
                throw new Exception($"没有提供从 {actionType} 到 {actionResultType} 的转换实现");
            }
        }

        Console.WriteLine("检查 ActionResultDataModel 转换");
        Type actionResultModelType = asm.GetType("EleCho.GoCqHttpSdk.Action.Model.ResultData.CqActionResultDataModel", true, false)!;
        MethodInfo actionResultDataModelFromRaw = actionResultModelType.GetMethod("FromRaw", BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, new Type[] { typeof(JsonElement?), typeof(string) })!;

        JsonDocument jdoc = JsonDocument.Parse("null");
        foreach (var actionType in Enum.GetValues<CqActionType>())
        {
            try
            {
                actionResultDataModelFromRaw.Invoke(null, new object[] { jdoc.RootElement, cqenumtostringfunc.Invoke(actionType) });
            }
            catch (NotImplementedException)
            {
                throw new Exception($"没有提供从 {actionType} 到 {actionResultModelType} 的转换实现");
            }
        }

        Console.WriteLine("程序集基础检查通过");

        if (warningCount != 0)
            Console.WriteLine($"但是有 {warningCount} 个警告");

        return warningCount++;
    }
}
