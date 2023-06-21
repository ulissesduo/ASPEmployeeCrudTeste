using EmployeeCrudTeste.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudTeste.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Teste> Teste { get; set; }
        public DbSet<Category> Categories { get; set; }

    }
}
