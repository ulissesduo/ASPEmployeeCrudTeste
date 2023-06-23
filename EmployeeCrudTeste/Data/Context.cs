using EmployeeCrudTeste.Models.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudTeste.Data
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Employees> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


    }
}
