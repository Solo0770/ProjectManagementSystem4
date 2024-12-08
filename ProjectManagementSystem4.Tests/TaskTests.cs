using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ProjectManagementSystem4;

namespace ProjectManagementSystem4.Tests
{
    public class TaskTests
    {
        [Fact]
        public void Task_Should_Be_Created_With_Valid_Data()
        {
            // Arrange
            string taskName = "Implement some feature";
            TeamMember assignedTo = new TeamMember("Nick Gurr", 1);
            string status = "Заплановано";

            // Act
            Task task = new Task(taskName, assignedTo, status);

            // Assert
            Assert.Equal(taskName, task.TaskName);
            Assert.Equal(assignedTo, task.AssignedTo);
            Assert.Equal(status, task.Status);
        }

        [Fact]
        public void Task_Should_Throw_Exception_For_Invalid_Status()
        {
            // Arrange
            string taskName = "Task 1";
            TeamMember assignedTo = new TeamMember("Nick Gurr", 1);
            string invalidStatus = "InvalidStatus";

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => new Task(taskName, assignedTo, invalidStatus));
            Assert.Equal("Invalid status. Allowed statuses are: Заплановано, Виконується, Завершено", ex.Message);
        }

        [Fact]
        public void Task_Should_Throw_Exception_For_Empty_Name_Or_Null_AssignedTo()
        {
            // Arrange
            TeamMember assignedTo = new TeamMember("Nick Gurr", 1);

            // Act та Assert
            Assert.Throws<ArgumentException>(() => new Task("", assignedTo, "Заплановано"));
            Assert.Throws<ArgumentNullException>(() => new Task("Valid Task", null, "Заплановано"));
        }
    }

}
