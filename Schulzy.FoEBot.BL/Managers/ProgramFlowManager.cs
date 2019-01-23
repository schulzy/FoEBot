using Schulzy.FoEBot.BL.Modul;
using Schulzy.FoEBot.BL.Tasks;
using Schulzy.FoEBot.Interface;
using Unity;

namespace Schulzy.FoEBot.BL
{
    public class ProgramFlowManager : IProgramFlowManager
    {
        private UnityContainer _unityContainer;

        public ProgramFlowManager()
        {
            _unityContainer = new UnityContainer();
        }

        public void Start()
        {
            Registration registration = new Registration();
            registration.RegisterAll(_unityContainer);
            var taskManager = _unityContainer.Resolve<ITaskManager>();
            taskManager.AddTask(new PlayNowLoginTask(_unityContainer));
            taskManager.Start();
        }
    }
}
