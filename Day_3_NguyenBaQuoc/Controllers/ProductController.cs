using Day_3_NguyenBaQuoc.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day_3_NguyenBaQuoc.Controllers
{
    public class ProductController : Controller
    {
        private static List<Product> _products = new List<Product>()
        {
            new Product(){Id=1, Name="Laptop", Price=3000, Description="Asus"},
            new Product(){Id=2, Name="Smart Phone", Price=1500, Description="Samsung"},
            new Product(){Id=3, Name="Mouse", Price=500, Description="Razer"},
        };

        // GET: ProductController
        public ActionResult Index()
        {
            return View(_products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            var category = _products.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm]Product product)
        {
            if (ModelState.IsValid)
            {
                int newId = _products.Any() ? _products.Max(c => c.Id) + 1 : 1;
                _products.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit([FromRoute]int id)
        {
            var category = _products.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            var existingProduct = _products.FirstOrDefault(c => c.Id == product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingProduct.Name = product.Name;
                existingProduct.Price = product.Price;
                existingProduct.Description = product.Description;
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _products.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: ProductController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var category = _products.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _products.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
