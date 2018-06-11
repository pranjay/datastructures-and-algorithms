using System.Collections.Generic;

namespace DS_Algo
{
    public class Project
    {
        public enum State { Complete, Partial, Blank }
        public Project()
        {
            Children = new List<Project>();
            Map = new Dictionary<string, Project>();
        }
        public Project(string name) : this()
        {
            this.Name = name;
        }

        public List<Project> Children { get; private set; }
        public Dictionary<string, Project> Map { get; private set; }
        public string Name { get; private set; }
        public int Dependencies { get; set; }
        public State ProjectState { get; set; }

        public void AddNeighbor(Project project)
        {
            if (Map.ContainsKey(project.Name)) return;

            Children.Add(project);
            Map.Add(project.Name, project);
            project.Dependencies++;
        }
    }
}
