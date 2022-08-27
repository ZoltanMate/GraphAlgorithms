namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, IslandCount, that takes in a grid containing Ws and Ls. W represents water
    /// and L represents land. The function should return the number of islands on the grid.
    /// An island is a vertically or horizontally connected region of land.
    /// </summary>
    public class IslandCount
    {
        /// <summary>
        /// r = number of rows
        /// c = number of columns
        /// Time: O(rc)
        /// Space: O(rc)
        /// </summary>
        public int IslandCountBreadthFirst(char[,] grid)
        {
            var visited = new HashSet<(int Row, int Col)>();
            var islands = 0;
            var queue = new Queue<(int Row, int Col)>();

            for (var row = 0; row < grid.GetLength(0); row++)
            {
                for (var col = 0; col < grid.GetLength(1); col++)
                {
                    var actualSpot = (row, col);
                    if (grid[row, col] == 'L' && !visited.Contains(actualSpot))
                    {
                        queue.Enqueue(actualSpot);

                        while (queue.Any())
                        {
                            var current = queue.Dequeue();
                            if (visited.Contains(current))
                            {
                                continue;
                            }

                            visited.Add(current);

                            if (current.Row - 1 > -1                            // boundary check
                                && grid[current.Row - 1, current.Col] == 'L')   // top
                            {
                                queue.Enqueue((current.Row - 1, current.Col));
                            }

                            if (current.Col + 1 < grid.GetLength(1)     // boundary check
                                && grid[current.Row, current.Col + 1] == 'L')   // right
                            {
                                queue.Enqueue((current.Row, current.Col + 1));
                            }

                            if (current.Row + 1 < grid.GetLength(0)     // boundary check
                                && grid[current.Row + 1, current.Col] == 'L')   // bottom
                            {
                                queue.Enqueue((current.Row + 1, current.Col));
                            }

                            if (current.Col - 1 > -1                            // boundary check
                                && grid[current.Row, current.Col - 1] == 'L')   // left
                            {
                                queue.Enqueue((current.Row, current.Col - 1));
                            }
                        }

                        islands++;
                    }
                }
            }

            return islands;
        }

        /// <summary>
        /// r = number of rows
        /// c = number of columns
        /// Time: O(rc)
        /// Space: O(rc)
        /// </summary>
        public int IslandCountDepthFirst(char[,] grid)
        {
            var islandCount = 0;
            var visited = new HashSet<(int Row, int Col)>();

            for (var row = 0; row < grid.GetLength(0); row++)
            {
                for (var col = 0; col < grid.GetLength(1); col++)
                {
                    if (ExploreDepthFirst(grid, row, col, visited))
                    {
                        islandCount++;
                    }
                }
            }

            return islandCount;
        }

        /// <summary>
        /// Return true if an unvisited island traversal finished.
        /// </summary>
        private static bool ExploreDepthFirst(char[,] grid, int row, int col, ISet<(int Row, int Col)> visited)
        {
            if (row < 0 || row >= grid.GetLength(0)) return false;
            if (col < 0 || col >= grid.GetLength(1)) return false;

            if (grid[row, col] == 'W') return false;
            if (visited.Contains((row, col))) return false;

            visited.Add((row, col));

            ExploreDepthFirst(grid, row - 1, col, visited);
            ExploreDepthFirst(grid, row + 1, col, visited);
            ExploreDepthFirst(grid, row, col - 1, visited);
            ExploreDepthFirst(grid, row, col + 1, visited);

            return true;
        }
    }
}
