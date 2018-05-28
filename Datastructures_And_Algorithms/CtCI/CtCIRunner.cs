using System;
using Datastructures_And_Algorithms.CtCI.Stacks_And_Queues;

namespace Datastructures_And_Algorithms.CtCI
{
    public static class CtCIRunner
    {
        public static void Run()
        {
            var myStack = new MyStack<string>();

            myStack.Add("item one");
            myStack.Add("item two");
            myStack.Add("item three");
            myStack.Add("item four");

            var peek = myStack.Peek();
            Console.WriteLine($"peek={peek}");

            var remove = myStack.Remove();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Remove();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Remove();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Remove();
            Console.WriteLine($"remove={remove}");
        }
    }
}
