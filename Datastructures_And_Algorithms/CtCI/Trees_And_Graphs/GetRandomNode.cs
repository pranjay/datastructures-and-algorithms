using System;
namespace Datastructures_And_Algorithms.CtCI.Trees_And_Graphs
{
    public class GetRandomNode
    {
        private class Tree
        {
            CustomTreeNode root;

            public int Size { get => root == null ? 0 : root.Size; }

            public CustomTreeNode GetRandomNode()
            {
                if (root == null) return null;

                var random = new Random();
                int index = random.Next(Size);

                return root.GetIthNode(index);
            }

            public void InsertInOrder(int data)
            {
                if (root == null) root = new CustomTreeNode(data);
                else root.InsertInOrder(data);

            }
        }

        private class CustomTreeNode
        {
            public int Data { get; set; }
            public CustomTreeNode Left { get; set; }
            public CustomTreeNode Right { get; set; }

            public int Size { get; private set; }

            public CustomTreeNode(int data)
            {
                Data = data;
                Size = 1;
            }

            public CustomTreeNode GetRandomNode()
            {
                var leftSize = Left == null ? 0 : Left.Size;
                var random = new Random();
                var index = random.Next(Size);

                if (index < leftSize) return Left.GetRandomNode();
                if (index == leftSize) return this;
                else return Right.GetRandomNode();
            }

            public void InsertInOrder(int data)
            {
                var treeNode = new CustomTreeNode(data);

                // val to be created is less than current value
                // traverse left
                if (data <= Data)
                {
                    // traverse left
                    if (Left == null) Left = new CustomTreeNode(data);
                    else Left.InsertInOrder(data);
                }
                else
                {
                    // traverse right
                    if (Right == null) Right = new CustomTreeNode(data);
                    else Right.InsertInOrder(data);
                }

                // increase size either way
                Size++;
            }

            public CustomTreeNode Find(int value)
            {
                if (value == Data) return this;

                if (value < Data) return Left == null ? null : Left.Find(value);
                else if (value > Data) return Right == null ? null : Right.Find(value);

                return null;
            }

            public CustomTreeNode GetIthNode(int index)
            {
                var leftSize = Left == null ? 0 : Left.Size;

                if (index == leftSize) return this;

                if (index <= leftSize) return Left.GetIthNode(index);

                return Right.GetIthNode(index - (leftSize + 1));
            }
        }
    }
}
