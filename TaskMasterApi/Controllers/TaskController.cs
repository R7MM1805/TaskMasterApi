using Microsoft.AspNetCore.Mvc;
using TaskMasterApi.Models;
using TaskMasterApi.Services;

namespace TaskMasterApi.Controllers
{
    [Controller]
    [Route("/api/[controller]")]
    public class TaskController : Controller
    {
        [HttpGet("GetTask")]
        public ActionResult<List<TaskModel>> GetTask() => Ok(TaskDataStore.Current.Tasks);
        [HttpGet("GetTaskByID")]
        public ActionResult<TaskModel> GetTaskByID(int id)
        {
            TaskModel? task = TaskDataStore.Current.Tasks.FirstOrDefault(x => x.ID == id);
            return task is null ? NotFound("La tarea no fue encontrada") : Ok(task);
        }
    }
}