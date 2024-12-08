using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem4
{
    public class Project
    {
        public string Name { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<Task> Tasks { get; private set; }

        public Project(string name, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Project name cannot be empty.");
            if (endDate < startDate)
                throw new ArgumentException("End date cannot be earlier than start date.");

            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Tasks = new List<Task>();
        }

        public void AddTask(Task task)
        {
            if (Tasks.Exists(t => t.TaskName == task.TaskName))
                throw new ArgumentException("Task with the same name already exists in the project.");
            Tasks.Add(task);
        }

    }
}

