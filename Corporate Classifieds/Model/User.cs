using System.ComponentModel.DataAnnotations;

namespace AuthorizeModule.Models
{
    public class User
    {
        [Required(ErrorMessage = "Title is required")]
        public int? EmployeeId { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Password { get; set; }
        
    }
}
