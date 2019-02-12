using Newtonsoft.Json.Linq;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class StartupService : BaseRequest
    {
        [MethodName("getData")]
        public void GetData(IRequestIdManager requestManager)
        {
            SetRequestClass("StartupService");
            SetRequestMethod(GetRequestedMethod());
            SetData(new JArray());
            SetId(requestManager.GetNextId);
        }
    }
}
