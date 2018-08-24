using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;
using Unity;

namespace Schulzy.FoEBot.BL
{
    public class RequestController
    {
        private UnityContainer _container;
        private readonly IHttpRequestManager _httpRequestManager;
        private readonly string _uri = @"https://hu0.forgeofempires.com/";

        public RequestController(UnityContainer container)
        {
            _container = container;
            _httpRequestManager = container.Resolve<IHttpRequestManager>();
            new RequestManagerInitializer().Initialize(_httpRequestManager, _uri);
        }
    }
}