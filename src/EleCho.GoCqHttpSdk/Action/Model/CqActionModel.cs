namespace EleCho.GoCqHttpSdk.Action.Model;

internal class CqActionModel(string action, object @params)
{
    public CqActionModel(string action, object @params, string? echo) : this(action, @params) => this.echo = echo;

    public string action { get; set; } = action;
    public object @params { get; set; } = @params;

    public string? echo { get; set; }
}