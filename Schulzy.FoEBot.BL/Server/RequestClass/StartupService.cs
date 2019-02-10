using Newtonsoft.Json.Linq;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class StartupService : BaseRequest
    {
        [MethodName("getData")]
        public void GetData(IRequestIdManager requestManager)
        {
            Request.requestClass = "StartupService";
            Request.requestMethod = GetRequestedMethod();
            Request.requestData = new JArray();
            Request.requestId = requestManager.GetNextId;
        }
    }
}
