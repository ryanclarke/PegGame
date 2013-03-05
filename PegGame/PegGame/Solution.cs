namespace PegGame
{
    internal class Solution
    {
        private Board Board { get; set; }
        private int CurrentJump { get; set; }
        private int PathIndex { get; set; }
        private int[] PathIndexes { get; set; }
        private string[] Answer { get; set; }
        private string LastJumpInstruction { get { return Answer[Board.Holes.Count - 3]; } }

        internal string[] Solve(Board board, bool useRecursion = true)
        {
            Board = board;
            CurrentJump = 0;
            PathIndex = 0;
            PathIndexes = new int[Board.Paths.Count - 1];
            Answer = new string[Board.Paths.Count - 3];

            if (useRecursion)
            {
                return RecursiveSolution();
            }
            else
            {
                return IterativeSolution();
            }
        }

        private string[] RecursiveSolution()
        {
            foreach (Path path in Board.Paths)
            {
                if (path.JumpIfValid(out Answer[CurrentJump]))
                {
                    CurrentJump++;
                    Answer = RecursiveSolution();

                    if (string.IsNullOrEmpty(LastJumpInstruction))
                    {
                        path.ReverseJump();
                        Answer[CurrentJump] = string.Empty;
                        CurrentJump--;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return Answer;
        }
        
        private string[] IterativeSolution()
        {
            Path path = Board.Paths[PathIndex];
            string instruction = string.Empty;

            while (string.IsNullOrEmpty(LastJumpInstruction))
            {
                if (path.JumpIfValid(out instruction))
                {
                    path = RecordJumpAndGoToNextMove(instruction);
                    continue;
                }

                path = BackOutIfDeadend(path);

                path = NextPath(path);
            }

            return Answer;
        }

        private Path RecordJumpAndGoToNextMove(string instruction)
        {
            Answer[CurrentJump] = instruction;
            PathIndexes[CurrentJump] = PathIndex;
            CurrentJump++;
            
            Path path = Board.Paths[PathIndex];
            PathIndex = 0;

            return path;
        }

        private Path BackOutIfDeadend(Path path)
        {
            while (PathIndex >= Board.Paths.Count - 1)
            {
                Answer[CurrentJump] = string.Empty;
                PathIndexes[CurrentJump] = 0;

                CurrentJump--;

                PathIndex = PathIndexes[CurrentJump];
                path = Board.Paths[PathIndex];
                path.ReverseJump();

                Answer[CurrentJump] = string.Empty;
                PathIndexes[CurrentJump] = 0;
            }
            return path;
        }

        private Path NextPath(Path path)
        {
            PathIndex++;
            path = Board.Paths[PathIndex];

            return path;
        }
    }
}
