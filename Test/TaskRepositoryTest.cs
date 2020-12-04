using System.Linq;
using BE;
using DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test
{
    [TestClass]
    public class TaskRepositoryTest
    {
        private TaskRepository taskRepository = new TaskRepository();

        [TestMethod]
        public void ClearTest()
        {
            // Arrange
            taskRepository.Save(new Task { Title = "Do homework", Completed = false });

            // Assert
            Assert.AreNotEqual(0, taskRepository.GetAll().Count());

            // Act
            taskRepository.Clear();

            // Assert
            Assert.AreEqual(0, taskRepository.GetAll().Count());
        }

        [TestMethod]
        public void SaveOnceTest()
        {
            // Arrange
            var newTask1 = new Task { Title = "Call mum", Completed = false };
            var newTask2 = new Task { Title = "Do homework", Completed = false };
            taskRepository.Clear();

            // Assert
            Assert.AreEqual(0, taskRepository.GetAll().Count());

            // Act
            taskRepository.Save(newTask1);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count());

            // Act
            taskRepository.Save(newTask2);

            // Assert
            Assert.AreEqual(2, taskRepository.GetAll().Count());
        }

        [TestMethod]
        public void SaveTwiceTest()
        {
            // Arrange
            var newTask1 = new Task { Title = "Call mum", Completed = false };
            taskRepository.Clear();

            // Assert
            Assert.AreEqual(0, taskRepository.GetAll().Count());

            // Act
            taskRepository.Save(newTask1);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count());

            // Act
            taskRepository.Save(newTask1);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count());
        }

        [TestMethod]
        public void UpdateTitleTest()
        {
            // Arrange
            var newTask1 = new Task { Title = "Call mum", Completed = false };
            taskRepository.Clear();

            // Act
            taskRepository.Save(newTask1);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count(t => t.Title == newTask1.Title));

            // Act
            newTask1.Title = "Call mum and dad";

            // Assert
            Assert.AreEqual(0, taskRepository.GetAll().Count(t => t.Title == "Call mum"));
            Assert.AreEqual(1, taskRepository.GetAll().Count(t => t.Title == "Call mum and dad"));
        }

        [TestMethod]
        public void UpdateIsCompletedTest()
        {
            // Arrange
            var newTask1 = new Task { Title = "Call mum", Completed = false };
            taskRepository.Clear();

            // Act
            taskRepository.Save(newTask1);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count(t => t.Completed == false));

            // Act
            newTask1.Completed = true;

            // Assert
            Assert.AreEqual(0, taskRepository.GetAll().Count(t => !t.Completed));
            Assert.AreEqual(1, taskRepository.GetAll().Count(t => t.Completed));
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            var newTask1 = new Task { Title = "Call mum", Completed = false };
            var newTask2 = new Task { Title = "Water flowers", Completed = false };
            taskRepository.Clear();
            taskRepository.Save(newTask1);
            taskRepository.Save(newTask2);

            // Assert
            Assert.AreEqual(2, taskRepository.GetAll().Count());

            // Act
            taskRepository.Delete(newTask2);

            // Assert
            Assert.AreEqual(1, taskRepository.GetAll().Count());
            Assert.IsNull(taskRepository.GetAll().SingleOrDefault(t => t.Id == newTask2.Id));
            Assert.IsNotNull(taskRepository.GetAll().SingleOrDefault(t => t.Id == newTask1.Id));
        }
    }
}