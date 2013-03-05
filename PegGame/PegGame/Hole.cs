namespace PegGame
{
    internal class Hole
    {
        internal int Number { get; set; }
        internal string Name { get; set; }
        internal bool IsFull { get; set; }

        internal Hole(int number, bool isFull = true)
        {
            this.Number = number;
            this.Name = number.ToString("00");
            this.IsFull = isFull;
        }
    }
}
