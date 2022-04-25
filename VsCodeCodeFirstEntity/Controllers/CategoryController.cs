using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VsCodeCodeFirstEntity.Models;

namespace VsCodeCodeFirstEntity.Controllers
{
    public class CategoryController : Controller
    {
        private readonly LibraryContext _context;

        public CategoryController(LibraryContext context)
        {
            _context = context;
        }
        //Get-Category List
        public IActionResult Index()
        {
            var categories = _context.Categories.Where(x => x.IsDeleted == false).ToList();
            return View(categories);
        }
        //Get-Delete Category List
        public IActionResult GetDeletedCategories()
        {
            var deleted = _context.Categories.Where(x => x.IsDeleted == true).ToList();
            return View("Index", deleted);
        }
        //Get-Create Page
        public IActionResult Create()
        {
            return View();
        }
        //Post-Create Category
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _context.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Details Page
        public IActionResult Details(int di)
        {
            var selectedCategory=_context.Categories.Find(di);
            return View(selectedCategory);
        }

        //Get-Edit Page
        public IActionResult Edit(int di)
        {
            var item=_context.Categories.Find(di);
            return View(item);
        }
        //Post-Edit Save
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Delete Page
        public IActionResult Delete(int di)
        {
            var deleteID=_context.Categories.Find(di);
            return View(deleteID);
        }
        //Post-Delete Update
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletedCategory(int di)
        {
            var selectDi=_context.Categories.Find(di);
            selectDi.IsDeleted=true;
            _context.Categories.Update(selectDi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}