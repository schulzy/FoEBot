using Newtonsoft.Json.Linq;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class CityProductionService : BaseRequest
    {
        [MethodName("startProduction")]
        public void StartProduction(IRequestIdManager requestManager,int buildingId, int productLenght=1)
        {
            SetRequestClass("CityProductionService");
            SetRequestMethod(GetRequestedMethod());
            SetData(new JArray() { buildingId, productLenght });
            SetId(requestManager.GetNextId);
        }

        [MethodName("pickupProduction")]
        public void PickupProduction(IRequestIdManager requestManager, params int[] buildingId)
        {
            SetRequestClass("CityProductionService");
            SetRequestMethod(GetRequestedMethod());
            SetData(new JArray() {new JArray() {buildingId}});
            SetId(requestManager.GetNextId);
        }
    }
}