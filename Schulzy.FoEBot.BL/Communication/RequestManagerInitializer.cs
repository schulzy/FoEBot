using System;
using System.Net;
using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Communication
{
    internal class RequestManagerInitializer
    {
        internal void Initialize(IHttpRequestManager manager, string uri)
        {
            manager.Cookies.Add(
                new Cookie("metricsUvId", "cd7c54d8-e974-48dc-9919-4e2c086b4ed1") {Domain = new Uri(uri).Host});
            manager.Cookies.Add(new Cookie("cid", "1447026018") {Domain = new Uri(uri).Host});
            manager.Cookies.Add(new Cookie("_ga", "GA1.2.546886856.1515696976") {Domain = new Uri(uri).Host});
            manager.Cookies.Add(
                new Cookie("ig_conv_last_site", @"https://hu2.forgeofempires.com/game/index")
                {
                    Domain = new Uri(uri).Host
                });
            manager.Cookies.Add(
                new Cookie("mid", @"qavTPKDWP4Bsvm8R6uEzX6qQJ5_jPY3KnUnFje1X") {Domain = new Uri(uri).Host});
            manager.Cookies.Add(new Cookie("startup_microtime", @"1531240589306") {Domain = new Uri(uri).Host});
            manager.Header.Add("Origin", @"https://hu0.forgeofempires.com");
            manager.Header.Add("X-Requested-With", "XMLHttpRequest");
            manager.Header.Add(@"Accept-Encoding", "gzip, deflate, br");
            manager.Header.Add(@"Accept-Language", "en-US,en;q=0.9,hu;q=0.8,de;q=0.7,en-GB;q=0.6");
            manager.UserAgent =
                @"Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            manager.Accept = @"text/plain, */*; q=0.01";
            manager.ContentType = @"application/x-www-form-urlencoded; charset=UTF-8";
        }
    }
}