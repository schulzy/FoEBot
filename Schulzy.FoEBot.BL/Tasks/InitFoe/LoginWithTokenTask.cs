using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.InitFoe
{
    internal class LoginWithTokenTask : ITask
    {
        private readonly IUnityContainer _diContainer;
        public int Priority { get; } = 2;

        public LoginWithTokenTask(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Run()
        {
            var httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            var settings = _diContainer.Resolve<ISettings>();
            var uri = @"https://hu2.forgeofempires.com/game/login?" + settings.Token;
            httpManagerInit.InitializeHeader();
            Status = FoeTaskStatus.Running;
            httpManager.SendGetRequest(uri, null, null, false);
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;
    }
}