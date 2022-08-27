namespace GraphAlgorithms.Core
{
    public class Utility
    {
        /// <summary>
        /// Builds an adjacency list from the given edges.
        /// </summary>
        public static IReadOnlyDictionary<char, HashSet<char>> BuildGraph(List<List<char>> edges)
        {
            var graph = new Dictionary<char, HashSet<char>>();

            foreach (var edge in edges)
            {
                AddNode(graph, edge[0], edge[1]);
                AddNode(graph, edge[1], edge[0]);
            }

            return graph;
        }

        private static void AddNode(IDictionary<char, HashSet<char>> graph, char key, char nodeToAdd)
        {
            if (!graph.ContainsKey(key))
            {
                graph[key] = new HashSet<char>();
            }

            graph[key].Add(nodeToAdd);
        }
    }
}
