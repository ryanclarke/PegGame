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

        private void InvertHoles()
        {
                this.Left.IsFull ^= true;
                this.Center.IsFull ^= true;
                this.Right.IsFull ^= true;
        }

        internal bool JumpIfValid(out string path)
        {
            if (IsValid)
            {
                InvertHoles();

                if (Right.IsFull)
                {
                    path = this.Left.Name + " > " + this.Right.Name;
                }
                else
                {
                    path = this.Right.Name + " > " + this.Left.Name;
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
            InvertHoles();
        }
    }
}
