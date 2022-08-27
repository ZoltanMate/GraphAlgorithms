// The codes in this project are based on this course: https://www.youtube.com/watch?v=tWVWeAqZ0WU

#region Traversal Basics
// This is a directed graph with no cycle.
var traversalBasicsGraph = new Dictionary<char, List<char>>
{
    {'a', new List<char>{ 'b', 'c' }},
    {'b', new List<char>{ 'd' }},
    {'c', new List<char>{ 'e' }},
    {'d', new List<char>{ 'f' }},
    {'e', new List<char>()},
    {'f', new List<char>()}
};
var traversalBasics = new TraversalBasics();
Console.WriteLine($"{nameof(TraversalBasics)}:");

Console.WriteLine($"\t{nameof(traversalBasics.DepthFirstIterative)}: {traversalBasics.DepthFirstIterative(traversalBasicsGraph, 'a')}"); // acebdf ('abdfce' is a valid answer for depth first as well)

var stringBuilder = new StringBuilder();
traversalBasics.DepthFirstRecursive(traversalBasicsGraph, 'a', stringBuilder);
Console.WriteLine($"\t{nameof(traversalBasics.DepthFirstRecursive)}: {stringBuilder}"); // abdfce

Console.WriteLine($"\t{nameof(traversalBasics.BreadthFirstIterative)}: {traversalBasics.BreadthFirstIterative(traversalBasicsGraph, 'a')}"); // abcdef ('acbedf' is a valid answer for breadth first as well)

Console.WriteLine();
#endregion

#region Has Path
// This is a directed graph with no cycle.
var hasPathGraph = new Dictionary<char, List<char>>
{
    {'f', new List<char>{ 'g', 'i' }},
    {'g', new List<char>{ 'h' }},
    {'h', new List<char>()},
    {'i', new List<char>{ 'g', 'k' }},
    {'j', new List<char> { 'i' }},
    {'k', new List<char>()}
};
var hasPath = new HasPath();
Console.WriteLine($"{nameof(HasPath)}:");

Console.WriteLine($"\t{nameof(hasPath.HasPathDepthFirst)}: {hasPath.HasPathDepthFirst(hasPathGraph, 'f', 'k')}"); // true
Console.WriteLine($"\t{nameof(hasPath.HasPathBreadthFirst)}: {hasPath.HasPathBreadthFirst(hasPathGraph, 'f', 'k')}"); // true

Console.WriteLine();
#endregion

#region Undirected Path
// This is an undirected graph with multiple components
var undirectedPathEdges = new List<List<char>>
{
    new() { 'i', 'j' },
    new() { 'k', 'i' },
    new() { 'm', 'k' },
    new() { 'k', 'l' },
    new() { 'o', 'n' }
};
var undirectedPath = new UndirectedPath();
Console.WriteLine($"{nameof(UndirectedPath)}:");

Console.WriteLine($"\t{nameof(undirectedPath.UndirectedPathDepthFirst)}: {undirectedPath.UndirectedPathDepthFirst(undirectedPathEdges, 'j', 'm')}"); // true

Console.WriteLine();
#endregion

#region Connected Components Count
// This is an undirected graph with multiple components
var connectedComponentsCountGraph = new Dictionary<char, HashSet<char>>
{
    {'1', new HashSet<char>{ '2' }},
    {'2', new HashSet<char>{ '1' }},
    {'3', new HashSet<char>()},
    {'4', new HashSet<char>{ '6' }},
    {'5', new HashSet<char>{ '6' }},
    {'6', new HashSet<char> { '4', '5', '7', '8' }},
    {'7', new HashSet<char> { '6' }},
    {'8', new HashSet<char> { '6' }}
};
var connectedComponentsCount = new ConnectedComponentsCount();
Console.WriteLine($"{nameof(ConnectedComponentsCount)}:");

Console.WriteLine($"\t{nameof(connectedComponentsCount.ConnectedComponentsCountBreadthFirst)}: {connectedComponentsCount.ConnectedComponentsCountBreadthFirst(connectedComponentsCountGraph)}"); // 3
Console.WriteLine($"\t{nameof(connectedComponentsCount.ConnectedComponentsCountDepthFirstRecursive)}: {connectedComponentsCount.ConnectedComponentsCountDepthFirstRecursive(connectedComponentsCountGraph)}"); // 3

Console.WriteLine();
#endregion

#region Largest Component
// This is an undirected graph with multiple components
var largestComponentGraph = new Dictionary<char, HashSet<char>>
{
    {'0', new HashSet<char>{ '8', '1', '5' }},
    {'1', new HashSet<char>{ '0' }},
    {'5', new HashSet<char>{ '0', '8' }},
    {'8', new HashSet<char> { '0', '5' }},
    {'2', new HashSet<char>{ '3', '4' }},
    {'3', new HashSet<char>{ '2', '4' }},
    {'4', new HashSet<char>{ '3', '2' }}
};
var largestComponent = new LargestComponent();
Console.WriteLine($"{nameof(LargestComponent)}:");

Console.WriteLine($"\t{nameof(largestComponent.LargestComponentDepthFirst)}: {largestComponent.LargestComponentDepthFirst(largestComponentGraph)}"); // 4

Console.WriteLine();
#endregion

#region Shortest Path
// This is an undirected graph
var shortestPathEdges = new List<List<char>>
{
    new() { 'w', 'x' },
    new() { 'x', 'y' },
    new() { 'z', 'y' },
    new() { 'z', 'v' },
    new() { 'w', 'v' }
};
var shortestPath = new ShortestPath();
Console.WriteLine($"{nameof(ShortestPath)}:");

Console.WriteLine($"\t{nameof(shortestPath.ShortestPathBreadthFirst)}: {shortestPath.ShortestPathBreadthFirst(shortestPathEdges, 'w', 'z')}"); // 2

Console.WriteLine();
#endregion

#region Island Count
var islandCountGrid = new[,]
{
    {'W', 'L', 'W', 'W', 'W'},
    {'W', 'L', 'W', 'W', 'W'},
    {'W', 'W', 'W', 'L', 'W'},
    {'W', 'W', 'L', 'L', 'W'},
    {'L', 'W', 'W', 'L', 'L'},
    {'L', 'L', 'W', 'W', 'W'}
};
var islandCount = new IslandCount();
Console.WriteLine($"{nameof(IslandCount)}:");

Console.WriteLine($"\t{nameof(islandCount.IslandCountBreadthFirst)}: {islandCount.IslandCountBreadthFirst(islandCountGrid)}"); // 3
Console.WriteLine($"\t{nameof(islandCount.IslandCountDepthFirst)}: {islandCount.IslandCountDepthFirst(islandCountGrid)}"); // 3

Console.WriteLine();
#endregion

#region Minimum Island
var minimumIslandGrid = new[,]
{
    {'W', 'L', 'W', 'W', 'W'},
    {'W', 'L', 'W', 'W', 'W'},
    {'W', 'W', 'W', 'L', 'W'},
    {'W', 'W', 'L', 'L', 'W'},
    {'L', 'W', 'W', 'L', 'L'},
    {'L', 'L', 'W', 'W', 'W'}
};
var minimumIsland = new MinimumIsland();
Console.WriteLine($"{nameof(MinimumIsland)}:");

Console.WriteLine($"\t{nameof(minimumIsland.MinimumIslandDepthFirst)}: {minimumIsland.MinimumIslandDepthFirst(minimumIslandGrid)}"); // 2

#endregion