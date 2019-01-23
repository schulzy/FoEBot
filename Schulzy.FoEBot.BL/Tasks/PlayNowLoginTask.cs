using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;
using Unity;

namespace Schulzy.FoEBot.BL.Tasks
{
    class PlayNowLoginTask : ITask
    {
        private int _priority;
        private IRequestManagerInitializer _httpManagerInit;
        private string _uri;
        private IHttpRequestManager _httpManager;
        private IUnityContainer _diContainer;

        public int Priority
        {
            get { return _priority; }
        }

        public PlayNowLoginTask(IUnityContainer diContainer)
        {
            _diContainer = diContainer;
            _priority = 100;
            _httpManager = diContainer.Resolve<IHttpRequestManager>();
            _httpManagerInit = diContainer.Resolve<IRequestManagerInitializer>();
            _uri = @"https://hu0.forgeofempires.com/start/index?action=play_now_login";
            _httpManagerInit.InitializeCookies(_uri);
            _httpManagerInit.InitializeHeader();
        }

        public void Run()
        {
            string content = "json=%7B%22world_id%22%3A%22hu2%22%7D";
            var response = _httpManager.SendPostRequest(_uri, content, null, null, false);
            InitToken(response);
        }

        private void InitToken(HttpWebResponse response)
        {
            var settings = _diContainer.Resolve<ISettings>();
            string tokenConst = "token=";
            var plainResponse = Helper.GetResponseAsString(response);
            int indexBegin = plainResponse.IndexOf(tokenConst, StringComparison.Ordinal);
            if(indexBegin<0)
                return;
            int indexEnd = plainResponse.IndexOf("&", indexBegin , StringComparison.Ordinal);
            if(indexEnd<0)
                return;

            var token = plainResponse.Substring(indexBegin + tokenConst.Length, indexEnd - indexBegin- tokenConst.Length);
            settings.Token = token;

        }

        
    }
}
