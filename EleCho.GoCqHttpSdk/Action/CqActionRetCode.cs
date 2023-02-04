namespace EleCho.GoCqHttpSdk.Action
{
    public enum CqActionRetCode
    {
        Okay = 0,
        Async = 1,

        BadRequest = 1400,
        Unauthorized = 1401,
        Forbidden = 1403,
        NotFound = 1404,
    }
}