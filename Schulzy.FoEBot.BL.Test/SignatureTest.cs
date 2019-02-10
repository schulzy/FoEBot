
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Schulzy.FoEBot.BL.Utils;
using Schulzy.FoEBot.Interface;

namespace Schulzy.FoEBot.BL.Test
{
    [TestClass]
    public class SignatureTest
    {
        private ISettings _settings = new Mock<ISettings>().Object;
        [TestMethod]
        public void Version_1_143()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "0TmPDOZ7ciiZjOnusowfMG3-";
            string secret = "Rw7oeLIP29HTVWjgS3NG6UzoyfIoEtwUR3pY/if76FdLOZHUPRLGHVDRCkdk4zijAqv4YGXBtIbKKnDCn7/8+A==";
            HashCreator hashCreator = new HashCreator(_settings);
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
            HashCreator hashCreator = new HashCreator(_settings);
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
            HashCreator hashCreator = new HashCreator(_settings);
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.AreEqual("2c3dbe779e", signature.Substring(0,10));
        }

        [TestMethod]
        public void Version_1_145_2()
        {
            string payload =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            string userkey = "r7XrEknlQw50DdNDiy_bs21V";
            string secret = "5ojZ7ltWda/CMrY6IhVwdvAMYK9Gy5QLIdrSDitg9/ugY9y8YL8haQp7ZR6EXZo182gNenXv0Er4F2p1myI0MA==";
            HashCreator hashCreator = new HashCreator(_settings);
            string signature = hashCreator.GetMd5Hash(userkey + secret + payload);
            Assert.AreEqual("d3809d0e2c", signature.Substring(0, 10));
        }

        [TestMethod]
        public void HashCreatorTest_Own()
        {
            var settingsMock = new Mock<ISettings>();
            settingsMock.SetupGet(x => x.Secret)
                .Returns("5ojZ7ltWda/CMrY6IhVwdvAMYK9Gy5QLIdrSDitg9/ugY9y8YL8haQp7ZR6EXZo182gNenXv0Er4F2p1myI0MA==");
            settingsMock.SetupGet(x => x.Gateway)
                .Returns(@"https://hu2.forgeofempires.com/game/json?h=uq-1o7C-SbFvHG4pO1d9wWm_");
            var hashCreator = new HashCreator(settingsMock.Object);
            var signature = hashCreator.GetSignature("[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]");
            Assert.AreNotEqual("299cb9de64", signature);
        }

        [TestMethod]
        public void HashCreatorTest_Origin()
        {
            var settingsMock = new Mock<ISettings>();
            settingsMock.SetupGet(x => x.Secret)
                .Returns("5ojZ7ltWda/CMrY6IhVwdvAMYK9Gy5QLIdrSDitg9/ugY9y8YL8haQp7ZR6EXZo182gNenXv0Er4F2p1myI0MA==");
            settingsMock.SetupGet(x => x.Gateway)
                .Returns(@"https://hu2.forgeofempires.com/game/json?h=r7XrEknlQw50DdNDiy_bs21V");
            var hashCreator = new HashCreator(settingsMock.Object);
            var signature = hashCreator.GetSignature("[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]");
            Assert.AreEqual("d3809d0e2c", signature);
        }

    }
}
