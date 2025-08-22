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
        public ActionResult<TaskModel> GetTaskByID([FromQuery] int id)
        {
            TaskModel? task = TaskDataStore.Current.Tasks.FirstOrDefault(x => x.ID == id);
            return task is null ? NotFound("La tarea no fue encontrada") : Ok(task);
        }
        [HttpPost("RegisterTask")]
        public ActionResult<TaskModel> RegisterTask([FromBody] RegisterTaskModel taskModel)
        {
            TaskModel newTask = TaskModel.MappingTask(taskModel);
            TaskDataStore.Current.Tasks.Add(newTask);
            return Ok(newTask);
        }
        [HttpPut("UpdateTask")]
        public ActionResult<TaskModel> UpdateTask([FromBody] RegisterTaskModel taskModel, [FromQuery] int id)
        {
            TaskModel? task = TaskDataStore.Current.Tasks.FirstOrDefault(x => x.ID == id);
            if (task is null) return NotFound("La tarea no fue encontrada");
            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.IsCompleted = taskModel.IsCompleted;
            task.UpdatedAt = DateTime.Now;
            return Ok(task);
        }
        [HttpDelete("DeleteTask")]
        public ActionResult DeleteTask([FromQuery] int id)
        {
            TaskModel? task = TaskDataStore.Current.Tasks.FirstOrDefault(x => x.ID == id);
            if (task is null) return NotFound("La tarea no fue encontrada");
            TaskDataStore.Current.Tasks.Remove(task);
            return NoContent();
        }
    }
}