namespace GraphAlgorithms.Core
{
    public class TraversalBasics
    {
        /// <summary>
        /// Uses Stack. This method cannot handle cycles in graph.
        /// </summary>
        /// <param name="graph">The graph to travel</param>
        /// <param name="source">The initial node in the graph where to start the traversal</param>
        /// <returns>The nodes in order</returns>
        public string DepthFirstIterative(IReadOnlyDictionary<char, List<char>> graph, char source)
        {
            var result = new StringBuilder();
            var stack = new Stack<char>();
            stack.Push(source);

            while (stack.Any())
            {
                var current = stack.Pop();
                result.Append(current);

                graph[current].ForEach(neighbor => stack.Push(neighbor));
            }

            return result.ToString();
        }

        /// <summary>
        /// Uses Stack. This method cannot handle cycles in graph.
        /// </summary>
        /// <param name="graph">The graph to travel</param>
        /// <param name="source">The initial node in the graph where to start the traversal</param>
        /// <param name="result">Helper StringBuilder to print out the nodes in order.</param>
        /// <returns>The nodes in order</returns>
        public void DepthFirstRecursive(IReadOnlyDictionary<char, List<char>> graph, char source, StringBuilder result)
        {
            result.Append(source);
            foreach (var neighbor in graph[source])
            {
                DepthFirstRecursive(graph, neighbor, result);
            }
        }

        /// <summary>
        /// Uses Queue. There is no recursive Breadth First algorithms because it uses Queue. This method cannot handle cycles in graph.
        /// </summary>
        /// <param name="graph">The graph to travel</param>
        /// <param name="source">The initial node in the graph where to start the traversal</param>
        /// <returns>The nodes in order</returns>
        public string BreadthFirstIterative(IReadOnlyDictionary<char, List<char>> graph, char source)
        {
            var result = new StringBuilder();
            var queue = new Queue<char>();
            queue.Enqueue(source);

            while (queue.Any())
            {
                var current = queue.Dequeue();
                result.Append(current);

                foreach (var neighbor in graph[current])
                {
                    queue.Enqueue(neighbor);
                }
            }

            return result.ToString();
        }
    }
}
