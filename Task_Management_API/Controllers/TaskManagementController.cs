using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Task_Management_API.Data;
using Task_Management_API.Model.Domain;
using Task_Management_API.Model.DTO;

namespace Task_Management_API.Controllers
{
    // https://localhost:7298/api/tasks
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly TaskManagementDbcontext dbcontext;

        public TaskManagementController(TaskManagementDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        // GET : https://localhost:7298/api/tasks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<TaskManagement> tasks = await dbcontext.Tasks.ToListAsync();
            return Ok(tasks);
        }

        // GET : https://localhost:7298/api/tasks/id
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int id)
        {
            var task = await dbcontext.Tasks.SingleOrDefaultAsync(x => x.Id == id);
            return Ok(task);
        }

        // POST : https://localhost:7298/api/tasks
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] AddTaskDto addTaskDto)
        {
            var taskDomin = new TaskManagement
            {
                Id = addTaskDto.Id,
                Title = addTaskDto.Title,
                Description = addTaskDto.Description,
                DueDate = addTaskDto.DueDate,
                IsCompleted = addTaskDto.IsCompleted,
            };

            await dbcontext.Tasks.AddAsync(taskDomin);
            await dbcontext.SaveChangesAsync();

            return Ok(taskDomin);

        }

        // PUT : https://localhost:7298/api/tasks
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id , [FromBody] UpdateTaskDto updateTaskDto)
        {
            var taskDomain =  await dbcontext.Tasks.SingleOrDefaultAsync(x =>x.Id == id);

            if (taskDomain == null)
            {
                return NotFound();
            }

            taskDomain.Title = updateTaskDto.Title;
            taskDomain.Description = updateTaskDto.Description;
            taskDomain.DueDate = updateTaskDto.DueDate;
            taskDomain.IsCompleted = updateTaskDto.IsCompleted;
          
            await dbcontext.SaveChangesAsync();
            return Ok(taskDomain);
        }

        // DELETE : https://localhost:7298/api/tasks
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            var task = await dbcontext.Tasks.SingleOrDefaultAsync(x =>x.Id == id);

            if(task == null)
            {
                return NotFound();
            }
             
            dbcontext.Tasks.Remove(task);
            await dbcontext.SaveChangesAsync();

            return Ok(task);
        }

    }
}
