using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab6oopvn
{
    internal sealed class Mercury : PlanetBase
    {
        private static readonly Lazy<Mercury> _instance = new Lazy<Mercury>(() => new Mercury());
        public static Mercury Instance => _instance.Value;

        private Mercury() : base("Меркурий", 3.3011e23, 4879, 5.79e7) { }
    }
}
