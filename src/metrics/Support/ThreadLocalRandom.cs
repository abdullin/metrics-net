using System;
using System.Threading;

namespace metrics.Support
{
    class ThreadLocalRandom
    {
        public static ThreadLocal<System.Random> _random;

        static ThreadLocalRandom()
        {
            _random = new ThreadLocal<System.Random>(() => new System.Random(Guid.NewGuid().GetHashCode()));
        }

        public double NextNonzeroDouble()
        {
            var r = _random.Value.NextDouble();
            return Math.Max(r, Double.Epsilon);
        }
    }
}
