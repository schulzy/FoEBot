using Schulzy.FoEBot.BL.Constants;
using Schulzy.FoEBot.BL.Tasks.InitFoe;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Containers
{
    class RegisterTaskContainers 
    {
        private IUnityContainer _diContainer;

        public RegisterTaskContainers(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Initialize()
        {
            Setup();
        }

        private void Setup()
        {
            var initFoe = _diContainer.Resolve<TaskContainer>();
            initFoe.AddTask(new PlayNowLoginTask(_diContainer));
            initFoe.AddTask(new LoginWithTokenTask(_diContainer));
            initFoe.AddTask(new FindGatewayUrlTask(_diContainer));
            _diContainer.RegisterInstance<ITaskContainer>(TaskContainerNames.InitializeFoE, initFoe);
        }
    }
}
