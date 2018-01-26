using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using ZabbixApi.Services;
using Moq;
namespace ZabbixApi.Test
{
    [TestClass]
    [DeploymentItem(@"Samples\Action\action.get.json", @"Samples\Action\")]
    public class ActionServiceUnitTest
    {
        string _actionGet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +  @"\Samples\Action\action.get.json";
        JsonSerializerSettings _settings;
        IContext _context;

        public ActionServiceUnitTest()
        {
            _settings = new JsonSerializerSettings();
            _settings.Converters = new JsonConverter[] { new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter() }; ;
            _settings.NullValueHandling = NullValueHandling.Ignore;
        }

        [TestInitialize]
        public void Initialize()
        {
            var mock = new Mock<IContext>();
            var data = JsonConvert.DeserializeObject<Entities.Action[]>(File.ReadAllText(_actionGet), _settings);
            mock.Setup(x => x.SendRequest<Entities.Action[]>(It.IsAny<object>(), It.IsAny<string>())).Returns(data);
            _context = mock.Object;
            
        }

        [TestMethod]
        public void GetAction_SomeName_SomeHost()
        {
            var target = new ActionService(_context) as IActionService;
            
            var result = target.Get();

            Assert.AreEqual(5, result.Count());
        }
    }
}
