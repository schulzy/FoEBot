using Newtonsoft.Json.Linq;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class CityProductionService : BaseRequest
    {
        [MethodName("startProduction")]
        public void StartProduction(IRequestIdManager requestManager,int buildingId, int productLenght=1)
        {
            Request.requestClass = "CityProductionService";
            Request.requestMethod = GetRequestedMethod();
            Request.requestData = new JArray() {buildingId, productLenght};
            Request.requestId = requestManager.GetNextId;
        }

        [MethodName("pickupProduction")]
        public void PickupProduction(IRequestIdManager requestManager, params int[] buildingId)
        {
            Request.requestClass = "CityProductionService";
            Request.requestMethod = GetRequestedMethod();
            Request.requestData = new JArray() {new JArray() {buildingId}};
            Request.requestId = requestManager.GetNextId;
        }
    }
}