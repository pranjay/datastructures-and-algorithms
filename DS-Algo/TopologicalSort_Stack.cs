using System;
using System.Collections.Generic;
using static DS_Algo.Project;

namespace DS_Algo
{
    public class TopologicalSort_Stack
    {
        public Stack<Project> BuildOrder(List<string> projects, List<Tuple<string, string>> dependencies)
        {
            var topSort = new TopologicalSort();
            var graph = topSort.BuildGraph(projects, dependencies);
            return OrderProjects(graph.Nodes);
        }

        private Stack<Project> OrderProjects(List<Project> projects)
        {
            var stack = new Stack<Project>();

            foreach (var project in projects)
            {
                if (project.ProjectState == State.Blank)
                {
                    if (!DoDfs(project, stack)) return null;
                }
            }

            return stack;
        }

        private bool DoDfs(Project project, Stack<Project> stack)
        {
            if (project.ProjectState == State.Partial) return false; // Cycle

            if (project.ProjectState == State.Blank)
            {
                project.ProjectState = State.Partial;

                foreach (var child in project.Children)
                {
                    if (!DoDfs(child, stack)) return false;
                }

                stack.Push(project);
                project.ProjectState = State.Complete;
            }

            return true;
        }
    }
}
