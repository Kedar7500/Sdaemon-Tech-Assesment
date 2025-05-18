using System.ComponentModel.DataAnnotations;

namespace Task_Management_API.Model.DTO
{
    public class UpdateTaskDto
    {
        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 to 100 characters")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(1000, ErrorMessage = "Description isupto only 1000 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "DueDate is required and it must be in the future")]
        public DateTime DueDate { get; set; }

        [Required(ErrorMessage = "Completion status is required")]
        public bool IsCompleted { get; set; }
    }
}
