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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskManagement>().HasData(

                new TaskManagement()
                {
                    Id = 1,
                    Title = "Seed Task 1",          
                    Description = "This is a seeded task",
                    DueDate = DateTime.UtcNow.AddDays(3),
                    IsCompleted = false
                }
            );

        }
    }
}
