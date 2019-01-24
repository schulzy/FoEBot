using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Unity;

namespace Schulzy.FoEBot.BL
{
    public class RequestController
    {
        private readonly IHttpRequestManager _httpRequestManager;
        private readonly string _uri = @"https://hu0.forgeofempires.com/";
        private UnityContainer _container;

        public RequestController(UnityContainer container)
        {
            _container = container;
            _httpRequestManager = container.Resolve<IHttpRequestManager>();
            new RequestManagerInitializer(_httpRequestManager).InitializeCookies(_uri);
        }
    }
}