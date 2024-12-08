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
        public void Should_Create_TeamMember_With_Valid_Data()
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
        public void Should_Throw_Exception_For_Invalid_Or_Missing_MemberId()
        {
            // Arrange
            string name = "Nick Gurr";

            // Act та Assert
            Assert.Throws<ArgumentException>(() => new TeamMember(name, 0));  // ID = 0
            Assert.Throws<ArgumentException>(() => new TeamMember(name, -1)); // ID < 0
        }

        [Fact]
        public void Should_Throw_Exception_For_Empty_Name()
        {
            // Arrange
            int memberId = 1;

            // Act та Assert
            Assert.Throws<ArgumentException>(() => new TeamMember("", memberId)); // пусте 
            Assert.Throws<ArgumentException>(() => new TeamMember(null, memberId)); // null
        }
    }
}
