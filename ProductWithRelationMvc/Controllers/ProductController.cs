using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProductWithRelationMvc.Data;
using ProductWithRelationMvc.Models;

namespace ProductWithRelationMvc.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Including the category table as well, using Include() function
            var products = _context.Products.Include(q => q.Category).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            // Both approaches are ok to send the categories to the view but using new SelectList() is prefered.

            // Sending the whole categories 
            ViewBag.categories = _context.Categories.ToList();

            // Sending the Categories using new SelectList() class, uncomment the line below in order to use it
            //ViewBag.categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if(ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
