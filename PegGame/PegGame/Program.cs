using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegGame
{
    class Program
    {
        const int ARRAY_SIZE = 14;

        static void Main()
        {
            string[] answer = new string[ARRAY_SIZE];
            List<Path> board = new List<Path>();
            while (true)
            {
                board = Board.Create(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("===========");
                int level = 0;
                answer = new string[ARRAY_SIZE];
                answer = MoveLoop(board.ToArray(), answer, level);

                for (int i = 0; i <= 12; i++)
                {
                    Console.WriteLine(string.Format("{0:D2}", (i + 1)) + ": " + answer[i]);
                }
                Console.WriteLine("");
                Console.WriteLine("");
            }
        }

        internal static string[] Move(List<Path> board, string[] answer, int level)
        {
            foreach (Path path in board)
            {
                if (path.JumpIfValid(out answer[level]))
                {
                    //Console.WriteLine(level);

                    answer = Move(board, answer, ++level);

                    if (!string.IsNullOrEmpty(answer[ARRAY_SIZE - 2]))
                    {
                        break;
                    }
                    else
                    {
                        if (level == 0)
                        { }
                        answer[level--] = string.Empty;
                        path.Reverse();
                    }
                }
            }
            return answer;
        }

        internal static string[] MoveLoop(Path[] board, string[] answer, int level)
        {
            int i = 0;
            Path path = board[i];
            int[] pathIndexStack = new int[board.Length - 1];

            while (string.IsNullOrEmpty(answer[ARRAY_SIZE - 2]))
            {
                
                if (path.JumpIfValid(out answer[level]))
                {
                if (level == 12)
                { }
                    pathIndexStack[level] = i;
                    path = board[i];
                    level++;
                    i = 0;
                    continue;
                }

                while (i >= board.Length - 1)
                {
                    answer[level] = string.Empty;
                    pathIndexStack[level] = 0;
                    
                    if (level == 0)
                    { return answer; }
                    level--;
                    
                    i = pathIndexStack[level];
                    path = board[i];
                    path.Reverse();

                    answer[level] = string.Empty;
                    pathIndexStack[level] = 0;

                    if (i == 15)
                    { }
                }

                i++;
                path = board[i];
            }

            return answer;
        }
    }
}
