using Newtonsoft.Json.Linq;
using Schulzy.FoEBot.Interface.ResponseProcessor;

namespace Schulzy.FoEBot.BL.ResponseProcessor
{
    internal class NoSessionResponse : INoSessionResponse
    {
        public bool HasActiveSession(string jsonResponse)
        {
            var jsonVal = JArray.Parse(jsonResponse);
            foreach (var token in jsonVal.Children<JToken>())
            foreach (var property in token.Children<JProperty>())
                if (property.Name.Equals("url"))
                {
                    var propertyValue = property.Value.ToString();
                    if (propertyValue.Contains("nosession"))
                    {
                        return false;
                    }
                }
            return true;
        }
    }
}