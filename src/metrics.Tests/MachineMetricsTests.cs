using System.Collections.Generic;
using NUnit.Framework;
using metrics;
using metrics.Core;

namespace metrics.Tests
{
    [TestFixture]
    public class MachineMetricsTests
    {
        [Test]
        public void Can_load_all_metrics()
        {
            Metrics.Clear();

            MachineMetrics.InstallAll();

            Assert.IsTrue(Metrics.All.Count > 0);
        }

        [Test]
        public void Can_load_CLR_metrics()
        {
            Metrics.Clear();
            MachineMetrics.InstallCLRLocksAndThreads();
            IDictionary<MetricName, IMetric> allMetrics = Metrics.All;
            Assert.IsTrue(allMetrics.Count > 0);
        }
    }
}
