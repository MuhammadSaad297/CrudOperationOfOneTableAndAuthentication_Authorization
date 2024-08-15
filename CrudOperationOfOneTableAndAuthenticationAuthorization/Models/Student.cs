using System.ComponentModel.DataAnnotations;

namespace CrudOperationOfOneTableAndAuthenticationAuthorization.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string FName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string RollNo { get; set; }
        [Required]
        public string PhoneNumber { get; set; }

        public string Address { get; set; }
    }
}
