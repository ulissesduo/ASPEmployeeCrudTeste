using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTeste.Models.Domain
{
    public class UserModel
    {
        public int Id { get; set; }
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
        public string LastName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        
        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password must be same")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedOn { get; set; }


    }
}
