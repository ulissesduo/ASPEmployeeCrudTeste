namespace EmployeeCrudTeste.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public Client Client { get; set; }
        public List<Products> Products { get; set; }

        public Order()
        {
            Products = new List<Products>();
        }
    }
}
