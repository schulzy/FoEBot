using System;
using System.Net;

namespace Schulzy.FoEBot.Interface
{
    public interface IHttpRequestManager
    {
        CookieContainer Cookies { get; }
        WebHeaderCollection Header { get; }
        string UserAgent { get; set; }
        string Accept { get; set; }
        string ContentType { get; set; }

        string GetCookieValue(Uri siteUri, string name);
        string GetResponseContent(HttpWebResponse response);

        HttpWebResponse SendPostRequest(string uri, string content, string login, string password,
            bool allowAutoRedirect);

        HttpWebResponse SendGetRequest(string uri, string login, string password, bool allowAutoRedirect);

        HttpWebResponse SendRequest(string uri, string content, string method, string login, string password,
            bool allowAutoRedirect);

        HttpWebRequest GenerateGetRequest(string uri, string login, string password, bool allowAutoRedirect);

        HttpWebRequest GeneratePostRequest(string uri, string content, string login, string password,
            bool allowAutoRedirect);
    }
}