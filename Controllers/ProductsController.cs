using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SWProducts.Data;
using SWProducts.Models;

namespace SWProducts.Controllers
{
    public class ProductsController : Controller 
    {
        private ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _context.Products.AddAsync(product);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Sorry, something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, "Sorry, something went wrong");
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var productExist = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                    
                    if(productExist != null)
                    {
                        productExist.Name = product.Name;
                        productExist.Price = product.Price;
                        productExist.Description = product.Description;
                        productExist.Quantity = product.Quantity;

                        await _context.SaveChangesAsync();

                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(string.Empty, "Product does not exist");
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Product cant be updated {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, "Product cant be updated");
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var productExist = await _context.Products.FirstOrDefaultAsync(x => x.Id == product.Id);
                    
                    if(productExist != null)
                    {
                        _context.Products.Remove(productExist);

                        await _context.SaveChangesAsync();
                        
                        return RedirectToAction("Index");
                    }

                    ModelState.AddModelError(string.Empty, "Product does not exist");
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Product cant be updated {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, "Product cant be updated");
            return View(product);
        }
    
    }
}