using Schulzy.FoEBot.Interface;
using Unity;
using  System.Linq;
using Schulzy.FoEBot.BL.Utils;

namespace Schulzy.FoEBot.BL.Commands
{
    public class Login : ICommand
    {
        private IHttpRequestManager _manager;
        string uri = @"https://hu2.forgeofempires.com/game/index?ref=";
        private IUnityContainer _diContainer;

        public Login(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
            _manager = diContainer.Resolve<IHttpRequestManager>();
        }

        public void Launch()
        {
            var response = _manager.SendGetRequest(uri, null, null, false);
            var converter = _diContainer.Resolve<IConverter>();
            //converter.
            //string responseText = GetResponseAsString(response);
        }

        public void Prepare()
        {
            _manager.Header.Remove("Sinature");
        }
    }
}