using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Newtonsoft.Json;
using Rhino.Mocks;
using System.IO;
using ZabbixApi;
using ZabbixApi.Entities;
using ZabbixApi.Services;
using FizzWare.NBuilder;
using Moq;

namespace ZabbixApi.Test
{
    [TestClass]
    [DeploymentItem(@"Samples\Host\host.get.json", @"Samples\Host\")]
    public class HostServiceUnitTest
    {
        string _hostGet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + @"\Samples\Host\host.get.json";
        JsonSerializerSettings _settings;
        IContext _context;
        Mock<IContext> mock;
        public HostServiceUnitTest()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() }; ;
            _settings.NullValueHandling = NullValueHandling.Ignore;
        }


        [TestInitialize]
        public void Initialize()
        {
            mock = new Mock<IContext>();
            var data = JsonConvert.DeserializeObject<Host[]>(File.ReadAllText(_hostGet), _settings);
            mock.Setup(x => x.SendRequest<Host[]>(It.IsAny<object>(), It.IsAny<string>())).Returns(data);
            
        }

        [TestMethod]
        public void GetHost_SomeName_SomeHost()
        {
            var hostName = "teste";
            _context = mock.Object;
            var target = new HostService(_context) as IHostService;
            
            var result = target.GetByName(hostName);

            var r = result;
            var host = r.host;
            Assert.AreEqual(hostName, host);
            Assert.AreEqual("127.0.0.1", r.interfaces.First().ip);
        }
    }
}
