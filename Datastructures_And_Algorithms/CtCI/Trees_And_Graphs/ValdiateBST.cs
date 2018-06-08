using static Datastructures_And_Algorithms.CtCI.Trees_And_Graphs.ListOfDepths;

namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class ValdiateBST
    {
        public ValdiateBST()
        {
        }

        int? lastValue;
        public bool IsValidBST(TreeNode root)
        {
            // Do an inorder traversal and check if the sorted order is maintained
            if (root == null) return true;

            if (!IsValidBST(root.left)) return false;

            if (lastValue.HasValue && lastValue < root.val) return false;

            lastValue = root.val;

            if (!IsValidBST(root.right)) return false;

            return true;
        }
    }
}
