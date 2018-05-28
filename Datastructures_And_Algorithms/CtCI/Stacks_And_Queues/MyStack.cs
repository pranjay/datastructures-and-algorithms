﻿using System;
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

        public void Add(T item)
        {
            var node = new StackNode<T>(item);
            node.Next = Top;
            Top = node;
        }

        public T Remove()
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

        public void Run()
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
