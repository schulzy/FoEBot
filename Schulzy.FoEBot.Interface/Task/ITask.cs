using Schulzy.FoEBot.Interface.Model;

namespace Schulzy.FoEBot.Interface.Task
{
    public interface ITask
    {
        int Priority { get; }
        void Run();
        FoeTaskStatus Status { get; }
    }
}