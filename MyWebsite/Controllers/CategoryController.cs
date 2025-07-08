using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;
using MyWebsite.Models;

namespace MyWebsite.Controllers
{
    //pass the data to see in the table when run the project
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name ==obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match te Name.");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);//to add category
                _db.SaveChanges();//go to the db and create that category
                return RedirectToAction("Index");
            }
            return View();
            
        }
    }
}
