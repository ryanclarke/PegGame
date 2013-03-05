using System;

namespace PegGame
{
    public class Program
    {

        public static void Main()
        {
            Board board = new Board();
            string[] answer = new string[board.Holes.Count];
            
            while (true)
            {
                board.SetBoard(GetEmptyHole());
                Console.WriteLine("===========");

                answer = new Solution().Solve(board);

                for (int i = 0; i <= board.Holes.Count - 3; i++)
                {
                    Console.WriteLine(string.Format("{0:D2}", (i + 1)) + ": " + answer[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("Press Enter to select a new hole.");
                Console.WriteLine("PEGGAME>");
                Console.SetCursorPosition(9, Console.CursorTop - 1);
                Console.ReadLine();
                Console.Clear();
            }
        }

        private static int GetEmptyHole()
        {
            Console.WriteLine("Enter empty hole numbered 1 to 15.");
            Console.WriteLine("PEGGAME>");
            Console.SetCursorPosition(9, Console.CursorTop - 1);
            string input = Console.ReadLine().Trim();

            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    Console.WriteLine("Valid entries are integers from 1 to 15");
                    input = "0";
                }
            }

            return Convert.ToInt32(input);
        }
    }
}
