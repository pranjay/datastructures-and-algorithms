using System;
using System.Collections.Generic;

namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class Node
    {
        public string Name { get; set; }
        public List<Node> Children { get; set; }
        public NodeState NodeState { get; set; }

        public Node(string name)
        {
            Name = name;
        }
    }

    public enum NodeState { Visited, Visiting, Unvisited }

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
                var node = new Node(i.ToString()) { NodeState = NodeState.Unvisited };
                g.Nodes.Add(node);

                for (int j = 0; j < 10; j++)
                {
                    g.Nodes[i].Children = new List<Node>();
                    g.Nodes[i].Children = new List<Node> { new Node(j.ToString()) { NodeState = NodeState.Unvisited } };
                }
            }

            //var hasPath = Search_Dfs(g, g.Nodes[0], g.Nodes[4]);
            //Console.WriteLine($"hasPath DFS={hasPath}");

            var hasPath = Search_Bfs(g, g.Nodes[0], g.Nodes[8]);
            Console.WriteLine($"hasPath BFS={hasPath}");
        }


        public bool Search_Bfs(Graph g, Node root, Node toSearch)
        {
            if (root == null) return root == toSearch;

            var q = new Queue<Node>();
            q.Enqueue(root);
            root.NodeState = NodeState.Visiting;

            while (q.Count > 0)
            {
                var node = q.Dequeue();
                if (node == null) continue;

                if (node.Children == null || node.Children.Count == 0) continue;

                foreach (var n in node.Children)
                {
                    if (n.NodeState == NodeState.Visited) continue;
                    if (n == toSearch) return true;

                    n.NodeState = NodeState.Visiting;
                    q.Enqueue(n);
                }

                node.NodeState = NodeState.Visited;
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
