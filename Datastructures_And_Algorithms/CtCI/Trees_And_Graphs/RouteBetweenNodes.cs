using System;
using System.Collections.Generic;

namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; }

        public Node(string name)
        {
            Name = name;
        }
    }

    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph()
        {
            this.Nodes = new List<Node>();
        }
    }

    public class RouteBetweenNodes
    {
        public void Run()
        {
            var g = new Graph();

            for (int i = 0; i < 10; i++)
            {
                g.Nodes.Add(new Node(i.ToString()));
            }

            //var hasPath = Search_Dfs(g, g.Nodes[0], g.Nodes[4]);
            //Console.WriteLine($"hasPath DFS={hasPath}");

            var hasPath = Search_Bfs(g, g.Nodes[0], g.Nodes[4]);
            Console.WriteLine($"hasPath BFS={hasPath}");
        }

        public bool Search_Bfs(Graph g, Node root, Node toSearch)
        {
            if (root == null) return root == toSearch;
            var q = new Queue<Node>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node.Name == toSearch.Name) return true;

                if (node.Children != null && node.Children.Count > 0)
                {
                    foreach (var n in node.Children) { q.Enqueue(n); }
                }
            }

            return false;
        }

        public bool Search_Dfs(Graph g, Node root, Node toSearch)
        {
            if (root == null) return root == toSearch;
            if (root.Name == toSearch.Name) return true;

            foreach (var n in root.Children)
            {
                return Search_Dfs(g, root, n);
            }

            return false;
        }
    }
}
