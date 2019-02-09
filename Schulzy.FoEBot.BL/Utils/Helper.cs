using System.Net;
using System.Text;

namespace Schulzy.FoEBot.BL.Utils
{
    internal static class Helper
    {
        public static string GetResponseAsString(HttpWebResponse response)
        {
            var encoding = Encoding.ASCII;
            string responseText = string.Empty;
            var stream = response?.GetResponseStream();
            if (stream != null)
            {
                using (var reader = new System.IO.StreamReader(stream, encoding))
                {
                    responseText = reader.ReadToEnd();
                }
            }
            return responseText;
        }
    }
}
