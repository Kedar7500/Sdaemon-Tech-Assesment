using AutoMapper;
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
    // https://localhost:7298/api/TaskManagement
    [Route("api/[controller]")]
    [ApiController]
    public class TaskManagementController : ControllerBase
    {
        private readonly TaskManagementDbcontext dbcontext;
        private readonly ILogger<TaskManagementController> logger;
        private readonly IMapper mapper;

        public TaskManagementController(TaskManagementDbcontext dbcontext, ILogger<TaskManagementController> logger,
            IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.logger = logger;
            this.mapper = mapper;
        }

        // GET :https://localhost:7298/api/TaskManagement
        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                List<TaskManagement> tasks = await dbcontext.Tasks.ToListAsync();

                if (tasks == null)
                {
                    return NotFound();
                }

                return Ok(tasks);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
           
        }

        // GET :https://localhost:7298/api/TaskManagement/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTaskById([FromRoute] int id)
        {
            try
            {
                var task = await dbcontext.Tasks.SingleOrDefaultAsync(x => x.Id == id);

                if (task == null)
                {
                    return NotFound();
                }

                return Ok(task);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }

        // POST : https://localhost:7298/api/TaskManagement
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] AddTaskDto addTaskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                     var taskDomain = mapper.Map<TaskManagement>(addTaskDto);

                    //var taskDomain = new TaskManagement
                    //{
                    //    Id = addTaskDto.Id,
                    //    Title = addTaskDto.Title,
                    //    Description = addTaskDto.Description,
                    //    DueDate = addTaskDto.DueDate,
                    //    IsCompleted = addTaskDto.IsCompleted,
                    //};

                    if (taskDomain == null) { return NotFound(); }  

                    await dbcontext.Tasks.AddAsync(taskDomain);
                    await dbcontext.SaveChangesAsync();

                    var taskDto = mapper.Map<TaskManagementDto>(taskDomain);

                    return CreatedAtAction(nameof(GetTaskById), new { id = taskDomain.Id }, taskDomain);
                }
                else
                {
                    return BadRequest(ModelState);
                }

            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }

        // PUT : https://localhost:7298/api/TaskManagement/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTask([FromRoute] int id , [FromBody] UpdateTaskDto updateTaskDto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var taskDomain = mapper.Map<TaskManagement>(updateTaskDto);

                    taskDomain = await dbcontext.Tasks.SingleOrDefaultAsync(x => x.Id == id);

                    if (taskDomain == null)
                    {
                        return NotFound();
                    }

                    taskDomain.Title = updateTaskDto.Title;
                    taskDomain.Description = updateTaskDto.Description;
                    taskDomain.DueDate = updateTaskDto.DueDate;
                    taskDomain.IsCompleted = updateTaskDto.IsCompleted;

                    await dbcontext.SaveChangesAsync();

                    var taskDto = mapper.Map<TaskManagementDto>(taskDomain);

                    return Ok(taskDto);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
           
            
        }

        // DELETE : https://localhost:7298/api/TaskManagement{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTask([FromRoute] int id)
        {
            try
            {
                var task = await dbcontext.Tasks.SingleOrDefaultAsync(x => x.Id == id);

                if (task == null)
                {
                    return NotFound();
                }

                dbcontext.Tasks.Remove(task);
                await dbcontext.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex) 
            {
                logger.LogError(ex.Message);
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
