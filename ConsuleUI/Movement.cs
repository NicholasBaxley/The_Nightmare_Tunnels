using System;
using System.Collections.Generic;
using System.Text;

namespace ConsuleUI
{
    public class Movement
    {
        public static void MoveNorth(ref int position)
        {
            if (position < 4)
            {
                position++;
            }
        }

        public static void MoveSouth(ref int position)
        {
            if (position > 0)
            {
                position--;
            }
        }
    }
}
