using System;
using System.Collections.Generic;

namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class ListOfDepths
    {

        public class TreeNode
        {
            public int val { get; private set; }
            public TreeNode left { get; set; }
            public TreeNode right { get; set; }
        }

        public void Run()
        {

        }

        public List<LinkedList<TreeNode>> CreateLinkedLists_Bfs(TreeNode root)
        {
            if (root == null) return new List<LinkedList<TreeNode>>();

            var results = new List<LinkedList<TreeNode>>();

            var q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var qCount = 0;
                var subList = new LinkedList<TreeNode>();

                for (int i = 0; i < qCount; ++i)
                {
                    var node = q.Dequeue();
                    subList.AddFirst(node);

                    if (node.left != null) q.Enqueue(node.left);
                    if (node.right != null) q.Enqueue(node.right);
                }

                results.Add(subList);
            }

            return results;
        }

        public List<LinkedList<TreeNode>> CreateLinkedLists_PreOrder(TreeNode root)
        {
            var results = new List<LinkedList<TreeNode>>();
            CreateListsByLevel(root, results, 0);
            return results;
        }

        private void CreateListsByLevel(TreeNode root, List<LinkedList<TreeNode>> results, int level)
        {
            if (root == null) return;

            LinkedList<TreeNode> list = null;
            if (results.Count == level) list = results[level];
            else list = new LinkedList<TreeNode>();

            list.AddFirst(root);

            CreateListsByLevel(root.left, results, level + 1);
            CreateListsByLevel(root.right, results, level + 1);
        }


    }
}
