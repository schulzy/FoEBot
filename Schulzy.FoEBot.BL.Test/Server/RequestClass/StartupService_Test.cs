using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Schulzy.FoEBot.BL.Server.RequestClass;
using Schulzy.FoEBot.Interface.Manager;

namespace Schulzy.FoEBot.BL.Test.Server.RequestClass
{
    [TestClass]
    public class StartupService_Test
    {
        [TestMethod]
        public void CreateRequest()
        {
            var startupService = new StartupService();
            var requestManagerMock = new Mock<IRequestIdManager>();
            requestManagerMock.SetupGet(x => x.GetNextId).Returns(1);
            startupService.GetData(requestManagerMock.Object);
            var request = startupService.JsonString;
            string original =
                "[{\"__class__\":\"ServerRequest\",\"requestData\":[],\"requestClass\":\"StartupService\",\"requestMethod\":\"getData\",\"requestId\":1}]";
            Assert.AreEqual(original, request);
        }
    }
}
