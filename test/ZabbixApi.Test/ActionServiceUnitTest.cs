using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Rhino.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZabbixApi.Services;
using ZabbixApi;

namespace ZabbixApi.Test
{
    [TestClass]
    [DeploymentItem(@"Samples\Action\action.get.json", @"Samples\Action\")]
    public class ActionServiceUnitTest
    {
        string _actionGet = @"Samples\Action\action.get.json";
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
            _context = MockRepository.GenerateStub<IContext>();
        }

        [TestMethod]
        public void GetHost_SomeName_SomeHost()
        {
            var data = JsonConvert.DeserializeObject<Entities.Action[]>(File.ReadAllText(_actionGet), _settings);

            _context.Stub(x => x.SendRequest<Entities.Action[]>(Arg<object>.Is.Anything, Arg<string>.Is.Anything)).Return(data);

            var target = new ActionService(_context) as IActionService;
            
            var result = target.Get();

            Assert.AreEqual(5, result.Count());
        }
    }
}
