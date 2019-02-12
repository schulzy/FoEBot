using System.Diagnostics;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Schulzy.FoEBot.BL.Server.RequestClass
{
    internal class BaseRequest
    {
        private dynamic Request { get; set; } = new JObject();

        public string JsonString => "[" + JsonConvert.SerializeObject(Request) + "]";

        public BaseRequest()
        {
            SetClass("ServerRequest");
            SetData("");
            SetRequestClass("");
            SetRequestMethod("");
            SetId("");
        }

        protected string GetRequestedMethod()
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase method = stackTrace.GetFrame(1).GetMethod();
            MethodNameAttribute attribute = (MethodNameAttribute)method.GetCustomAttributes(typeof(MethodNameAttribute), true)[0];
            return attribute.Name;
        }
        
        protected void SetRequestClass(dynamic className)
        {
            Request.requestClass = className;
        }

        protected void SetRequestMethod(dynamic method)
        {
            Request.requestMethod = method;
        }

        protected void SetData(dynamic data)
        {
            Request.requestData = data;
        }

        protected void SetId(dynamic id)
        {
            Request.requestId = id;
        }

        private void SetClass(dynamic serverClass)
        {
            Request.__class__ = serverClass;
        }
    }
}