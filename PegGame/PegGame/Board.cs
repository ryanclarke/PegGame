using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PegGame
{
    internal static class Board
    {
        internal static List<Path> Create(int emptyHole)
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
            template.Add(new int[] { 3, 6, 10 });
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
