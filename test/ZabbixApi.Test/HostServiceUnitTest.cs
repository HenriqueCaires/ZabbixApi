using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ZabbixApi.Entities;
using System.Collections.Generic;
using System.Linq;
using SisMon.Zabbix.Services;

namespace ZabbixApi.Test
{
    [TestClass]
    public class HostServiceUnitTest
    {
        [TestMethod]
        public void TryGetSomeHost()
        {
            using (var context = new Context() as IContext)
            {
                var target = new HostService(context) as IHostService;
                var result = target.GetByName("teste2").FirstOrDefault();
                result.host = "teste2";
                result.name = "teste2";

                result.interfaces[0].ip = "172.20.12.57";

                var v = target.Update(result);
            }
        }
    }
}
