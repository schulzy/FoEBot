using System;
using System.Net;
using Schulzy.FoEBot.Interface;
using Schulzy.FoEBot.Interface.Communications;

namespace Schulzy.FoEBot.BL.Communication
{
    internal class RequestManagerInitializer : IRequestManagerInitializer
    {
        private readonly IHttpRequestManager _httpRequestManager;

        public RequestManagerInitializer(IHttpRequestManager httpRequestManager)
        {
            _httpRequestManager = httpRequestManager;
        }

        public void InitializeHeader()
        {
            _httpRequestManager.Header.Add("Origin", @"https://hu0.forgeofempires.com");
            _httpRequestManager.Header.Add("X-Requested-With", "XMLHttpRequest");
            _httpRequestManager.Header.Add(@"Accept-Encoding", "gzip, deflate, br");
            _httpRequestManager.Header.Add(@"Accept-Language", "en-US,en;q=0.9,hu;q=0.8,de;q=0.7,en-GB;q=0.6");
            _httpRequestManager.UserAgent =
                @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            _httpRequestManager.Accept = @"text/plain, */*; q=0.01";
            _httpRequestManager.ContentType = @"application/x-www-form-urlencoded; charset=UTF-8";
        }

        public void InitializeCookies(string uri)
        {
            _httpRequestManager.Cookies.Add(
                new Cookie("metricsUvId", "67476666-b328-4799-8d24-c1f9782cda5c") {Domain = new Uri(uri).Host});
            _httpRequestManager.Cookies.Add(new Cookie("cid", "2054610294") {Domain = new Uri(uri).Host});
            _httpRequestManager.Cookies.Add(
                new Cookie("_ga", "GA1.2.546886856.1515696976") {Domain = new Uri(uri).Host});
            _httpRequestManager.Cookies.Add(
                new Cookie("ig_conv_last_site", @"https://hu2.forgeofempires.com/game/index")
                {
                    Domain = new Uri(uri).Host
                });
            _httpRequestManager.Cookies.Add(
                new Cookie("mid", @"gTwKfh6C6K-47fPf1K5uhNU2wSmtA2jzgVlpqvpx") {Domain = new Uri(uri).Host});
            _httpRequestManager.Cookies.Add(
                new Cookie("startup_microtime", @"1548275351309") {Domain = new Uri(uri).Host});
        }
    }

    internal interface IRequestManagerInitializer
    {
        void InitializeHeader();

        void InitializeCookies(string uri);
    }
}