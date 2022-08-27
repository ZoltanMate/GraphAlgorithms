namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, HasPath, that takes in an object representing the adjacency list of a directed acyclic graph and two nodes (source, dest).
    /// The function should return a boolean indicating whether or not there exists a directed path between the source and destination nodes.
    /// </summary>
    public class HasPath
    {
        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public bool HasPathDepthFirst(IReadOnlyDictionary<char, List<char>> graph, char source, char dest)
        {
            if (source == dest)
            {
                return true;
            }

            foreach (var neighbor in graph[source])
            {
                if (HasPathDepthFirst(graph, neighbor, dest))
                {
                    return true;
                }
            }

            return false;

            // The whole method in one line:
            // return source == dest || graph[source].Any(neighbor => HasPath(graph, neighbor, dest));
        }

        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public bool HasPathBreadthFirst(IReadOnlyDictionary<char, List<char>> graph, char source, char dest)
        {
            var queue = new Queue<char>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (current == dest)
                {
                    return true;
                }

                foreach (var neighbor in graph[current])
                {
                    queue.Enqueue(neighbor);
                }
            }

            return false;
        }
    }
}
