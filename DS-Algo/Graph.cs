using System.Collections.Generic;

namespace DS_Algo
{
    public class Graph
    {
        public List<Project> Nodes { get; private set; }
        public Dictionary<string, Project> Map { get; private set; }

        public Project GetOrCreateNode(string name)
        {
            if (!Map.ContainsKey(name))
            {
                var project = new Project(name);
                Nodes.Add(project);
                Map.Add(name, project);
            }

            return Map[name];
        }

        public void AddEdge(string startName, string endName)
        {
            var startVertex = GetOrCreateNode(startName);
            var endVertex = GetOrCreateNode(endName);

            startVertex.AddNeighbor(endVertex);
        }
    }
}
