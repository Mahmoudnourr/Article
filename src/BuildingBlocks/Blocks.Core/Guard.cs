using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blocks.Core
{
    public static  class Guard
    {
        public static void ThrowIfNullorWhiteSpace (string value) =>
            ArgumentException.ThrowIfNullOrWhiteSpace(value, "Value cannot be null or empty.");
    }
}
