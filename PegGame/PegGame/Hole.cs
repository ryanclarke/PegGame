using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegGame
{
    internal class Hole
    {
        internal string Number { get; set; }
        internal bool IsFull { get; set; }

        internal Hole(int number, bool isFull)
        {
            this.Number = number.ToString("00");
            this.IsFull = isFull;
        }
    }
}
