namespace largest_component
{
    public class Program
    {
        public static int largestComponent(Dictionary<int, List<int>> graph)
        {
            int count = 0;
            HashSet<int> visited = new HashSet<int>();
            int maxSize = 0;

            foreach (int node in graph.Keys) 
            {
                int size = traverse(graph,node,visited); // returns the size of the component the current node is a part of
                if (size > maxSize) 
                { 
                    maxSize = size;
                }
            }

            return maxSize;



        }

        // recursive depth first search
        public static int traverseSize(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
        {
            if (visited.Contains(node)) 
            {
                return 0;
            }
            visited.Add(node);
            int totalSize = 1; // start at 1 because we already have the initial node
            List<int> neighbours = graph.GetValueOrDefault(node); // getting neighbours for the node
            
            foreach(int neighbour in neighbours)
            {
               totalSize += traverseSize(graph,neighbour,visited); 
            }

            return totalSize;

        }

        // iterative depth first search
        public static int traverse(Dictionary<int, List<int>> graph, int node, HashSet<int> visited)
        {
            if (visited.Contains(node)) 
            {
                return 0;
            }
            
            Stack<int> stack = new Stack<int>();
            stack.Push(node);
            visited.Add(node);
            int totalSize = 1;
            while (stack.Count != 0) 
            { 
                var currentNode = stack.Pop();
                
                foreach(int neighbour in graph.GetValueOrDefault(currentNode))
                {
                    if (!visited.Contains(neighbour))
                    {
                        stack.Push(neighbour);
                        visited.Add(neighbour);
                        totalSize++;
                    }
                    
                }
            
            }

            return totalSize;
        }

        public static void Main(string[] args)
        {
            Dictionary<int, List<int>> graph = new Dictionary<int, List<int>> {
                {0,new List<int>{8,1,5} },
                {1,new List<int>{0} },
                {5,new List<int>{0,8} },
                {8,new List<int>{0, 5} },
                {2,new List<int>{3, 4} },
                {3,new List<int>{2, 4} },
                {4,new List<int>{3,2} }


            };

            Console.WriteLine(largestComponent(graph));
        }
    }
}
