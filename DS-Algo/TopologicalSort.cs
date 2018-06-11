using System;
using System.Collections.Generic;

namespace DS_Algo
{
    public class TopologicalSort
    {
        public List<Project> BuildOrder(List<string> projects, List<Tuple<string, string>> dependencies)
        {
            Graph graph = BuildGraph(projects, dependencies);
            return OrderProjects(graph.Nodes);
        }

        private List<Project> OrderProjects(List<Project> projects)
        {
            var buildOrder = new List<Project>();

            // Add the projects with no dependency (in degree == 0)
            int endOfList = AddIndenpendent(buildOrder, projects, 0);
            int tobeProcessed = 0;

            while (tobeProcessed < buildOrder.Count)
            {
                var currentProject = buildOrder[tobeProcessed];

                // If the current project is null, we have a circular dependency
                // We cannot build the system
                if (currentProject == null) return null;

                foreach (var child in currentProject.Children)
                {
                    // Decrement dependency
                    child.Dependencies--;
                }

                // Add children that have no one depending on them
                endOfList = AddIndenpendent(buildOrder, currentProject.Children, endOfList);
                tobeProcessed++;
            }

            return buildOrder;
        }

        /// <summary>
        /// Adds the indenpendent projects.
        /// </summary>
        /// <param name="buildOrder">The build order.</param>
        /// <param name="projects">The projects.</param>
        /// <param name="offset">The offset.</param>
        /// <returns></returns>
        private int AddIndenpendent(List<Project> buildOrder, List<Project> projects, int offset)
        {
            foreach (var project in projects)
            {
                if (project.Dependencies > 0) continue;

                buildOrder.Add(project);
                offset++;
            }

            return offset;
        }

        public Graph BuildGraph(List<string> projects, List<Tuple<string, string>> dependencies)
        {
            var graph = new Graph();

            // Add Nodes
            foreach (var project in projects)
            {
                graph.GetOrCreateNode(project);
            }

            // Add Edges
            foreach (var dependecy in dependencies)
            {
                graph.AddEdge(dependecy.Item1, dependecy.Item2);
            }

            return graph;
        }
    }
}
