using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Repository.Contracts;

namespace TaskManagementAPI.Controllers
{
    /// <summary>
    ///  This class has actions of all Task Controller.
    /// </summary>
    [Route("api/task")]
    [ApiController]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        // private ILoggerManager logger = new LoggerManager();
        private ITaskRepository taskRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TaskController"/> class.
        /// </summary>
        /// <param name="taskRepository">taskRepository.</param>
        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        /// <summary>
        /// Get Task.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        /// <returns>get Task.</returns>
        [HttpGet("{taskID}/task")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> GetTaskAsync(int taskID)
        {
            try
            {
                var task = await this.taskRepository.GetTask(taskID);
                return this.Ok(task);
            }
            catch (Exception ex)
            {
                // this.logger.LogError(ex, "TaskController", "GetTaskAsync");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// Get Task list.
        /// </summary>
        /// <returns>List of Tasks.</returns>
        [HttpGet("alltasks")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllTaskAsync()
        {
            try
            {
                var taskList = await this.taskRepository.GetAllTasks();
                return this.Ok(taskList);
            }
            catch (Exception ex)
            {
                // this.logger.LogError(ex, "TaskController", "GetAllTaskAsync");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// To create the Task data.
        /// </summary>
        /// <param name="taskModel">task Model.</param>
        /// <returns>returns the id.</returns>
        [HttpPost("createtask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult CreateTask(TaskModel taskModel)
        {
            try
            {
                this.taskRepository.CreateTask(taskModel);
                return this.Ok(string.Empty);
            }
            catch (Exception ex)
            {
                // this.logger.LogError(ex, "TaskController", "CreateTask");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// To update the Task data.
        /// </summary>
        /// <param name="taskModel">task Model.</param>
        /// <returns>returns the id.</returns>
        [HttpPost("updatetask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult UpdateTask(TaskModel taskModel)
        {
            try
            {
                this.taskRepository.UpdateTask(taskModel);
                return this.Ok(string.Empty);
            }
            catch (Exception ex)
            {
                // this.logger.LogError(ex, "TaskController", "UpdateTask");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        /// To delete the Task data.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        /// <returns>delete task by task id.</returns>
        [HttpPost("{taskID}/deletetask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [Produces("application/json")]
        public IActionResult DeleteTask(int taskID)
        {
            try
            {
                this.taskRepository.DeleteTask(taskID);
                return this.Ok(string.Empty);
            }
            catch (Exception ex)
            {
                // this.logger.LogError(ex, "TaskController", "DeleteTask");
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
