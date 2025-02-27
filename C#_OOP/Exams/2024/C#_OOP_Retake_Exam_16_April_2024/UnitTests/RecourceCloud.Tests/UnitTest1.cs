using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

namespace RecourceCloud.Tests
{
    public class Tests
    {
        [Test]
        public void Constructor_initializesCorrectly()
        {
            // Act
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(departmentCloud, Is.Not.Null);
                Assert.That(departmentCloud.Tasks, Is.Not.Null);
                Assert.That(departmentCloud.Tasks, Is.Empty);
                Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
                Assert.That(departmentCloud.Resources, Is.Not.Null);
                Assert.That(departmentCloud.Resources, Is.Empty);
                Assert.That(departmentCloud.Resources.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void LogTask_logsSuccessfully()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act
            string result = departmentCloud.LogTask(taskDetails);

            // Assert
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
            Assert.That(result, Is.EqualTo("Task logged successfully."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenArgsAreLessThan3()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string[] taskDetails = new string[] { priority.ToString(), label };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(taskDetails);
            });
            Assert.That(exception.Message, Is.EqualTo("All arguments are required."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenArgsAreMoreThan3()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string details2 = "Details2";
            string[] taskDetails = new string[] { priority.ToString(), label, details, details2 };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(taskDetails);
            });
            Assert.That(exception.Message, Is.EqualTo("All arguments are required."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenDetailsIsNull()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = null;
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(taskDetails);
            });
            Assert.That(exception.Message, Is.EqualTo("Arguments values cannot be null."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenLabelIsNull()
        {
            // Arrange
            int priority = 1;
            string label = null;
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(taskDetails);
            });
            Assert.That(exception.Message, Is.EqualTo("Arguments values cannot be null."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenArgsAreNull()
        {
            // Arrange
            int priority = 1;
            string label = null;
            string details = null;
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act & Assert
            Exception exception = Assert.Throws<ArgumentException>(() =>
            {
                departmentCloud.LogTask(taskDetails);
            });
            Assert.That(exception.Message, Is.EqualTo("Arguments values cannot be null."));
        }

        [Test]
        public void LogTask_NotSuccessful_WhenTaskAlreadyLogged()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(taskDetails);

            // Act
            string result = departmentCloud.LogTask(taskDetails);

            // Assert
            Assert.That(result, Is.EqualTo($"{details} is already logged."));
            Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
        }

        [Test]
        public void CreateResource_Success()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(taskDetails);

            departmentCloud.LogTask(new string[] { "2", "SecondLabel", "SecondDetails" });

            // Act
            bool success = departmentCloud.CreateResource();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
                Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(1));
            });
        }

        [Test]
        public void CreateResource_Success_Variant2()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(taskDetails);

            // Act
            bool success = departmentCloud.CreateResource();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
                Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void CreateResource_Fail_WhenNoTaskFound()
        {
            // Arrange
            DepartmentCloud departmentCloud = new DepartmentCloud();

            // Act
            bool success = departmentCloud.CreateResource();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(departmentCloud.Resources.Count, Is.EqualTo(0));
                Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestResource_ReturnsResource_WhenResourceExists()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(taskDetails);
            departmentCloud.CreateResource();

            // Act
            Resource resource = departmentCloud.TestResource(details);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(resource, Is.Not.Null);
                Assert.That(resource.IsTested, Is.True);
                Assert.That(resource.Name, Is.EqualTo(details));
                Assert.That(resource.ResourceType, Is.EqualTo(label));
                Assert.That(departmentCloud.Resources.Count, Is.EqualTo(1));
                Assert.That(departmentCloud.Tasks.Count, Is.EqualTo(0));
            });
        }

        [Test]
        public void TestResource_ReturnsNull_WhenResourceDoesNotExist()
        {
            // Arrange
            int priority = 1;
            string label = "Label";
            string details = "Details";
            string[] taskDetails = new string[] { priority.ToString(), label, details };
            DepartmentCloud departmentCloud = new DepartmentCloud();
            departmentCloud.LogTask(taskDetails);

            // Act
            Resource resource = departmentCloud.TestResource(details);

            // Assert
            Assert.That(resource, Is.Null);
        }
    }
}