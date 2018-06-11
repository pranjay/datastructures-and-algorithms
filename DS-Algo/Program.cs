using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Algo
{
    class Program
    {
        static void Main(string[] args)
        {
            var topSort = new TopologicalSort();

            var projects = new List<string> { "a", "b", "c", "d", "e", "f" };

            var dependencies = new List<Tuple<string, string>>();
            dependencies.Add(Tuple.Create("a", "d"));
            dependencies.Add(Tuple.Create("f", "b"));
            dependencies.Add(Tuple.Create("b", "d"));
            dependencies.Add(Tuple.Create("f", "a"));
            dependencies.Add(Tuple.Create("d", "c"));

            var buildOrder = topSort.BuildOrder(projects, dependencies);

            for (int i = 0; i < buildOrder.Count; i++)
            {
                Console.Write(buildOrder[i].Name + ", ");
            }

            foreach (var item in buildOrder)
            {
                Console.WriteLine(item.Name);

            }
            Console.ReadKey();
        }
    }
}
