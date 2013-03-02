using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegGame
{
    internal class Path
    {
        internal Hole Left { get; set; }
        internal Hole Center { get; set; }
        internal Hole Right { get; set; }

        internal bool IsValid
        {
            get { return (Center.IsFull & (Left.IsFull ^ Right.IsFull)); }
        }

        internal Path(Hole left, Hole center, Hole right)
        {
            this.Left = left;
            this.Center = center;
            this.Right = right;
        }

        internal bool JumpIfValid(out string path)
        {
            if (IsValid)
            {
                this.Left.IsFull ^= true;
                this.Center.IsFull ^= true;
                this.Right.IsFull ^= true;
                
                if (Right.IsFull)
                {
                    //Console.WriteLine(this.Left.Number + " ---->> " + this.Right.Number);
                    path =  this.Left.Number + " > " + this.Right.Number;
                }
                else
                {
                    //Console.WriteLine(this.Right.Number + " ---->> " + this.Left.Number);
                    path =  this.Right.Number + " > " + this.Left.Number;
                }
                return true;
            }
            else
            {
                path = string.Empty;
                return false;
            }
        }

        internal void Reverse()
        {
            this.Left.IsFull ^= true;
            this.Center.IsFull ^= true;
            this.Right.IsFull ^= true;

            if (Right.IsFull)
            {
                //Console.WriteLine(this.Right.Number + " <<---- " + this.Left.Number);
            }
            else
            {
                //Console.WriteLine(this.Left.Number + " <<---- " + this.Right.Number);
            }
        }
    }
}
