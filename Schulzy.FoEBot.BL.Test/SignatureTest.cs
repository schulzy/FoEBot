using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schulzy.FoEBot.BL.Test
{
    [TestClass]
    public class SignatureTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            string payload =
                "[{\"requestId\":1,\"requestMethod\":\"getData\",\"requestClass\":\"StartupService\",\"requestData\":[],\"__class__\":\"ServerRequest\"}]";
            string userkey = "8VeDq-mZ_rJOKjac4ASNr5j1";
            string secret = "BPmkpdLgpRePZjT4bAHnfI+IqyTv3tkoZNBo9ZtUzjHaZCYiBxWTo9Nap4IZZmEDm66g9+NalSsNQbeqeieKCg==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash( userkey + secret + payload);
            Assert.Equals("580f062981", signature);
        }
    }
}
