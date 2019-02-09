
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Schulzy.FoEBot.BL.Test
{
    [TestClass]
    public class SignatureTest
    {
        [TestMethod]
        public void Version_1_143()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "0TmPDOZ7ciiZjOnusowfMG3-";
            string secret = "Rw7oeLIP29HTVWjgS3NG6UzoyfIoEtwUR3pY/if76FdLOZHUPRLGHVDRCkdk4zijAqv4YGXBtIbKKnDCn7/8+A==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.AreEqual("94bfbfa0ce", signature.Substring(0, 10));
        }

        [TestMethod]
        public void Version_1_144()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "vpGv01DRo23aAJMqi35PjjcH";
            string secret = "X2hSCLmVfPKbmWIMm88CfEokCPVIfhV1cooHcF4yopCUkfEQJ6IsaDWsZHkz1xTfWAOdWPn2Iwp6wbLmnJBElw==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.AreEqual("5cd4cde2b0", signature.Substring(0, 10));
        }

        [TestMethod]
        public void Version_1_145()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "hhPLdp2KVLoJfhLkOsvL6Np0";
            string secret = "5ojZ7ltWda/CMrY6IhVwdvAMYK9Gy5QLIdrSDitg9/ugY9y8YL8haQp7ZR6EXZo182gNenXv0Er4F2p1myI0MA==";
            HashCreator hashCreator = new HashCreator();
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.AreEqual("2c3dbe779e", signature.Substring(0,10));
        }
    }
}
