namespace EmployeeCrudTeste.Models.Domain
{
    public class Client
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public double Credit { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public List<Order> Orders { get; set; }

        public Client()
        {
            Orders = new List<Order>();
        }

    }
}
