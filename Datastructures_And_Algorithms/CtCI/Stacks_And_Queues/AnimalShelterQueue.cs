namespace Datastructures_And_Algorithms.CtCI.Stacks_And_Queues
{
    public abstract class Animal
    {
        public string Name { get; private set; }
        public int Order { get; set; }

        protected Animal(string name)
        {
            Name = name;
        }

        public bool IsOlderThan(Animal a) { return Order < a.Order; }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
    }

    public class AnimalShelterQueue
    {

        private int order;
        public MyQueue<Dog> Dogs { get; set; }
        public MyQueue<Cat> Cats { get; set; }

        public void Add(Animal a)
        {
            a.Order = order;
            order++;

            if (a is Dog) Dogs.Add(a as Dog);
            if (a is Cat) Cats.Add(a as Cat);
        }

        public Dog DequeueDog() { return Dogs.Remove(); }

        public Cat DequeueCat() { return Cats.Remove(); }

        public Animal DequeueAny()
        {
            if (Dogs.IsEmpty()) return Cats.Remove();
            if (Cats.IsEmpty()) return Dogs.Remove();

            var dog = Dogs.Peek();
            var cat = Cats.Peek();

            if (dog.IsOlderThan(cat)) return DequeueDog();

            return DequeueCat();
        }
    }
}
