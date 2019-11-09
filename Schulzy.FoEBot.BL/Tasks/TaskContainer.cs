using System.Collections.Generic;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;

namespace Schulzy.FoEBot.BL.Tasks
{
    internal class TaskContainer : ITaskContainer
    {
        private readonly Queue<ITask> _tasks = new Queue<ITask>();

        public int Priority { get; private set; } = int.MaxValue;

        public void Run()
        {
            var copyQueue = new Queue<ITask>(_tasks);
            Status = FoeTaskStatus.Running;
            while (copyQueue.TryDequeue(out ITask task))
            {
                task.Run();
                if (task.Status.HasFlag(FoeTaskStatus.LoginIssue))
                    Status |= task.Status;
            }
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;

        public void AddTask(ITask task)
        {
            if (task.Priority < Priority)
                Priority = task.Priority;

            _tasks.Enqueue(task);
        }
    }
}