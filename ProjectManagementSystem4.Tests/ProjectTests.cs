using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagementSystem4.Tests
{
    public class ProjectTests
    {
        [Fact]
        public void CreateProject_ValidData_ReturnsCreatedProject()
        {
            // Arrange
            string name = "Project A";
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(30);

            // Act
            var project = new Project(name, startDate, endDate);

            // Assert
            Assert.Equal(name, project.Name);
            Assert.Equal(startDate, project.StartDate);
            Assert.Equal(endDate, project.EndDate);
        }

        [Fact]
        public void CreateProject_EmptyName_ThrowsArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(30);

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => new Project("", startDate, endDate));
            Assert.Equal("Project name cannot be empty.", ex.Message);
        }

        [Fact]
        public void CreateProject_EndDateBeforeStartDate_ThrowsArgumentException()
        {
            // Arrange
            DateTime startDate = DateTime.Now;
            DateTime endDate = startDate.AddDays(-1);

            // Act та Assert
            var ex = Assert.Throws<ArgumentException>(() => new Project("Project A", startDate, endDate));
            Assert.Equal("End date cannot be earlier than start date.", ex.Message);
        }
    }
}
