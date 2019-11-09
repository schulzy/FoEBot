namespace Schulzy.FoEBot.Interface.ResponseProcessor
{
    public interface INoSessionResponse
    {
        bool HasActiveSession(string jsonResponse);
    }
}