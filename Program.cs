using System;

using System.Windows.Controls;

// denne klasse bør udfases

namespace CHESSWPF
{
    class Program
    {

        public static int transformX(string input)
        {
            int output = (int)Convert.ToChar(input.Substring(0, 1)) - 65;   // 64 +1 fordi base 0
            return output;
        }
        public static int transformY(string input)
        {
            int output = 7- Convert.ToInt32(input.Substring(1, 1)) +1;  // fordi...
            return output;
        }

        public static Board Board1 = new Board();
    }
}
