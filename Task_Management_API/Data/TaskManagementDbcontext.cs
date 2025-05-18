using Microsoft.EntityFrameworkCore;
using TaskManagement = Task_Management_API.Model.Domain.TaskManagement;

namespace Task_Management_API.Data
{
    public class TaskManagementDbcontext : DbContext
    {
        public TaskManagementDbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        // DbSet of an task entity
        public DbSet<TaskManagement> Tasks { get; set; }
    }
}
