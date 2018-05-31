using System;
namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class QueueWithStacks
    {
        readonly MyStack<int> newestStack;
        readonly MyStack<int> oldestStack;

        public QueueWithStacks()
        {
            oldestStack = new MyStack<int>();
            newestStack = new MyStack<int>();
        }

        public void Push(int item)
        {
            newestStack.Push(item);
        }

        public int Pop()
        {
            ShiftStacks();
            return oldestStack.Pop();
        }

        public int Peek()
        {
            ShiftStacks();
            return oldestStack.Peek();
        }

        void ShiftStacks()
        {
            if (oldestStack.IsEmpty())
            {
                while (!newestStack.IsEmpty())
                {
                    oldestStack.Push(newestStack.Pop());
                }
            }
        }
    }
}
