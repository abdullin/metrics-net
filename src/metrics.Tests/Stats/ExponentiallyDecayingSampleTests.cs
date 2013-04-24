using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using NUnit.Framework;
using metrics.Stats;

namespace metrics.Tests.Stats
{
    [TestFixture]
    public class ExponentiallyDecayingSampleTests
    {
        [Test]
        public void Should_not_delete_all_but_one_value()
        {
            var rand = new Random();
            var sample = new ExponentiallyDecayingSample(1028, 0.015 * 100);
            
            for (var i = 0; i < 1028 + 200; i++)
            {
                sample.Update(rand.Next(1000));
                Thread.Sleep(1);
            }
            
            Debug.WriteLine(sample.Count);
            Debug.WriteLine(sample.Values.Count);
            
            var internalValues = sample.GetValues();
            foreach (var internalValue in internalValues)
            {
                Debug.WriteLine(internalValue.Key + ": " + internalValue.Value);
            }

            Assert.AreEqual(1028, sample.Values.Count);
        }
    }
}
