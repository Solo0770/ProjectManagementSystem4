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
        public void CreateTask_ValidData_ReturnsCreatedTask()
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
        public void CreateTask_InvalidStatus_ThrowsArgumentException()
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
        public void CreateTask_EmptyNameOrNullAssignedTo_ThrowsException()
        {
            // Arrange
            TeamMember assignedTo = new TeamMember("Nick Gurr", 1);

            // Act та Assert
            var ex1 = Assert.Throws<ArgumentException>(() => new Task("", assignedTo, "Заплановано"));
            Assert.Equal("Task name cannot be empty or whitespace.", ex1.Message);

            var ex2 = Assert.Throws<ArgumentNullException>(() => new Task("Valid Task", null, "Заплановано"));
            Assert.Equal("Assigned team member cannot be null. (Parameter 'assignedTo')", ex2.Message);
        }
    }

}
