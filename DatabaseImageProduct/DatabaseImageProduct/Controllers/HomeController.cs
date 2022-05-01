using DatabaseImageProduct.Models.Context;
using DatabaseImageProduct.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseImageProduct.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext _context;
        public HomeController(ProductDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }
        public IActionResult Edit(int id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/");
            var imgList = Directory.GetFiles(path);
            List<Product> uploadedImages = new List<Product>();
            foreach (var image in imgList)
            {
                FileInfo fileInfo = new FileInfo(image);
                Product uploadedImage = new Product();
                uploadedImage.ImageFullName = fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);
                uploadedImages.Add(uploadedImage);
            }
            var secilenId = _context.Products.Find(id);
            return View(secilenId);
        }
        [HttpPost]
        public IActionResult Edit(int id, Product product,IFormFile file)
        {
            if (file != null && file.ContentType == "image/png")
            {
                string imageExtension = Path.GetExtension(file.FileName);//.png yanı uzantısını aldı örnek .png/.jpg
                string imageName = Guid.NewGuid() + imageExtension;//abc.png seklide kaydetcek isim kısmı rastgeledir   örnek  abc .png
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");//burada ise alınan resmin nereye kaydedileceğini belirtiriz.

                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                product.ImageFullName = imageName;
                _context.Products.Update(product);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult Create()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/");
            var imgList = Directory.GetFiles(path);
            List<Product> uploadedImages = new List<Product>();
            foreach (var image in imgList)
            {
                FileInfo fileInfo = new FileInfo(image);
                Product uploadedImage = new Product();
                uploadedImage.ImageFullName = fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);
                uploadedImages.Add(uploadedImage);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile file)
        {
            if (file != null && file.ContentType == "image/png")
            {
                string imageExtension = Path.GetExtension(file.FileName);//.png yanı uzantısını aldı örnek .png/.jpg
                string imageName = Guid.NewGuid() + imageExtension;//abc.png seklide kaydetcek isim kısmı rastgeledir   örnek  abc .png
                string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{imageName}");//burada ise alınan resmin nereye kaydedileceğini belirtiriz.

                var stream = new FileStream(path, FileMode.Create);
                file.CopyTo(stream);
                product.ImageFullName = imageName;
                _context.Products.Update(product);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/");
            var imgList = Directory.GetFiles(path);
            List<Product> uploadedImages = new List<Product>();
            foreach (var image in imgList)
            {
                FileInfo fileInfo = new FileInfo(image);
                Product uploadedImage = new Product();
                uploadedImage.ImageFullName = fileInfo.FullName.Substring(fileInfo.FullName.IndexOf("wwwroot")).Replace("wwwroot", string.Empty);
                uploadedImages.Add(uploadedImage);
            }
            var secilenId = _context.Products.Find(id);
            return View(secilenId);
        }
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var secilenId = _context.Products.Find(id);
            _context.Products.Remove(secilenId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
