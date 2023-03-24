namespace LinkCutter.WebUI.LinkGenerator
{
    public interface ILinkStorage
    {
        Task<string> GetOriginalUrl(string url);
        Task<string> GetToken(string url);
    }
}
