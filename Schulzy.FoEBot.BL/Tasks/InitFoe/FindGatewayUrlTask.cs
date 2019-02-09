using System;
using System.IO;
using System.Net;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;
using Schulzy.FoEBot.Interface.Model;
using Schulzy.FoEBot.Interface.Task;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks.InitFoe
{
    public class FindGatewayUrlTask : ITask
    {
        private readonly IUnityContainer _diContainer;
        public int Priority { get; } = 3;

        public FindGatewayUrlTask(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Run()
        {
            var httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            var uri = @"https://hu2.forgeofempires.com/game/index?ref=";
            httpManagerInit.InitializeHeader();
            Status = FoeTaskStatus.Running;
            var response = httpManager.SendGetRequest(uri, null, null, false);
            
            InitGateway(response);
        }

        private void InitGateway(HttpWebResponse response)
        {
            var plainResponse = Helper.GetResponseAsString(response);
            var settings = _diContainer.Resolve<ISettings>();
            using (StringReader reader = new StringReader(plainResponse))
            {
                string line;
                do
                {
                    line = reader.ReadLine();
                    if (line != null && line.Contains("string_gatewayUrl"))
                    {
                        var elements = line.Split(new[] {':'}, 2);
                        if (elements.Length != 2)
                        {
                            Status = FoeTaskStatus.Error;
                            return;
                        }
                        var gatewayRaw = elements[1];
                        int indexBegin = gatewayRaw.IndexOf("'", StringComparison.Ordinal);
                        if (indexBegin < 0)
                            return;
                        int indexEnd = gatewayRaw.IndexOf("'", indexBegin+1, StringComparison.Ordinal);
                        if (indexEnd < 0)
                            return;
                        settings.Gateway = gatewayRaw.Substring(indexBegin, indexEnd - indexBegin); 
                        break;
                    }

                } while (line != null);
            }
        }

        public FoeTaskStatus Status { get; private set; } = FoeTaskStatus.NotStarted;
    }
}