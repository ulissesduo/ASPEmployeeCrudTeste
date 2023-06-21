using EmployeeCrudTeste.Models.Domain;

namespace EmployeeCrudTeste.Helper
{
    public class TypeProducts
    {
        public static List<Category> GetAll()
        {
            return new List<Category>
            {
                new Category { Id = 1, Name = "Instrumento"},
                new Category { Id = 2, Name = "Método"},
                new Category { Id = 3, Name = "Acessório"},

            };
        }
    }
}
