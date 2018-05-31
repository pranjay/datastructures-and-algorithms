using System;
using System.Collections.Generic;

namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public class StackSet<T>
    {
        public List<MyStack<T>> Stacks { get; private set; }
    }

    public class SetOfStacks<T>
    {
        readonly int maxCapacity;
        int maxStacks = 3;
        readonly T[][] values;
        readonly int[] sizes;
        int currentStackId;

        public SetOfStacks(int threshold)
        {
            values = new T[maxStacks][];
            values[0] = new T[threshold];
            sizes = new int[maxStacks];
            maxCapacity = threshold;
        }

        public void Push(T item)
        {
            Push(currentStackId, item);
        }

        private void Push(int stackId, T item)
        {
            if (IsFull(stackId)) throw new Exception($"Stack number {stackId} is full. Cannot push.");

            sizes[currentStackId]++;
            values[currentStackId][IndexOfTop(currentStackId)] = item;

            if (sizes[currentStackId] == maxCapacity) InitNewStack();
        }

        void InitNewStack()
        {
            currentStackId = currentStackId + 1;
            values[currentStackId] = new T[maxCapacity];
        }

        public T Pop()
        {
            return Pop(currentStackId);
        }

        T Pop(int stackId)
        {
            if (IsEmpty(stackId)) throw new Exception("Stack is empty. Nothing to Pop.");

            var topIndex = IndexOfTop(stackId);
            var value = values[stackId][topIndex];

            values[stackId][topIndex] = default(T);
            sizes[stackId]--;

            if (sizes[stackId] == 0)
            {
                //values[currentStackId] = null;
                if (currentStackId > 0) currentStackId--;
            }

            return value;
        }

        bool IsEmpty(int stackIndex)
        {
            return sizes[stackIndex] == 0;
        }

        int IndexOfTop(int stackIndex)
        {
            var topIndex = maxCapacity - sizes[stackIndex];
            return topIndex;
        }

        bool IsFull(int stackIndex)
        {
            return sizes[stackIndex] == maxCapacity;
        }

        public void Run()
        {
            var ss = new SetOfStacks<int>(3);

            for (int i = 1; i < maxStacks * maxCapacity; i++)
            {
                ss.Push(i);
            }

            var pop = 0;

            for (int i = 1; i < maxStacks * maxCapacity; i++)
            {
                pop = ss.Pop();
                Console.WriteLine($"pop={pop}");
            }

            for (int i = 1; i < maxStacks * maxCapacity; i++)
            {
                ss.Push(i);
            }

            pop = ss.Pop(1);
            Console.WriteLine($"pop={pop} at 1");
        }
    }
}
