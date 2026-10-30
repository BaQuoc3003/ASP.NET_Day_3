using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Day_3_NguyenBaQuoc.Models;

namespace Day_3_NguyenBaQuoc.Controllers
{
    public class CategoryController : Controller
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category(){Id=1, Name="Category 1"},
            new Category(){Id=2, Name="Category 2"},
            new Category(){Id=3, Name="Category 3"},
        };

        // GET: Category
        public ActionResult Index()
        {
            return View(_categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Category/Create
        public ActionResult Create(int id)
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                int newId = _categories.Any()? _categories.Max(c => c.Id) + 1 : 1;
                _categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Edit/5
        public ActionResult Edit([FromRoute]int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null) {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            var existingCategory = _categories.FirstOrDefault(c => c.Id == category.Id);
            if (existingCategory == null) { 
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                existingCategory.Name = category.Name;
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            var category = _categories.FirstOrDefault(c => c.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _categories.Remove(category);
            return RedirectToAction(nameof(Index));
        }
    }
}
