namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, LargestComponent, that takes in the adjacency list of an undirected graph.
    /// The function should return the size of the largest connected component in the graph.
    /// </summary>
    public class LargestComponent
    {
        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public int LargestComponentDepthFirst(IDictionary<char, HashSet<char>> graph)
        {
            var largest = int.MinValue;
            var visited = new HashSet<char>();

            foreach (var node in graph)
            {
                var size = ExploreSizeDepthFirst(graph, node.Key, visited);

                if (size > largest)
                {
                    largest = size;
                }
            }

            return largest;

            // The whole method in 2 lines:
            // var visited = new HashSet<char>();
            // return graph.Select(node => ExploreSizeDepthFirst(graph, node.Row, visited)).Prepend(int.MinValue).Max();
        }

        /// <summary>
        /// Returns the size of an unvisited component
        /// </summary>
        private static int ExploreSizeDepthFirst(IDictionary<char, HashSet<char>> graph, char current, ISet<char> visited)
        {
            if (visited.Contains(current))
            {
                return 0;
            }

            visited.Add(current);

            var size = 1;
            foreach (var neighbor in graph[current])
            {
                size += ExploreSizeDepthFirst(graph, neighbor, visited);
            }

            return size;

            // The whole method in 3 lines:
            // if (visited.Contains(current)) return 0;
            // visited.Add(current);
            // return 1 + graph[current].Sum(neighbor => ExploreDepthFirstInt(graph, neighbor, visited));
        }
    }
}
