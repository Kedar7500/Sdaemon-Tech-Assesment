using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task_Management_API.Data;
using Task_Management_API.Model.Domain;
using Task_Management_API.Model.DTO;

namespace Task_Management_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly TaskManagementDbcontext dbcontext;

        public TaskManagementController(TaskManagementDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            
             List<TaskManagement> tasks = dbcontext.Tasks.ToList();
             return Ok(tasks);
        }

        [HttpPost]
        public IActionResult CreateTask([FromBody] AddTaskDto addTaskDto)
        {
            var taskDomin = new TaskManagement 
            {
                Id = addTaskDto.Id,
                Title = addTaskDto.Title,
                Description = addTaskDto.Description,
                DueDate = addTaskDto.DueDate,
                IsCompleted = addTaskDto.IsCompleted,
            };

                 dbcontext.Tasks.Add(taskDomin);
                dbcontext.SaveChanges();

            return Ok(taskDomin);


        }
    }
}
