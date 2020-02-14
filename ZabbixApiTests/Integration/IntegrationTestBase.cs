using System;
using Xunit;
using ZabbixApi;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, DisableTestParallelization =true, MaxParallelThreads = 1)]

namespace ZabbixApiTests.Integration
{
    public class IntegrationTestBase : IDisposable
    {
        protected readonly IContext context;

        public IntegrationTestBase()
        {
            context = new Context();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
