using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZabbixApi.Entities;
using System.Collections.Generic;
using System.Linq;
using ZabbixApi.Services;
using Newtonsoft.Json;
using Rhino.Mocks;
using System.IO;

namespace ZabbixApi.Test
{
    [TestClass]
    [DeploymentItem(@"Samples\Host\host.get.json", @"Samples\Host\")]
    public class HostServiceUnitTest
    {
        string _hostGet = @"Samples\Host\host.get.json";
        JsonSerializerSettings _settings;
        IContext _context;

        public HostServiceUnitTest()
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
            var data = JsonConvert.DeserializeObject<Host[]>(File.ReadAllText(_hostGet), _settings);

            _context.Stub(x => x.SendRequest<Host[]>(Arg<object>.Is.Anything, Arg<string>.Is.Anything)).Return(data);

            var target = new HostService(_context) as IHostService;
            
            var result = target.GetByName("teste");

            var r = result;

            Assert.AreEqual("teste", r.host);
            Assert.AreEqual("127.0.0.1", r.interfaces.First().ip);
        }
    }
}
