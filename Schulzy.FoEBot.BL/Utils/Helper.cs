using System.Net;
using System.Text;

namespace Schulzy.FoEBot.BL.Utils
{
    internal static class Helper
    {
        public static string GetResponseAsString(HttpWebResponse response)
        {
            var encoding = Encoding.ASCII;
            string responseText;
            using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
            {
                responseText = reader.ReadToEnd();
            }

            return responseText;
        }
    }
}
