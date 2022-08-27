namespace GraphAlgorithms.Core
{
    /// <summary>
    /// Write a function, ShortestPath, that takes in an array of edges for an undirected graph and
    /// two nodes (source, dest). The function should return the length of the shortest path between
    /// source and dest. Consider the length as the number of edges in the path, not the number of nodes.
    /// If there is no path between source and dest, then return -1.
    /// </summary>
    public class ShortestPath
    {
        /// <summary>
        /// n = number of nodes
        /// e = number of edges
        /// Time: O(e)
        /// Space: O(n)
        /// </summary>
        public int ShortestPathBreadthFirst(List<List<char>> edges, char source, char dest)
        {
            if (source == dest)
            {
                return 0;
            }

            var graph = Utility.BuildGraph(edges);

            var visited = new HashSet<char>();
            var queue = new Queue<Tuple<char, int>>();
            queue.Enqueue(new Tuple<char, int>(source, 0));

            while (queue.Any())
            {
                var (current, distance) = queue.Dequeue();

                if (current == dest)
                {
                    return distance;
                }

                if (visited.Contains(current))
                {
                    continue;
                }

                visited.Add(current);

                foreach (var neighbor in graph[current])
                {
                    queue.Enqueue(new Tuple<char, int>(neighbor, distance + 1));
                }
            }

            return -1;
        }
    }
}
