using TaskMasterApi.Services;

namespace TaskMasterApi.Models
{
    public class TaskModel
    {
        public int ID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }

        public static TaskModel MappingTask(RegisterTaskModel taskModel) =>
            new()
            {
                ID = TaskDataStore.Current.Tasks.Max(x => x.ID) + 1,
                Title = taskModel.Title,
                Description = taskModel.Description
            };
    }
}