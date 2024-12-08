﻿using System;
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

    }
}
