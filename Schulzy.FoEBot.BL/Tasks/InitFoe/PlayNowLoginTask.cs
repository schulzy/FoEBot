using System;
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
    internal class PlayNowLoginTask : ITask
    {
        private string _uri;
        private IHttpRequestManager _httpManager;
        private readonly IUnityContainer _diContainer;

        public int Priority { get; }

        public PlayNowLoginTask(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
            Priority = 1;
        }

        public void Run()
        {
            _httpManager = _diContainer.Resolve<IHttpRequestManager>();
            var _httpManagerInit = _diContainer.Resolve<IRequestManagerInitializer>();
            _uri = @"https://hu0.forgeofempires.com/start/index?action=play_now_login";
            _httpManagerInit.InitializeCookies(_uri);
            _httpManagerInit.InitializeHeader();
            string content = "json=%7B%22world_id%22%3A%22hu2%22%7D";
            var response = _httpManager.SendPostRequest(_uri, content, null, null, false);
            InitToken(response);
        }

        public FoeTaskStatus Status { get; } = FoeTaskStatus.NotStarted;

        private void InitToken(HttpWebResponse response)
        {
            var settings = _diContainer.Resolve<ISettings>();
            string tokenConst = "token=";
            var plainResponse = Helper.GetResponseAsString(response);
            int indexBegin = plainResponse.IndexOf(tokenConst, StringComparison.Ordinal);
            if (indexBegin < 0)
                return;
            int indexEnd = plainResponse.IndexOf("\"}", indexBegin, StringComparison.Ordinal);
            if (indexEnd < 0)
                return;

            var token = plainResponse.Substring(indexBegin, indexEnd - indexBegin);
            settings.Token = token;
        }
    }
}
