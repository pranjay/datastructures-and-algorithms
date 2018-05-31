using System;
namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class SortedStack
    {
        private MyStack<int> bufferStack, sortedStack;

        public SortedStack()
        {
            bufferStack = new MyStack<int>();
            sortedStack = new MyStack<int>();
        }

        public void Push(int item)
        {
            if (!sortedStack.IsEmpty() && item > sortedStack.Peek())
            {
                while (!sortedStack.IsEmpty() && item >= sortedStack.Peek())
                {
                    bufferStack.Push(sortedStack.Pop());
                }

                sortedStack.Push(item);

                while (!bufferStack.IsEmpty())
                {
                    sortedStack.Push(bufferStack.Pop());
                }
            }
            else
            {
                sortedStack.Push(item);
            }
        }

        public int Pop() { return sortedStack.Pop(); }

        public int Peek() { return sortedStack.Peek(); }

        public bool IsEmpty() { return sortedStack.IsEmpty(); }

        public void Run()
        {
            var ss = new SortedStack();

            for (int i = 0; i < 5; i++)
            {
                ss.Push(i);
            }

            while (!ss.IsEmpty()) { Console.WriteLine($"Popped item: { ss.Pop() }"); }
        }
    }
}
