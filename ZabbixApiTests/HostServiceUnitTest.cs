﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using ZabbixApi.Entities;
using ZabbixApi.Services;
using Moq;
using System;
namespace ZabbixApi.Test
{
    [TestClass]
    [DeploymentItem(@"Samples\Host\host.get.json", @"Samples\Host\")]
    public class HostServiceUnitTest
    {
        string _hostGet = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Samples\Host\host.get.json";
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

        [TestMethod]
        public void CheckStatus()
        {
            const string url = "http://myzabbixserver/zabbix/api_jsonrpc.php";
            const string user = "Admin";
            const string password = "zabbix";

            var ctx = new Context(url, user, password);
            Assert.IsNotNull(ctx);
        }

        [TestMethod]
        public void GetVersion()
        {
            var _zabbixContext = new Context();
            var apiInfoService = new ApiInfoService();
            var version = apiInfoService.GetVersion();
            Assert.IsNotNull(version);
            Assert.IsFalse(version == "");
            //return !string.IsNullOrWhiteSpace(version);
        }

    }
}
