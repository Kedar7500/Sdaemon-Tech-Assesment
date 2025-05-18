using Microsoft.EntityFrameworkCore;

namespace Task_Management_API.Data
{
    public class TaskManagementDbcontext : DbContext
    {
        public TaskManagementDbcontext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {
            
        }

        // DbSet of an task entity
        public DbSet<Task> Tasks { get; set; }
    }
}
