namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, ConnectedComponentsCount, that takes in the adjacency list of an undirected graph.
    /// The function should return the number of connected components within the graph.
    /// </summary>
    public class ConnectedComponentsCount
    {
        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public int ConnectedComponentsCountBreadthFirst(IDictionary<char, HashSet<char>> graph)
        {
            var count = 0;
            var visited = new HashSet<char>();

            foreach (var node in graph)
            {
                if (visited.Contains(node.Key))
                {
                    continue;
                }

                var queue = new Queue<char>();
                queue.Enqueue(node.Key);
                while (queue.Any())
                {
                    var current = queue.Dequeue();
                    visited.Add(current);

                    foreach (var neighbor in graph[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            queue.Enqueue(neighbor);
                        }
                    }
                }

                count++;
            }

            return count;
        }

        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public int ConnectedComponentsCountDepthFirstRecursive(IDictionary<char, HashSet<char>> graph)
        {
            var count = 0;
            var visited = new HashSet<char>();

            foreach (var node in graph)
            {
                if (ExploreDepthFirst(graph, node.Key, visited))
                {
                    count++;
                }
            }

            return count;

            // The whole method in 2 lines:
            // var visited = new HashSet<char>();
            // return graph.Count(node => ExploreDepthFirstBool(graph, node.Row, visited));
        }

        /// <summary>
        /// Returns true when found an unvisited node and finished the traversal.
        /// </summary>
        private static bool ExploreDepthFirst(IDictionary<char, HashSet<char>> graph, char current, ISet<char> visited)
        {
            if (visited.Contains(current))
            {
                return false;
            }

            visited.Add(current);

            var node = graph[current];

            foreach (var neighbor in node)
            {
                ExploreDepthFirst(graph, neighbor, visited);
            }

            return true;
        }
    }
}
