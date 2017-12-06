using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using FizzWare.NBuilder;
using Xunit;
using FizzWare.NBuilder;
using Moq;
using ZabbixApi;
using ZabbixApi.Services;
namespace ZabbixApiTests
{
    public class HostServiceTest
    {
        
        public HostServiceTest()
        {
            var ctx = new Context();
            var service = new HostService(ctx);
            
        }
    }
}
