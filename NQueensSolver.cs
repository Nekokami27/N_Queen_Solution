namespace NQueen
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class NQueensSolver
    {
        private static void Main()
        {
            int solutionCount = 0;
            IList<IList<string>> solutions = SolveNQueens(8);
            StringBuilder sb = new();

            foreach (IList<string> innerList in solutions)
            {
                foreach (string str in innerList)
                {
                    sb.AppendLine(str);
                }
                sb.AppendLine();
                solutionCount++;
            }

            Console.WriteLine(sb.ToString());
            Console.WriteLine("Total solutions: " + solutionCount);
        }

        public static IList<IList<string>> SolveNQueens(int n)
        {
            IList<IList<string>> solutions = new List<IList<string>>();
            char[,] currentResult = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    currentResult[i, j] = '.';
                }
            }

            Backtrack(solutions, currentResult, 0);
            return solutions;
        }

        private static void Backtrack(IList<IList<string>> solutions, char[,] currentResult, int x)
        {
            for (int j = 0; j < currentResult.GetLength(1); j++)
            {
                if (IsValid(currentResult, x, j))
                {
                    currentResult[x, j] = 'Q';
                    if (x == currentResult.GetLength(0) - 1)
                    {
                        SaveResult(solutions, currentResult);
                    }
                    else
                    {
                        Backtrack(solutions, currentResult, x + 1);
                    }
                    currentResult[x, j] = '.';
                }
            }
        }

        private static bool IsValid(char[,] currentResult, int x, int y)
        {
            int n = currentResult.GetLength(0);

            for (int i = 0; i < x; i++)
            {
                if (currentResult[i, y] == 'Q')
                {
                    return false;
                }

                int leftDiagonal = y - (x - i);
                int rightDiagonal = y + (x - i);

                if (leftDiagonal >= 0 && currentResult[i, leftDiagonal] == 'Q')
                {
                    return false;
                }

                if (rightDiagonal < n && currentResult[i, rightDiagonal] == 'Q')
                {
                    return false;
                }
            }

            return true;
        }

        private static void SaveResult(IList<IList<string>> solutions, char[,] currentResult)
        {
            List<string> list = new();
            StringBuilder sb = new();

            for (int i = 0; i < currentResult.GetLength(0); i++)
            {
                sb.Clear();
                for (int j = 0; j < currentResult.GetLength(1); j++)
                {
                    sb.Append(currentResult[i, j]);
                }
                list.Add(sb.ToString());
            }

            solutions.Add(list);
        }
    }
}