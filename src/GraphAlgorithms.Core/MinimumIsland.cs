namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, MinimumIsland, that takes in a grid containing Ws and Ls. W represents water
    /// and L represents land. The function should return the size of the smallest island.
    /// An island is a vertically or horizontally connected region of land.
    ///
    /// You may assume that the grid contains at least one island.
    /// </summary>
    public class MinimumIsland
    {
        /// <summary>
        /// r = number of rows
        /// c = number of columns
        /// Time: O(rc)
        /// Space: O(rc)
        /// </summary>
        public int MinimumIslandDepthFirst(char[,] grid)
        {
            var minimumIslandSize = int.MaxValue;
            var visited = new HashSet<(int Row, int Col)>();

            for (var row = 0; row < grid.GetLength(0); row++)
            {
                for (var col = 0; col < grid.GetLength(1); col++)
                {
                    var size = ExploreSizeDepthFirst(grid, row, col, visited);
                    if (size > 0 && size < minimumIslandSize)
                    {
                        minimumIslandSize = size;
                    }
                }
            }

            return minimumIslandSize;
        }

        /// <summary>
        /// Returns the size of an unvisited island.
        /// </summary>
        private static int ExploreSizeDepthFirst(char[,] grid, int row, int col, ISet<(int Row, int Col)> visited)
        {
            if (row < 0 || row >= grid.GetLength(0)) return 0;
            if (col < 0 || col >= grid.GetLength(1)) return 0;
            // OR
            //var rowInbounds = 0 <= row && row < grid.GetLength(0);
            //var colInbounds = 0 <= col && col < grid.GetLength(1);
            //if (!rowInbounds || !colInbounds) return 0;

            if (grid[row, col] == 'W') return 0;
            if (visited.Contains((row, col))) return 0;

            visited.Add((row, col));

            return 1 + ExploreSizeDepthFirst(grid, row - 1, col, visited)
                     + ExploreSizeDepthFirst(grid, row + 1, col, visited)
                     + ExploreSizeDepthFirst(grid, row, col - 1, visited)
                     + ExploreSizeDepthFirst(grid, row, col + 1, visited);
        }
    }
}
