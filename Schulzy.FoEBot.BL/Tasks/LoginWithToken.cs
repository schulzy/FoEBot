using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks
{
    internal class LoginWithToken : ITask
    {
        private readonly IUnityContainer _diContainer;
        public int Priority { get; } = 99;

        public LoginWithToken(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Run()
        {
            var httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var _httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            var settings = _diContainer.Resolve<ISettings>();
            var uri = @"https://hu2.forgeofempires.com/game/login?" + settings.Token;
            _httpManagerInit.InitializeHeader();
            Status = FoeTaskStatus.Running;
            var response = httpManager.SendGetRequest(uri, null, null, false);
            Helper.GetResponseAsString(response);
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;
    }
}