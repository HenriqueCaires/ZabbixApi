using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, DisableTestParallelization =true, MaxParallelThreads = 1)]

namespace ZabbixApiTests.Integration
{
    public class IntegrationTest
    {
    }
}
