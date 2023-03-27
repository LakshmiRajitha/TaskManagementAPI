
using TaskManagementAPI.Repository.Contracts;
using Moq;
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Controllers;
using TaskManagement.Test.MockData;
using FluentAssertions;


namespace TaskManagement.Test
{
	public class TaskManagementControllerTest
	{
		
		[Fact]
		public async Task GetTaskList_ShouldReturn200Status()
        {
            /// Arrange
            var taskService = new Mock<ITaskRepository>();
            taskService.Setup(_ => _.GetAllTasks()).ReturnsAsync(TaskMockData.GetTaskList());
            var sut = new TaskController(taskService.Object);

            /// Act
            var result = (OkObjectResult)await sut.GetAllTaskAsync();
            /// Assert
            result.StatusCode.Should().Be(200);
        }
        
        [Fact]
        public async Task GetAllTaskAsync_ReturnTaskList()
        {
            /// Arrange
            var taskService = new Mock<ITaskRepository>();
            taskService.Setup(_ => _.GetAllTasks()).ReturnsAsync(TaskMockData.GetTaskList());
            var sut = new TaskController(taskService.Object);

            /// Act
            var result = await sut.GetAllTaskAsync();

            /// Assert
            result.Equals(TaskMockData.GetTaskList().Count);
        }
        [Fact]
        public async Task CreateTask_ShouldReturn200Status()
        {
            /// Arrange
            var taskService = new Mock<ITaskRepository>();
            taskService.Setup(_ => _.CreateTask(TaskMockData.GetTaskList()[1]));
            var sut = new TaskController(taskService.Object);

            /// Act
            var result = (OkObjectResult) sut.CreateTask(TaskMockData.GetTaskList()[1]);
            /// Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task UpdateTask_ShouldReturn200Status()
        {
            /// Arrange
            var taskService = new Mock<ITaskRepository>();
            taskService.Setup(_ => _.UpdateTask(TaskMockData.GetTaskList()[1]));
            var sut = new TaskController(taskService.Object);

            /// Act
            var result = (OkObjectResult)sut.UpdateTask(TaskMockData.GetTaskList()[1]);
            /// Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task DeleteTask_ShouldReturn200Status()
        {
            /// Arrange
            var taskService = new Mock<ITaskRepository>();
            taskService.Setup(_ => _.DeleteTask(TaskMockData.GetTaskList()[1].TaskID));
            var sut = new TaskController(taskService.Object);

            /// Act
            var result = (OkObjectResult)sut.DeleteTask(TaskMockData.GetTaskList()[1].TaskID);
            /// Assert
            result.StatusCode.Should().Be(200);
        }
    }

}

