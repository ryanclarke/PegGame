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
                this.Left.IsFull = !(this.Left.IsFull);
                this.Center.IsFull = false;
                this.Right.IsFull = !(this.Right.IsFull);
                
                if (Right.IsFull)
                {
                    path =  this.Left.Number + " > " + this.Right.Number;
                }
                else
                {
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

        internal void ReverseJump()
        {
            this.Left.IsFull = !(this.Left.IsFull);
            this.Center.IsFull = true;
            this.Right.IsFull = !(this.Right.IsFull);
        }
    }
}
