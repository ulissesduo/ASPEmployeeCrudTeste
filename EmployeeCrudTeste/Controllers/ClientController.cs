using EmployeeCrudTeste.Data;
using EmployeeCrudTeste.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudTeste.Controllers
{
    public class ClientController : Controller
    {
        private readonly Context mvcDbContext;
        public ClientController(Context mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve the client or perform any necessary checks
            

            // Pass the client ID as the model to the view
            return View();
        }


        [HttpPost]
        public IActionResult BuyProduct(Guid clientId, Guid productId)
        {
            var client = mvcDbContext.Clients.FirstOrDefault(c => c.Id == clientId);


            if (client == null)
                return NotFound();

            var orderProduct = mvcDbContext.Products.FirstOrDefault(p => p.Id == productId);

            if (orderProduct == null)
                return NotFound();

            if (orderProduct.StockQuantity > 0)
            {
                orderProduct.StockQuantity -= 1;

                if (orderProduct.StockQuantity == 0)
                    orderProduct.Available = false;

                // Create a new order and associate it with the client
                var order = new Order
                {
                    Id = GenerateOrderId(), // Generate a unique order ID
                    Client = client
                };

                order.Products.Add(orderProduct);

                client.Orders.Add(order);

                return RedirectToAction("Products", new { clientId });
            }

            return BadRequest("Product is out of stock.");

        }
        private int GenerateOrderId()
        {
            // Generate a random number between 1000 and 9999
            var random = new Random();
            return random.Next(1000, 10000);
        }
    }

}
