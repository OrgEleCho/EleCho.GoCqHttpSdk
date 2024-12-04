using System;
using System.Reflection;
using System.Threading.Tasks;

namespace EleCho.GoCqHttpSdk.CommandExecuting;

internal class TaskUtils
{
    public static async Task<object?> WaitAsync(Task task)
    {
        Type type = task.GetType();

        await task;
        if (type.GetProperty(nameof(Task<object>.Result)) is PropertyInfo prop)
        {
            return prop.GetValue(task);
        }

        return null;
    }
}
