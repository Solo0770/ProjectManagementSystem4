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
         
        }

       

    }
}
