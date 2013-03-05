namespace PegGame
{
    internal class Path
    {
        internal Hole Left { get; set; }
        internal Hole Center { get; set; }
        internal Hole Right { get; set; }

        internal bool IsValid
        {
            get { return (Center.IsFull && (Left.IsFull ^ Right.IsFull)); }
        }

        internal Path(Hole left, Hole center, Hole right)
        {
            Left = left;
            Center = center;
            Right = right;
        }

        private void InvertHoles()
        {
                Left.IsFull ^= true;
                Center.IsFull ^= true;
                Right.IsFull ^= true;
        }

        internal bool JumpIfValid(out string path)
        {
            if (IsValid)
            {
                InvertHoles();

                if (Right.IsFull)
                {
                    path = Left.Name + " > " + Right.Name;
                }
                else
                {
                    path = Right.Name + " > " + Left.Name;
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
