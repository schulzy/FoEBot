namespace Schulzy.FoEBot.Interface.Task
{
    public interface ITaskContainer : ITask
    {
        void AddTask(ITask task);
    }
}