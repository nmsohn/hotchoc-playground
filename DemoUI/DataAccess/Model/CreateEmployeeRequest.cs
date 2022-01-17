using System.ComponentModel.DataAnnotations;

namespace DemoUI.DataAccess.Model
{
    public class CreateEmployeeRequest
    {
        [Required(ErrorMessage = "Name is required")]        
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Department Name is required")]
        public string DepartmentName { get; set; }

        [Required(ErrorMessage = "Age Name is required")]
        [Range(minimum: 20, maximum: 50)]
        public int Age { get; set; }
    }
}