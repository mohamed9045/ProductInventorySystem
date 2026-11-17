using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using ProductInventorySystem.BLL.Services.Interfaces;
using ProductInventorySystem.BLL.ViewModels;

namespace ProductInventorySystem.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();

            return View(products);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var error = await _productService.CreateAsync(model);

            Console.WriteLine("SKU ERROR: " + error);

            if (error != null)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductFormViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var error = await _productService.UpdateAsync(model);

            if (error != null)
            {
                ModelState.AddModelError("", error);
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Products/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _productService.DeleteAsync(id);

            if (!result)
                return NotFound();

            return RedirectToAction(nameof(Index));
        }
    }
}
