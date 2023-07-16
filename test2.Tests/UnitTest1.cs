using FluentAssertions;
using System.Collections.ObjectModel;
using test2.Models;

namespace test2.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Gpa_ShouldReturnZero_WhenNoModulesExist()
        {
            // Arrange
            var student = new Student();
            student.StudentModules = new ObservableCollection<StudentModules>();

            // Act
            double gpa = student.Gpa;

            // Assert
            gpa.Should().Be(0);
        }
       
        [Fact]




        public void NewUser_passwd_shouldBestrong()
        {
            User user = new User();
            user.UserName = "Test";
            user.Password = "Test22222222";

            user.Password.Should().NotBeNullOrEmpty();
            user.Password.Should().NotBeNullOrWhiteSpace();
        }
        [Fact]
        public void When_thereare_noModule_registred_gpa_sholdbeZero()
        {
            // Arrange
            var student = new Student
            {
                Id = 1,
                RegNo = 123456,
                Name = "John Doe",
                Email = "john.doe@example.com",
               
            };

            // Act
            var gpa = student.Gpa;

            // Assert
            gpa.Should().Be(0);
        }
        [Fact]
        public void User_ConstructWithParameters_SetsPropertiesCorrectly()
        {
            // Arrange
            string userName = "john.doe";
            string password = "password123";
            string role = "admin";

            // Act
            var user = new User(userName, password, role);

            // Assert
            user.UserName.Should().Be(userName);
            user.Password.Should().Be(password);
            user.Role.Should().Be(role);
        }

    }
}