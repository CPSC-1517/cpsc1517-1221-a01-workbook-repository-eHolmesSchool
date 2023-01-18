using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NhlSystemClassLibrary
{
    internal static class Utilities
    {
        public static bool NumInRange(int num, int min, int max)
        {
            return num >= min && num <= max;
        }
    }
}
