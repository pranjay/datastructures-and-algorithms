using System;

namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class StackNodeWithMin
    {
        public int Value { get; set; }
        public int Min { get; set; }

        public StackNodeWithMin(int value, int min)
        {
            Value = value;
            Min = min;
        }
    }

    public class MinStack : MyStack<StackNodeWithMin>
    {
        public void Push(int data)
        {
            var newMin = Math.Min(data, Min());
            var node = new StackNodeWithMin(data, newMin);
            base.Push(node);
        }

        public int Min()
        {
            if (IsEmpty()) return int.MaxValue;
            return Peek().Min;
        }

        new public void Run()
        {
            var s = new MinStack();

            s.Push(5);
            var min = s.Min();
            Console.WriteLine($"min={min}");

            s.Push(4);
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Push(3);
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Pop();
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Pop();
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Clear();
            Console.WriteLine($"Stack is empty: {s.IsEmpty()}");

        }
    }

    // With two Stacks; one keeping track of mins

    public class MinStackWithTwoStacks : MyStack<int>
    {
        MyStack<int> minStack = new MyStack<int>();

        new public void Push(int value)
        {
            if (value < Min()) minStack.Push(value);
            base.Push(value);
        }

        new public int Pop()
        {
            var node = base.Pop();
            if (node == Min()) minStack.Pop();
            return node;
        }

        public int Min()
        {
            if (IsEmpty()) return int.MaxValue;
            return minStack.Peek();
        }

        new public void Run()
        {
            var s = new MinStack();

            s.Push(5);
            var min = s.Min();
            Console.WriteLine($"min={min}");

            s.Push(4);
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Push(3);
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Pop();
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Pop();
            min = s.Min();
            Console.WriteLine($"min={min}");

            s.Clear();
            Console.WriteLine($"Stack is empty: {s.IsEmpty()}");
        }
    }
}
