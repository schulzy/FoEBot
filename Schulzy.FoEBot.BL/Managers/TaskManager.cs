using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using Schulzy.FoEBot.Interface.Task;

namespace Schulzy.FoEBot.BL.Managers
{
    public class TaskManager : ITaskManager
    {
        private readonly ConcurrentDictionary<Guid, ITask> _tasks = new ConcurrentDictionary<Guid, ITask>();

        private AutoResetEvent _autoResetEvent;

        public Status Status { get; private set; }

        public void Start()
        {
            _autoResetEvent = new AutoResetEvent(false);
            Status = Status.Idle;
            InvokeTasks();
            _autoResetEvent.WaitOne();
        }

        public void Stop()
        {
            Status = Status.Stopped;
            _autoResetEvent.Set();
        }

        public bool AddTask(ITask task)
        {
            var isAdded = _tasks.TryAdd(Guid.NewGuid(), task);
            if (Status == Status.Idle)
                InvokeTasks();
            return isAdded;
        }

        private void InvokeTasks()
        {
            while (GetTask(out ITask task))
            {
                Status = Status.Running;
                task.Run();
                Status = Status.Pending;
            }

            Status = Status.Idle;
        }

        private bool GetTask(out ITask task)
        {
            task = null;
            var isRemoved = false;
            if (_tasks.Count > 0)
            {
                var keyValuePair = _tasks.OrderBy(x => x.Value.Priority).FirstOrDefault();
                isRemoved = _tasks.TryRemove(keyValuePair.Key, out task);
            }
            return isRemoved;
        }
    }
}