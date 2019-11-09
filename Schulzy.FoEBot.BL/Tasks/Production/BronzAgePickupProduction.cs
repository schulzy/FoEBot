using System.Collections.Generic;
using System.Net;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Server.RequestClass;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Manager;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.ResponseProcessor;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.Production
{
    public class BronzAgePickupProduction : ITask
    {
        private IUnityContainer _diContainer;

        public BronzAgePickupProduction(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }
        public int Priority { get; } = 10;
        public void Run()
        {
            Status = FoeTaskStatus.Running;
            var httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            var settings = _diContainer.Resolve<ISettings>();
            var hashCreator = _diContainer.Resolve<IHashCreator>();
            var uri = settings.Gateway;
            var requestIdManager = _diContainer.Resolve<IRequestIdManager>();

            List<int> ids = new List<int> { 249, 271, 272, 273, 377 };
            var cityProductionService = new CityProductionService();
            foreach (var id in ids)
            {
                cityProductionService.PickupProduction(requestIdManager, id);
                var request = cityProductionService.JsonString;
                var signature = hashCreator.GetSignature(request);
                httpManagerInit.InitializeHeader(signature);

                var response = httpManager.SendPostRequest(uri, request, null, null, false);
                ProcessResponse(response);
                if (Status == FoeTaskStatus.Error || Status == FoeTaskStatus.LoginIssue)
                    break;
            }
        }

        private void ProcessResponse(HttpWebResponse response)
        {
            var noSessionCheck = _diContainer.Resolve<INoSessionResponse>();
            var plainResponse = Helper.GetResponseAsString(response);

            if (!noSessionCheck.HasActiveSession(plainResponse))
                Status |= FoeTaskStatus.LoginIssue;
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;
    }
}