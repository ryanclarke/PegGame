using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegGame
{
    class Program
    {
        const int MAX_LEVEL = 20;

        static void Main()
        {
            List<Path> board = CreateBoard(Convert.ToInt32(Console.ReadLine()));
            string[] answer = new string[MAX_LEVEL];
            int level = 0;
            answer = Move(board, answer, level);
            int i = 0;
            foreach (string step in answer)
            {
                Console.WriteLine(string.Format("{0:D2}", ++i) + ": " + step);
            }
            Console.ReadLine();
        }

        internal static string[] Move(List<Path> board, string[] answer, int level)
        {
            foreach (Path path in board)
            {
                if (path.JumpIfValid(out answer[level]))
                {
                    Console.WriteLine(level);
                    if (level == 1)
                    {}
                    answer = Move(board, answer, ++level);
                    if (!string.IsNullOrEmpty(answer[13]))
                    {
                        break;
                    }
                    else
                    {
                        answer[level] = string.Empty;
                        path.ReverseJump();
                    }
                }
            }
            return answer;
        }

        internal static List<Path> CreateBoard(int emptyHole)
        {
            var hole = new Dictionary<int, Hole>();
            for (int i = 1; i <= 15; i++)
            {
                hole.Add(i, new Hole(i, (i != emptyHole)));
            }

            var paths = new List<Path>();
            foreach (var path in TemplateOfPaths())
            {
                paths.Add(new Path(hole[path[0]], hole[path[1]], hole[path[2]]));
            }

            return paths;

        }

        internal static List<int[]> TemplateOfPaths()
        {
            var template = new List<int[]>();

            template.Add(new int[] { 1, 2, 4 });
            template.Add(new int[] { 1, 3, 6 });
            template.Add(new int[] { 2, 4, 7 });
            template.Add(new int[] { 2, 5, 9 });
            template.Add(new int[] { 3, 5, 8 });
            template.Add(new int[] { 4, 5, 6 });
            template.Add(new int[] { 4, 7, 11 });
            template.Add(new int[] { 4, 8, 13 });
            template.Add(new int[] { 5, 8, 12 });
            template.Add(new int[] { 5, 9, 14 });
            template.Add(new int[] { 6, 9, 13 });
            template.Add(new int[] { 6, 10, 15 });
            template.Add(new int[] { 7, 8, 9 });
            template.Add(new int[] { 8, 9, 10 });
            template.Add(new int[] { 11, 12, 13 });
            template.Add(new int[] { 12, 13, 14 });
            template.Add(new int[] { 13, 14, 15 });

            return template;
        }
    }
}
