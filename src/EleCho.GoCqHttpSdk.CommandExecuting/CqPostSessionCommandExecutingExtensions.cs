namespace EleCho.GoCqHttpSdk.CommandExecuting;

public static class CqPostSessionCommandExecutingExtensions
{
    public static void UseCommandExecutePlugin(this ICqPostSession session, CqCommandExecutePostPlugin plugin)
    {
        session.UseAny(plugin.Execute);
    }
}
