using System;
namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class ThreeInOne
    {

        public void Run()
        {
            var fixedMultiStack = new FixedMultiStack<string>(3);

            // Stack one operations
            fixedMultiStack.Add(1, "item 1.1");
            fixedMultiStack.Add(1, "item 1.2");
            fixedMultiStack.Add(1, "item 1.3");

            // Stack two operations
            fixedMultiStack.Add(2, "item 2.1");
            fixedMultiStack.Add(2, "item 2.2");
            fixedMultiStack.Add(2, "item 2.3");

            // Stack three operations
            fixedMultiStack.Add(3, "item 3.1");
            fixedMultiStack.Add(3, "item 3.2");
            fixedMultiStack.Add(3, "item 3.3");

            // Stack one operations
            var remove = fixedMultiStack.Remove(1);
            Console.WriteLine($"remove={remove}");

            remove = fixedMultiStack.Remove(1);
            Console.WriteLine($"remove={remove}");

            remove = fixedMultiStack.Remove(1);
            Console.WriteLine($"remove={remove}");

        }
    }

    public class FixedMultiStack<T>
    {
        const int numberOfStacks = 3;
        int stackCapacity;

        T[] values;
        int[] sizes;

        public FixedMultiStack(int capacity)
        {
            stackCapacity = capacity;
            values = new T[numberOfStacks * stackCapacity];
            sizes = new int[numberOfStacks];
        }

        public void Add(int stackNumber, T item)
        {
            if (IsStackFull(stackNumber)) throw new Exception($"Stack number: {stackNumber} is at capacity.");

            sizes[stackNumber - 1]++;
            values[IndexOfTop(stackNumber)] = item;
        }

        public T Remove(int stackNumber)
        {
            if (IsEmpty(stackNumber)) throw new Exception($"Stack number: {stackNumber} is empty.");

            var topIndex = IndexOfTop(stackNumber);
            var value = values[topIndex];

            values[topIndex] = default(T); // Clear values
            sizes[stackNumber - 1]--; //Shrink

            return value;
        }

        public T Peek(int stackNumber)
        {
            if (IsEmpty(stackNumber)) throw new Exception($"Stack number {stackNumber} is empty.");

            return values[IndexOfTop(stackNumber)];
        }

        bool IsEmpty(int stackNumber)
        {
            return sizes[stackNumber - 1] == 0;
        }

        int IndexOfTop(int stackNumber)
        {
            var offset = stackNumber * stackCapacity;
            var size = sizes[stackNumber - 1];
            return offset - size;
        }

        bool IsStackFull(int stackNumber)
        {
            return sizes[stackNumber - 1] == stackCapacity;
        }
    }
}
