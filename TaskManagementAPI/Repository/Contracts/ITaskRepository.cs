using System.Collections.Generic;
using System.Threading.Tasks;
using TaskManagementAPI.Entities;

namespace TaskManagementAPI.Repository.Contracts
{
    /// <summary>
    /// This interface holds the Task repository.
    /// </summary>
    public interface ITaskRepository
    {
        /// <summary>
        /// Get Task by ID.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        /// <returns>return task.</returns>
        Task<TaskModel> GetTask(int taskID);

        /// <summary>
        /// Get all Task list.
        /// </summary>
        /// <returns>List of all Tasks.</returns>
        Task<List<TaskModel>> GetAllTasks();

        /// <summary>
        /// This service used for to create the Task.
        /// </summary>
        /// <param name="taskModel">taskModel.</param>
        void CreateTask(TaskModel taskModel);

        /// <summary>
        /// This service used for to update the Task.
        /// </summary>
        /// <param name="taskModel">taskModel.</param>
        void UpdateTask(TaskModel taskModel);

        /// <summary>
        /// This service used for to delete the Task.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        void DeleteTask(int taskID);
    }
}
