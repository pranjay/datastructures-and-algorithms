using System.Collections.Generic;

namespace DS_Algo
{
    public class Project
    {
        public List<Project> Children { get; private set; }
        public Dictionary<string, Project> Map { get; private set; }
        public string Name { get; private set; }
        public int Dependencies { get; private set; }

        public Project(string name)
        {
            this.Name = name;
        }

        public void AddNeighbor(Project project)
        {
            if (Map.ContainsKey(project.Name)) return;

            Children.Add(project);
            Map.Add(project.Name, project);
            Dependencies++;
        }
    }
}
