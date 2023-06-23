using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudTeste.Models.Domain
{
    public class Products
    {
        public Guid Id { get; set; }

        [MinLength(6)]
        [Required(ErrorMessage = "The Name field is required."), MaxLength(100)]
        [StringLength(100, ErrorMessage = "The Name field must be at most {1} characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Price field is required.")]
        public decimal Price { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "The Category field is required.")]
        public string Category { get; set; }

        public int StockQuantity { get; set; }

        public bool Available { get; set; }
        public Guid ClientId { get; set; }
    }
}
