using TaskMasterApi.Models;

namespace TaskMasterApi.Services
{
    public class TaskDataStore
    {
        public List<TaskModel> Tasks { get; set; }
        public static TaskDataStore Current { get; } = new TaskDataStore();

        public TaskDataStore()
        {
            Tasks =
            [
                new(){
                    ID = 1,
                    Title = "Aprender C#",
                    Description = "Aprender los fundamentos C#",
                    IsCompleted = false
                },
                new(){
                    ID = 2,
                    Title = "Aprender ASP.NET Core",
                    Description = "Aprender los fundamentos ASP.NET Core",
                    IsCompleted = false
                },
                new(){
                    ID = 3,
                    Title = "Aprender Entity Framework Core",
                    Description = "Aprender los fundamentos Entity Framework Core",
                    IsCompleted = false
                }
            ];
        }
    }
}