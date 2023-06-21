using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTeste.Models
{
    public class UpdateEmployeeViewModel
    {
        public Guid Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(16)]
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
