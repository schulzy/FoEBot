namespace Schulzy.FoEBot.Interface
{
    public interface ITaskManager
    {
        /// <summary>
        /// Get the status of the task manager
        /// </summary>
        Status Status { get; }

        /// <summary>
        /// Start running all task in the queue
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the task manager
        /// </summary>
        void Stop();

        /// <summary>
        /// Add new task
        /// </summary>
        /// <param name="task"></param>
        /// <returns>If it has been added than returns true otherwise false</returns>
        bool AddTask(ITask task);
    }

    public enum Status
    {
        Running,
        Idle,
        Pending,
        Stopped
    }
}