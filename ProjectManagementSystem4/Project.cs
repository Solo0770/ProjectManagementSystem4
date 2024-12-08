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
           
        }

       
    }
}

