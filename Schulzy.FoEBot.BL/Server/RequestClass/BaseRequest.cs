using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class BaseRequest
    {
        protected dynamic Request { get; set; } = new JObject();

        public string JsonString => "[" + JsonConvert.SerializeObject(Request) + "]";

        public BaseRequest()
        {
            Request.__class__ = "ServerRequest";
            Request.requestData = "";
            Request.requestClass = "";
            Request.requestMethod = "";
            Request.requestId = "";
        }

        protected string GetRequestedMethod()
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            MethodNameAttribute attribute = (MethodNameAttribute)method.GetCustomAttributes(typeof(MethodNameAttribute), true)[0];
            return attribute.Name;
        }
    }
}