using System;
namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class QueueNode<T>
    {
        public T Data { get; private set; }
        public QueueNode<T> Next { get; set; }

        public QueueNode(T data)
        {
            this.Data = data;
        }
    }

    public class MyQueue<T>
    {
        public QueueNode<T> First { get; private set; }
        public QueueNode<T> Last { get; private set; }

        public void Add(T item)
        {
            var node = new QueueNode<T>(item);

            if (Last != null) Last.Next = node;
            Last = node;

            if (First == null) First = Last;
        }

        public T Remove()
        {
            if (IsEmpty()) throw new Exception("Queue is empty.");
            var value = First.Data;
            First = First.Next;

            if (First == null) Last = null;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty()) throw new Exception("Queue is empty.");
            return First.Data;
        }

        public bool IsEmpty() { return First == null; }

        internal void Run()
        {
            var q = new MyQueue<string>();

            q.Add("item one");
            q.Add("item two");
            q.Add("item three");
            q.Add("item four");

            var peek = q.Peek();
            Console.WriteLine($"peek={peek}");

            var remove = q.Remove();
            Console.WriteLine($"remove={remove}");

            remove = q.Remove();
            Console.WriteLine($"remove={remove}");

            remove = q.Remove();
            Console.WriteLine($"remove={remove}");

            remove = q.Remove();
            Console.WriteLine($"remove={remove}");

            Console.WriteLine();
        }
    }
}