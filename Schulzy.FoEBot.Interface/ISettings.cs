namespace Schulzy.FoEBot.Interface
{
    public interface ISettings
    {
        string Secret { get; set; }
        string Token { get; set; }
    }
}