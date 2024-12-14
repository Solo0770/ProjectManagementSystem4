using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProjectManagementSystem4.Tests
{
    public class TeamMemberTests
    {
        [Fact]
        public void CreateTeamMember_ValidData_ReturnsCreatedTeamMember()
        {
            // Arrange
            string name = "Nick Gurr";
            int memberId = 1;

            // Act
            TeamMember member = new TeamMember(name, memberId);

            // Assert
            Assert.Equal(name, member.Name);
            Assert.Equal(memberId, member.MemberId);
        }

        [Fact]
        public void CreateTeamMember_InvalidOrMissingMemberId_ThrowsArgumentException()
        {
            // Arrange
            string name = "Nick Gurr";

            // Act та Assert
            var ex1 = Assert.Throws<ArgumentException>(() => new TeamMember(name, 0));
            Assert.Equal("Member ID must be a positive number and explicitly provided.", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => new TeamMember(name, -1));
            Assert.Equal("Member ID must be a positive number and explicitly provided.", ex2.Message);
        }

        [Fact]
        public void CreateTeamMember_EmptyName_ThrowsArgumentException()
        {
            // Arrange
            int memberId = 1;

            // Act та Assert
            var ex1 = Assert.Throws<ArgumentException>(() => new TeamMember("", memberId));
            Assert.Equal("Name cannot be empty.", ex1.Message);

            var ex2 = Assert.Throws<ArgumentException>(() => new TeamMember(null, memberId));
            Assert.Equal("Name cannot be empty.", ex2.Message);
        }
    }
}
