namespace Schulzy.FoEBot.Interface
{
    public interface IHashCreator
    {
        string GetSignature(string input);
        string GetMd5Hash(string input);
    }
}