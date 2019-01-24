using Schulzy.FoEBot.BL.Modul;
using Schulzy.FoEBot.BL.Tasks;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL
{
    public class ProgramFlowManager : IProgramFlowManager
    {
        private readonly UnityContainer _unityContainer;

        public ProgramFlowManager()
        {
            _unityContainer = new UnityContainer();
        }

        public void Start()
        {
            var registration = new Registration();
            registration.RegisterAll(_unityContainer);
            var taskManager = _unityContainer.Resolve<ITaskManager>();
            taskManager.AddTask(new PlayNowLoginTask(_unityContainer));
            taskManager.AddTask(new LoginWithToken(_unityContainer));
            taskManager.AddTask(new FindGatewayUrl(_unityContainer));
            taskManager.Start();
        }
    }
}