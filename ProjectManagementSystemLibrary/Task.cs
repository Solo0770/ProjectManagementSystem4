using ProjectManagementSystem4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementSystem4
{
    public class Task
    {
        public string TaskName { get; private set; }
        public TeamMember AssignedTo { get; private set; }
        public string Status { get; private set; }

        internal static readonly string[] AllowedStatuses = { "Заплановано", "Виконується", "Завершено" };


        public Task(string taskName, TeamMember assignedTo, string status)
        {
            if (string.IsNullOrWhiteSpace(taskName))
                throw new ArgumentException("Task name cannot be empty or whitespace.");

            ValidateStatus(status);

            TaskName = taskName;
            AssignedTo = assignedTo ?? throw new ArgumentNullException(nameof(assignedTo), "Assigned team member cannot be null.");
            Status = status;
        }

        private static void ValidateStatus(string status)
        {
            if (!Array.Exists(AllowedStatuses, s => s == status))
                throw new ArgumentException($"Invalid status. Allowed statuses are: {string.Join(", ", AllowedStatuses)}");
        }


        public void UpdateStatus(string newStatus)
        {
            ValidateStatus(newStatus);
            Status = newStatus;
        }

    }
}
