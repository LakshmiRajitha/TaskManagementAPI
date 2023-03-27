namespace TaskManagementAPI.Entities
{
    /// <summary>
    /// Task.
    /// </summary>
    public class TaskModel
    {
        /// <summary>
        /// Gets or sets TaskID.
        /// </summary>
        public int TaskID { get; set; }

        /// <summary>
        /// Gets or sets TaskName.
        /// </summary>
        public string TaskName { get; set; }

        /// <summary>
        /// Gets or sets Description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Deadline.
        /// </summary>
        public string Deadline { get; set; }
    }
}
