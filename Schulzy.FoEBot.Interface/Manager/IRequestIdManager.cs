namespace Schulzy.FoEBot.Interface.Manager
{
    public interface IRequestIdManager
    {
        int GetNextId { get; }
        void ResetId();
    }
}