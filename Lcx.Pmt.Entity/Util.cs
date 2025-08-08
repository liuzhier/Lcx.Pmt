using System;
using System.Collections.Generic;
using System.Text;

namespace Lcx.Pmt.Entity
{
    public class Util
    {
        public static void CheckoutArrayIndex(int length, ref int index, ref int index2)
        {
            (index, index2) = CheckoutArrayIndex(length, index, index2);
        }
        public static (int, int) CheckoutArrayIndex(int length, int index, int index2)
        {
            if (index < 0) index = length - index;
            if (index2 < 0) index2 = length - index2;

            return (index, index2);
        }
    }
}
