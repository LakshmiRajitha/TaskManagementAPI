using System;
using TaskManagementAPI.Entities;

namespace TaskManagement.Test.MockData
{
	public class TaskMockData
	{
		public static List<TaskModel> GetTaskList()
		{
            return new List<TaskModel>{
             new TaskModel{
                 TaskID = 1,
                 TaskName = "New Task 1",
                 Description = "Task 1 Description",
                 Deadline ="01/01/2020"
             },
             new TaskModel{
                 TaskID = 1,
                 TaskName = "New Task 2",
                 Description = "Task 2 Description",
                 Deadline ="01/01/2022"
             },
             new TaskModel{
                 TaskID = 1,
                 TaskName = "New Task 3",
                 Description = "Task 3 Description",
                 Deadline = "01/01/20203"
             },
         };
        }
        public static List<TaskModel> GetEmptyTasks()
        {
            return new List<TaskModel>();
        }
    }

}

