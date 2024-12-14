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
        public void AddTaskToProject_ValidData_ReturnsTaskAddedToProject()
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
        public void AddProject_DuplicateProjectName_ThrowsArgumentException()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));

            projectManager.AddProject(project);

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => projectManager.AddProject(project));
            Assert.Equal("Project with the same name already exists.", ex.Message);
        }

        [Fact]
        public void AddTaskToNonExistentProject_ThrowsKeyNotFoundException()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Implement some feature", teamMember, "Заплановано");

            // Act та Assert
            var ex = Assert.Throws<KeyNotFoundException>(() => projectManager.AddTask("Nonexistent Project", task));
            Assert.Equal("Project 'Nonexistent Project' not found.", ex.Message);
        }

        [Fact]
        public void AddTask_NullTask_ThrowsArgumentNullException()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));

            projectManager.AddProject(project);

            // Act та Assert
            var ex = Assert.Throws<ArgumentNullException>(() => projectManager.AddTask("Project A", null));
            Assert.Equal("Task cannot be null. (Parameter 'task')", ex.Message);
        }

        [Fact]
        public void AddTask_EmptyTaskName_ThrowsArgumentException()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Valid Task", teamMember, "Заплановано");

            projectManager.AddProject(project);

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => projectManager.AddTask("Project A", new Task("", teamMember, "Заплановано")));
            Assert.Equal("Task name cannot be empty or whitespace.", ex.Message);
        }

        [Fact]
        public void UpdateTaskStatus_ValidData_ReturnsUpdatedStatus()
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
        public void GetTasksFromProject_ValidProject_ReturnsAllTasks()
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
        public void AddTaskToProject_DuplicateTaskName_ThrowsArgumentException()
        {
            // Arrange
            var projectManager = new ProjectManager();
            var project = new Project("Project A", DateTime.Now, DateTime.Now.AddDays(30));
            var teamMember = new TeamMember("Nick Gurr", 1);
            var task = new Task("Task 1", teamMember, "Заплановано");

            projectManager.AddProject(project);
            projectManager.AddTask("Project A", task);

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => projectManager.AddTask("Project A", task));
            Assert.Equal("Task with the name 'Task 1' already exists in the project 'Project A'.", ex.Message);
        }

    }
}

