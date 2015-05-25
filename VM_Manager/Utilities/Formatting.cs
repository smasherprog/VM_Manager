using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VM_Manager.Utilities
{
    public static class Formatting
    {
        public static string Format(long bytes)
        {
            const long scale = 1024;
            string[] orders = new string[] { "TB", "GB", "MB", "KB", "Bytes" };
            var max = (long)Math.Pow(scale, (orders.Length - 1));
            foreach(string order in orders)
            {
                if(bytes > max)
                    return string.Format("{0:##.##} {1}", Decimal.Divide(bytes, max), order);
                max /= scale;
            }
            return "0 Bytes";
        }
    }
}
