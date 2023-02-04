namespace EleCho.GoCqHttpSdk
{
    public enum CqRole
    {
        Member = 0b0000,
        Admin  = 0b0001,
        Owner  = 0b0011,
        Unknown = -1
    }
}