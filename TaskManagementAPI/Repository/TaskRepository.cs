using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TaskManagementAPI.Entities;
using TaskManagementAPI.Repository.Contracts;

namespace TaskManagementAPI.Repository
{
    /// <summary>
    /// This class holds the Task repository.
    /// </summary>
    public class TaskRepository : ITaskRepository
    {
        private const string JsonFile = "./StaticData/TaskList.json";
        private readonly string jsonText = File.ReadAllText(JsonFile);

        /// <summary>
        /// Get all Task list.
        /// </summary>
        /// <returns>List of all Tasks.</returns>
        public async Task<List<TaskModel>> GetAllTasks()
        {

            if (string.IsNullOrEmpty(this.jsonText))
            {
                return null;
            }

            var list = JsonConvert.DeserializeObject<List<TaskModel>>(this.jsonText);
            return await Task.FromResult(list);
        }

        /// <summary>
        /// Get Task by ID.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        /// <returns>return task.</returns>
        public async Task<TaskModel> GetTask(int taskID)
        {
            if (string.IsNullOrEmpty(this.jsonText))
            {
                return null;
            }

            var list = JsonConvert.DeserializeObject<List<TaskModel>>(this.jsonText)?.FirstOrDefault(t => t.TaskID == taskID);
            return await Task.FromResult(list);
        }

        /// <summary>
        /// This service used for to create the Task.
        /// </summary>
        /// <param name="taskModel">taskModel.</param>
        public void CreateTask(TaskModel taskModel)
        {
            var taskList = JsonConvert.DeserializeObject<List<TaskModel>>(this.jsonText);
            taskList.Add(taskModel);
            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(taskList, Formatting.Indented));
        }

        /// <summary>
        /// This service used for to update the Task.
        /// </summary>
        /// <param name="taskModel">taskModel.</param>
        public void UpdateTask(TaskModel taskModel)
        {
            var taskList = JsonConvert.DeserializeObject<List<TaskModel>>(this.jsonText);
            foreach (TaskModel itemToUpdate in taskList.Where(t => t.TaskID == taskModel.TaskID))
            {
                itemToUpdate.TaskName = taskModel.TaskName;
                itemToUpdate.Description = taskModel.Description;
                itemToUpdate.Deadline = taskModel.Deadline;
            }
            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(taskList));
        }

        /// <summary>
        /// This service used for to delete the Task.
        /// </summary>
        /// <param name="taskID">taskID.</param>
        public void DeleteTask(int taskID)
        {
            var taskList = JsonConvert.DeserializeObject<List<TaskModel>>(this.jsonText);
            var itemToRemove = taskList.FirstOrDefault(t => t.TaskID == taskID);
            if (itemToRemove != null)
            {
                taskList.Remove(itemToRemove);
            }
            File.WriteAllText(JsonFile, JsonConvert.SerializeObject(taskList));

        }
    }
}
