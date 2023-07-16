using FluentAssertions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xunit;

namespace TestProject
{
    public class StudentTests
    {
        [Fact]
        public void Gpa_ShouldCalculateCorrectly_WhenModulesExist()
        {
            // Arrange
            var student = new Student();
            var modules = new ObservableCollection<StudentModules>
            {
                new StudentModules { Credit = 3, Grade = "A" },
                new StudentModules { Credit = 4, Grade = "B+" },
                new StudentModules { Credit = 2, Grade = "A-" }
            };
            student.StudentModules = modules;

            // Act
            double gpa = student.Gpa;

            // Assert
            gpa.Should().BeApproximately(3.27, 0.01);
        }

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
        public void GetRegmod_ShouldPopulateModules_WhenStudentModulesExistInDatabase()
        {
            // Arrange
            var student = new Student { Id = 1 };
            var databaseDataContex = new DatabaseDataContex();
            // TODO: Prepare the databaseDataContex to contain the expected StudentModules for the given student Id

            // Act
            student.GetRegmod();

            // Assert
            student.StudentModules.Should().NotBeNull();
            student.StudentModules.Should().NotBeEmpty();
        }

        [Fact]
        public void GetRegmod_ShouldNotPopulateModules_WhenNoStudentModulesExistInDatabase()
        {
            // Arrange
            var student = new Student { Id = 1 };
            var databaseDataContex = new DatabaseDataContex();
            // TODO: Prepare the databaseDataContex to not contain any StudentModules

            // Act
            student.GetRegmod();

            // Assert
            student.StudentModules.Should().NotBeNull();
            student.StudentModules.Should().BeEmpty();
        }
    }
}
