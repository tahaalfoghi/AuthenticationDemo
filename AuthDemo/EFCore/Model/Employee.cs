using System.ComponentModel.DataAnnotations;

namespace AuthDemo.EFCore.Model
{
    public class Employee
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? FullName { get; set; }
        
    }
}
