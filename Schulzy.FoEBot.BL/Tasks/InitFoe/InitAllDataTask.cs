using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Server.RequestClass;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Manager;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.InitFoe
{
    public class InitAllDataTask :  ITask
    {
        private readonly IUnityContainer _diContainer;

        public InitAllDataTask(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }
        public int Priority { get; } = 4;
        public void Run()
        {
            Status = FoeTaskStatus.Running;
            var httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            var settings = _diContainer.Resolve<ISettings>();
            var hashCreator = _diContainer.Resolve<IHashCreator>();
            var uri = settings.Gateway;

            var requestIdManager = _diContainer.Resolve<IRequestIdManager>();
            var startupService = new StartupService();
            startupService.GetData(requestIdManager);
            var request = startupService.JsonString;

            var signature = hashCreator.GetSignature(request);
            httpManagerInit.InitializeHeader(signature);

            httpManager.SendPostRequest(uri, request, null, null, false);
            Status = FoeTaskStatus.Success;
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;
    }
}