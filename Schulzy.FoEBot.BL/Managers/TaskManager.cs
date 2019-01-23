using System;
using System.Collections.Concurrent;
using System.Linq;
using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL
{
    public class TaskManager : ITaskManager
    {
        private ConcurrentDictionary<Guid,ITask> _tasks = new ConcurrentDictionary<Guid, ITask>();

        public Status Status { get; private set; }

        public void Start()
        {
            Status = Status.Idle;
            InvokeTasks();
        }

        public void Stop()
        {
            Status = Status.Stopped;
        }

        public bool AddTask(ITask task)
        {
            bool isAdded = _tasks.TryAdd(Guid.NewGuid(), task);
            if (Status == Status.Idle)
            {
                InvokeTasks();
            }
            return isAdded;
        }

        private void InvokeTasks()
        {
            while (GetTask(out ITask task))
            {
                Status =Status.Running;
                task.Run();
                Status = Status.Pending;
            }

            Status = Status.Idle;
        }

        private bool GetTask(out ITask task)
        {
            task = null;
            bool isRemoved = false;
            if (_tasks.Count > 0)
            {
                var keyValuePair = _tasks.OrderBy(x => x.Value.Priority).FirstOrDefault();
                isRemoved = _tasks.TryRemove(keyValuePair.Key, out task);
            }
            return isRemoved;
        }
    }
}