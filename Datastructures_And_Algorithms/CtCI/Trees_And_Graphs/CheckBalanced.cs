using System;
using static Datastructures_And_Algorithms.CtCI.Trees_And_Graphs.ListOfDepths;

namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class CheckBalanced
    {

        public bool IsBalanced_Better(TreeNode root)
        {
            return CheckHeight(root) != int.MinValue;
        }

        public int CheckHeight(TreeNode root)
        {
            if (root == null) return -1;

            var leftHeight = CheckHeight(root.left);
            if (leftHeight == int.MinValue) return int.MinValue;

            var rightHeight = CheckHeight(root.right);
            if (rightHeight == int.MinValue) return int.MinValue;

            if (Math.Abs(leftHeight - rightHeight) > 1) return int.MinValue;
            return Math.Max(leftHeight, rightHeight) + 1;
        }

        public bool IsBalanced_Simple(TreeNode root)
        {
            if (root == null) return true;

            var heightDiff = GetHeight(root.left) - GetHeight(root.right);

            if (Math.Abs(heightDiff) > 1) return false;

            return IsBalanced_Simple(root.left) && IsBalanced_Simple(root.right);

        }

        int GetHeight(TreeNode root)
        {
            if (root == null) return -1;

            return Math.Max(GetHeight(root.left), GetHeight(root.right)) + 1;
        }
    }
}
