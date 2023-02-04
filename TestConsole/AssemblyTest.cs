using EleCho.GoCqHttpSdk;
using EleCho.GoCqHttpSdk.Action;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    internal static class AssemblyTest
    {
        /// <summary>
        /// 对 EleCho.GoCqHttpSdk 的程序集进行基础测试
        /// </summary>
        /// <exception cref="Exception">有测试不通过的内容</exception>
        public static void Run()
        {
            Assembly asm = typeof(CqSession).Assembly;

            Type[] allTypes = asm.GetTypes();

            Type typeCqActionParamsModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.Params.CqActionParamsModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");
            Type typeCqActionResultDataModel = Type.GetType("EleCho.GoCqHttpSdk.Action.Model.ResultData.CqActionResultDataModel, EleCho.GoCqHttpSdk") ?? throw new Exception("找不到类型");

            Type[] cqActionTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqAction))).ToArray();
            Type[] cqActionParamsModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionParamsModel)).ToArray();
            Type[] cqActionResultTypes = allTypes.Where(t => t.IsSubclassOf(typeof(CqActionResult))).ToArray();
            Type[] cqActionResultDataModelTypes = allTypes.Where(t => t.IsSubclassOf(typeCqActionResultDataModel)).ToArray();

            foreach (var action in cqActionTypes)
            {
                if (!action.IsPublic)
                    throw new Exception($"{action.FullName} 不是 public");
                foreach (var prop in action.GetProperties())
                {
                    if (!prop.CanWrite && prop.Name != nameof(CqAction.ActionType))
                        Console.WriteLine($"程序集检查警告: {action} 的 {prop} 属性没有 '写' 访问器");
                }
            }

            foreach (var actionParamsModel in cqActionParamsModelTypes)
                if (actionParamsModel.IsPublic)
                    throw new Exception($"{actionParamsModel.FullName} 是 public");

            foreach (var actionResult in cqActionResultTypes)
            {
                if (!actionResult.IsPublic)
                    throw new Exception($"{actionResult.FullName} 不是 public");
                if (actionResult.GetConstructors().Length > 0)
                    throw new Exception($"{actionResult} 有公共的构造函数!");
                if (actionResult.Namespace?.StartsWith("EleCho.GoCqHttpSdk.Action.Result") ?? throw new Exception($"怪了, {actionResult} 没命名空间"))
                    throw new Exception($"{actionResult.FullName} 在 EleCho.GoCqHttpSdk.Action.Result 命名空间下");
                foreach (var prop in actionResult.GetProperties())
                {
                    if (prop.GetSetMethod() is not null)
                        throw new Exception($"{actionResult.FullName} 有公共的属性 {prop.Name}");
                    if (prop.CanWrite && prop.SetMethod!.IsPublic)
                        Console.WriteLine($"程序集检查警告: {actionResult} 的 {prop} 有公共的 '写' 访问器, 它不应该对用户暴露");
                }
            }

            foreach (var actionResultDataModel in cqActionResultDataModelTypes)
            {
                if (actionResultDataModel.IsPublic)
                    throw new Exception($"{actionResultDataModel.FullName} 是 public");
                if (actionResultDataModel.Namespace?.StartsWith("EleCho.GoCqHttpSdk.Action.Result") ?? throw new Exception($"怪了, {actionResultDataModel} 没命名空间"))
                    throw new Exception($"{actionResultDataModel} 命名空间不对劲");
            }


            Type cqenum = asm.GetType("EleCho.GoCqHttpSdk.CqEnum", true, false);
            MethodInfo cqenumtostring = cqenum.GetMethod("GetString", new Type[] { typeof(CqActionType) });
            Func<CqActionType, string> cqenumtostringfunc = cqenumtostring.CreateDelegate<Func<CqActionType, string>>();


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

            Console.WriteLine("程序集基础检查通过");
        }
    }
}
