using System;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulzy.FoEBot.BL.Communication;
using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Test
{
    [TestClass]
    public class HttpRequestTest
    {
        IHttpRequestManager _manager = new HttpRequestManager();
        [TestMethod]
        public void PlayNowLogin()
        {
            string uri = @"https://hu0.forgeofempires.com/start/index?action=play_now_login ";
            string content = "json=%7B%22world_id%22%3A%22hu2%22%7D";

            _manager.Cookies.Add(new Cookie("metricsUvId", "cd7c54d8-e974-48dc-9919-4e2c086b4ed1") { Domain = new Uri(uri).Host });
            _manager.Cookies.Add(new Cookie("cid", "1447026018") { Domain = new Uri(uri).Host });
            _manager.Cookies.Add(new Cookie("_ga", "GA1.2.546886856.1515696976") { Domain = new Uri(uri).Host });
            _manager.Cookies.Add(new Cookie("ig_conv_last_site", @"https://hu2.forgeofempires.com/game/index") { Domain = new Uri(uri).Host });
            _manager.Cookies.Add(new Cookie("mid", @"qavTPKDWP4Bsvm8R6uEzX6qQJ5_jPY3KnUnFje1X") { Domain = new Uri(uri).Host });
            _manager.Cookies.Add(new Cookie("startup_microtime", @"1531240589306") { Domain = new Uri(uri).Host });
            _manager.Header.Add("Origin", @"https://hu0.forgeofempires.com");
            _manager.Header.Add("X-Requested-With", "XMLHttpRequest");
            _manager.Header.Add(@"Accept-Encoding", "gzip, deflate, br");
            _manager.Header.Add(@"Accept-Language", "en-US,en;q=0.9,hu;q=0.8,de;q=0.7,en-GB;q=0.6");
            _manager.UserAgent =
                @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            _manager.Accept = @"text/plain, */*; q=0.01";
            _manager.ContentType = @"application/x-www-form-urlencoded; charset=UTF-8";
            var response = _manager.SendPostRequest(uri, content, null, null, false);

            WebHeaderCollection header = response.Headers;

            var encoding = ASCIIEncoding.ASCII;
            string responseText = string.Empty;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }
        }
    }
}
