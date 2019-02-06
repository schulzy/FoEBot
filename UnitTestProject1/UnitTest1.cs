using Microsoft.VisualStudio.TestTools.UnitTesting;
using Schulzy.FoEBot.BL;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "0TmPDOZ7ciiZjOnusowfMG3-";
            string secret = "Rw7oeLIP29HTVWjgS3NG6UzoyfIoEtwUR3pY/if76FdLOZHUPRLGHVDRCkdk4zijAqv4YGXBtIbKKnDCn7/8+A==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.Equals("94bfbfa0ce", signature);
        }

        [TestMethod]
        public void TestMethod2()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "vpGv01DRo23aAJMqi35PjjcH";
            string secret = "X2hSCLmVfPKbmWIMm88CfEokCPVIfhV1cooHcF4yopCUkfEQJ6IsaDWsZHkz1xTfWAOdWPn2Iwp6wbLmnJBElw==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.Equals("5cd4cde2b0", signature);
        }
    }
}
