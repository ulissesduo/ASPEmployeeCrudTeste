using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTeste.Models
{
    public class AddEmployeeViewModel
    {
        [StringLength(150)]
        public string Name { get; set; }
        [StringLength(150)]
        public string Email { get; set; }
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; }
    }
}
