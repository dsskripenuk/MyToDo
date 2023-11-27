using System.ComponentModel.DataAnnotations;

namespace Test_Task_Shop_Express.Models
{
    public class TaskModel
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsDone { get; set; }
    }
}
