using System.Timers;
using Schulzy.FoEBot.BL.Constants;
using Schulzy.FoEBot.BL.Modul;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Managers
{
    public class ProgramFlowManager : IProgramFlowManager
    {
        private readonly UnityContainer _unityContainer;
        private ITaskManager _taskManager;

        public ProgramFlowManager()
        {
            _unityContainer = new UnityContainer();
        }

        public void Start()
        {
            var registration = new Registration();
            registration.RegisterAll(_unityContainer);

            _taskManager = _unityContainer.Resolve<ITaskManager>();
            _taskManager.AddTask(_unityContainer.Resolve<ITaskContainer>(Constant.TaskContainerNames.InitializeFoE));

            StartRecuringTasks();
            _taskManager.LoginIssueOccurred +=
                (sender, args) => _taskManager.AddTask(
                    _unityContainer.Resolve<ITaskContainer>(Constant.TaskContainerNames.InitializeFoE));

            _taskManager.Start();
        }

        private void StartRecuringTasks()
        {
            StartBronzAge5MinuteTask();
        }

        private void StartBronzAge5MinuteTask()
        {
            Timer timer = new Timer
            {
                Interval = 305000,
                //Interval =90000,
                AutoReset = true
            };
            //timer.Elapsed += BronzAge5MinuteTask;
            timer.Elapsed += Vikink5MinuteTask;
            timer.Start();
        }

        private void BronzAge5MinuteTask(object sender, ElapsedEventArgs e)
        {
            _taskManager.AddTask(_unityContainer.Resolve<ITaskContainer>(Constant.TaskContainerNames.BronzAgeHarvest));
        }

        private void Vikink5MinuteTask(object sender, ElapsedEventArgs e)
        {
            _taskManager.AddTask(_unityContainer.Resolve<ITaskContainer>(Constant.TaskContainerNames.VikingProduktion));
        }
    }
}