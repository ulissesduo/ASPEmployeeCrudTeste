using EmployeeCrudTeste.Models.Domain;
using EmployeeCrudTeste.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using EmployeeCrudTeste.Helper;
using EmployeeCrudTeste.Data;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrudTeste.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context mvcDbContext;

        public ProductsController(Context mvcDbContext)
        {
            this.mvcDbContext = mvcDbContext;
        }

        public async Task<IActionResult> Index()
        {
            var x = await mvcDbContext.Products.ToListAsync();
            return View(x);
        }


        [HttpGet]
        public IActionResult Add()
        {
            var typeProducts = TypeProducts.GetAll();
            var model = new AddProductViewModel();
            model.TypeProductList = new List<SelectListItem>();
            foreach (var typeProduct in typeProducts)
            {
                model.TypeProductList.Add(new SelectListItem { Text = typeProduct.Name, Value = typeProduct.Name });
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddProductViewModel model)
        {
            var selectCategory = model.SelectedCategory;
            Products products = new Products()
            {
                Id = Guid.NewGuid(),
                Name = model.Name,
                Price = model.Price,
                Description = model.Description,
                Category = selectCategory,
                StockQuantity = model.StockQuantity,

            };
            await mvcDbContext.Products.AddAsync(products);
            await mvcDbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var product = await mvcDbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product != null)
            {
                var typeProducts = TypeProducts.GetAll();
                var viewModel = new UpdateProductViewModel()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    Category = product.Category,
                    StockQuantity = product.StockQuantity,
                    TypeProductList = typeProducts.Select(typeProduct => new SelectListItem
                    {
                        Text = typeProduct.Name,
                        Value = typeProduct.Name,
                        Selected = typeProduct.Name == product.Category
                    }).ToList()
                };

                return View("Edit", viewModel);
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProductViewModel model)
        {
            var selectCategory = model.SelectedCategory;
            var product = await mvcDbContext.Products.FindAsync(model.Id);
            if (product != null)
            {
                product.Name = model.Name;
                product.Price = model.Price;
                product.Description = model.Description;
                product.Category = selectCategory;
                product.StockQuantity = model.StockQuantity;


                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || mvcDbContext.Products == null)
            {
                return NotFound();
            }

            var products = await mvcDbContext.Products //accessando a tabela Employees
                .FirstOrDefaultAsync(m => m.Id == id);


            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(UpdateProductViewModel model)
        {
            var products = await mvcDbContext.Products.FindAsync(model.Id);
            if (products != null)
            {
                mvcDbContext.Products.Remove(products);
                await mvcDbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
