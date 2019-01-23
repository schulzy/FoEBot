namespace Schulzy.FoEBot.Interface
{
    public interface ITask
    {
        int Priority { get; }
        void Run();

    }
}