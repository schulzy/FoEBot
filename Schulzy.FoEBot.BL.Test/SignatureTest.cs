
using NUnit.Framework;

namespace Schulzy.FoEBot.BL.Test
{
    [TestFixture]
    public class SignatureTest
    {
        [Test]
        public void TestMethod1()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "0TmPDOZ7ciiZjOnusowfMG3-";
            string secret = "Rw7oeLIP29HTVWjgS3NG6UzoyfIoEtwUR3pY/if76FdLOZHUPRLGHVDRCkdk4zijAqv4YGXBtIbKKnDCn7/8+A==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash( userkey + secret + payload);
            Assert.Equals("94bfbfa0ce", signature);
        }
    }
}
