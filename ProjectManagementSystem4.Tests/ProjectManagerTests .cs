using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagementSystem4.Tests
{
    public class ProjectManagerTests
    {
        [Fact]
        public void Should_Add_Task_To_Project()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Implement some feature", teamMember, "Заплановано");

            projectManager.AddProject(project);

            // Act
            projectManager.AddTask("Project A", task);

            // Assert
            var tasks = projectManager.GetTasks("Project A");
            Assert.Contains(task, tasks);
        }

        [Fact]
        public void Should_Update_Task_Status()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Implement some feature", teamMember, "Заплановано");

            projectManager.AddProject(project);
            projectManager.AddTask("Project A", task);

            // Act
            projectManager.UpdateTaskStatus("Project A", "Implement some feature", "Виконується");

            // Assert
            var tasks = projectManager.GetTasks("Project A");
            var updatedTask = tasks.Find(t => t.TaskName == "Implement some feature");
            Assert.NotNull(updatedTask);
            Assert.Equal("Виконується", updatedTask.Status);
        }

        [Fact]
        public void Should_Return_All_Tasks_For_Project()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));

            var teamMember1 = new TeamMember("Nick Gurr", 1);
            var teamMember2 = new TeamMember("Anna", 2);

            var task1 = new Task("Implement some feature", teamMember1, "Заплановано");
            var task2 = new Task("Fix bug Y", teamMember2, "Виконується");

            projectManager.AddProject(project);
            projectManager.AddTask("Project A", task1);
            projectManager.AddTask("Project A", task2);

            // Act
            var tasks = projectManager.GetTasks("Project A");

            // Assert
            Assert.Equal(2, tasks.Count);
            Assert.Contains(task1, tasks);
            Assert.Contains(task2, tasks);
        }

        [Fact]
        public void Should_Throw_Exception_For_Invalid_Status()
        {
            // Arrange
            var teamMember = new TeamMember("Nick Gurr", 1);

            // Act та Assert
            Assert.Throws<ArgumentException>(() => new Task("Task 1", teamMember, "InvalidStatus"));
        }

        [Fact]
        public void Should_Throw_Exception_For_Duplicate_Task_Name()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Task 1", teamMember, "Заплановано");

            projectManager.AddProject(project);
            projectManager.AddTask("Project A", task);

            // Act та Assert
            Assert.Throws<ArgumentException>(() => projectManager.AddTask("Project A", task));
        }

    }
}

