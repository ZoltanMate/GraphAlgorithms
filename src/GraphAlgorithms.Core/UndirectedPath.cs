namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, UndirectedGraph, that takes in an array of edges for an undirected graph
    /// and two nodes (source, dest). The function should return a boolean indicating whether or not
    /// there exists a path between source and dest.
    /// </summary>
    public class UndirectedPath
    {
        public bool UndirectedPathDepthFirst(List<List<char>> edges, char source, char dest)
        {
            var graph = Utility.BuildGraph(edges);
            return HasPathDepthFirstVisited(graph, source, dest, new HashSet<char>());
        }

        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        private static bool HasPathDepthFirstVisited(IReadOnlyDictionary<char, HashSet<char>> graph, char source, char dest, ISet<char> visited)
        {
            if (visited.Contains(source))
            {
                return false;
            }

            if (source == dest)
            {
                return true;
            }

            visited.Add(source);

            return graph[source].Any(neighbor => HasPathDepthFirstVisited(graph, neighbor, dest, visited));
        }
    }
}
