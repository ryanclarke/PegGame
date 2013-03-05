using System.Collections.Generic;

namespace PegGame
{
    internal class Board
    {
        private const int NUMBER_OF_HOLES = 15;

        internal List<Hole> Holes { get; set; }
        internal List<Path> Paths { get; set; }

        internal Board()
        {
            this.Holes = CreateHoles();
            this.Paths = CreatePaths();
        }

        internal void SetBoard(int emptyHole)
        {
            foreach (var hole in this.Holes)
            {
               hole.IsFull = (hole.Number != emptyHole);
            }
        }

        private List<Hole> CreateHoles()
        {
            var holes = new List<Hole>();
            
            for (int i = 1; i <= NUMBER_OF_HOLES; i++)
            {
                holes.Add(new Hole(i));
            }

            return holes;
        }

        private List<Path> CreatePaths()
        {
            var paths = new List<Path>();
            
            foreach (var path in TemplateOfPaths())
            {
                paths.Add(new Path(Holes[path[0]-1], Holes[path[1]-1], Holes[path[2]-1]));
            }

            return paths;
        }

        private List<int[]> TemplateOfPaths()
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
