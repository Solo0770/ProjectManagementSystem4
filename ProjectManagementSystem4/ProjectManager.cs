using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem4
{
    public class ProjectManager
    {
        private readonly Dictionary<string, Project> projects = new();

        public void AddProject(Project project)
        {
            if (projects.ContainsKey(project.Name))
                throw new ArgumentException("Project with the same name already exists.");
            projects[project.Name] = project;
        }

        public void AddTask(string projectName, Task task)
        {
            if (!projects.ContainsKey(projectName))
                throw new KeyNotFoundException($"Project '{projectName}' not found.");

            if (task == null)
                throw new ArgumentNullException(nameof(task), "Task cannot be null.");

            if (string.IsNullOrWhiteSpace(task.TaskName))
                throw new ArgumentException("Task name cannot be empty or whitespace.");

            var project = projects[projectName];
            if (project.Tasks.Exists(t => t.TaskName == task.TaskName))
                throw new ArgumentException($"Task with the name '{task.TaskName}' already exists in the project '{projectName}'.");

            project.AddTask(task);
        }

        public List<Task> GetTasks(string projectName)
        {
            if (!projects.ContainsKey(projectName))
                throw new KeyNotFoundException("Project not found.");
            return projects[projectName].Tasks;
        }
    }
}

