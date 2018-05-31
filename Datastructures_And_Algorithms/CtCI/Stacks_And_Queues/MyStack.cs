using System;
namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class StackNode<T>
    {
        public T Data { get; set; }
        public StackNode<T> Next { get; set; }

        public StackNode(T data)
        {
            Data = data;
        }
    }

    public class MyStack<T>
    {
        public StackNode<T> Top { get; set; }
        public int Capacity { get; private set; }

        public void Push(T item)
        {
            var node = new StackNode<T>(item);
            node.Next = Top;
            Top = node;
        }

        public T Pop()
        {
            if (Top == null) throw new Exception("Stack is empty.");
            T value = Top.Data;
            Top = Top.Next;
            return value;
        }

        public T Peek()
        {
            if (Top == null) throw new Exception("Stack is empty.");
            return Top.Data;
        }

        public void Clear()
        {
            while (!IsEmpty()) { Pop(); }
        }

        public bool IsEmpty() { return Top == null; }

        public void Run()
        {
            var myStack = new MyStack<string>();

            myStack.Push("item one");
            myStack.Push("item two");
            myStack.Push("item three");
            myStack.Push("item four");

            var peek = myStack.Peek();
            Console.WriteLine($"peek={peek}");

            var remove = myStack.Pop();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Pop();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Pop();
            Console.WriteLine($"remove={remove}");

            remove = myStack.Pop();
            Console.WriteLine($"remove={remove}");
        }
    }
}
