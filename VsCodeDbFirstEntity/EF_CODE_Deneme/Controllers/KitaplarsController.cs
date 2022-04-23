using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Controllers
{
    public class KitaplarsController : Controller
    {
        private readonly KutuphaneAksamContext _context;
        public KitaplarsController(KutuphaneAksamContext context)
        {
            _context = context;
        }
        //Get-Kitap Listeleme
        public IActionResult Index()
        {
            return View(_context.Kitaplars.ToList());
        }
        //Get-Kitap Detayları
        public IActionResult Details(string id)
        {
            var seciliKitap = _context.Kitaplars.Include(k => k.Turler).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First(s => s.Isbn == id);
            return View(seciliKitap);
        }
        //Get-Düzeltme Sayfası
        public IActionResult Edit(string id)
        {
            var secilenKitap = _context.Kitaplars.Find(id);
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd", secilenKitap.TurlerId);
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", secilenKitap.YazarlarId);
            ViewData["Yayinevi"] = new SelectList(_context.Yayinevleris, "Id", "Ad", secilenKitap.YayinEvleriId);
            return View(secilenKitap);
        }
        //Post-Düzeltme kaydetme
        [HttpPost]
        public IActionResult Edit(Kitaplar kitap)
        {
            _context.Kitaplars.Update(kitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Silme Sayfası
        public IActionResult Delete(string id)
        {
            var silicekId = _context.Kitaplars.Find(id);
            ViewData["Tur"] = new SelectList(_context.Turlers, "Id", "TurAd", silicekId.TurlerId);
            ViewData["Yazar"] = new SelectList(_context.Yazarlars, "Id", "AdSoyad", silicekId.YazarlarId);
            ViewData["Yayinevi"] = new SelectList(_context.Yayinevleris, "Id", "Ad", silicekId.YayinEvleriId);
            return View(silicekId);
        }
        //Post-Silme
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteConfirmed(string id)
        {
            var seciliKitap = _context.Kitaplars.Include(k => k.Turler).Include(k => k.Yazarlar).Include(k => k.YayinEvleri).First(s => s.Isbn == id);
            _context.Remove(seciliKitap);
            _context.SaveChanges();
            return RedirectToAction("Index");
        } 
        //Get-Yeni Kitap Ekle
        public IActionResult Create()
        {
        ViewData["Tur"]= new SelectList(_context.Turlers,"Id", "TurAd",_context.Kitaplars.Include(x=>x.Turler).ToList());
        ViewData["Yazar"]= new SelectList(_context.Yazarlars,"Id", "AdSoyad",_context.Kitaplars.Include(x=>x.Yazarlar).ToList());
        ViewData["Yayinevi"]= new SelectList(_context.Yayinevleris,"Id", "Ad",_context.Kitaplars.Include(x=>x.YayinEvleri).ToList());
            return View();
        }
        //Post-Yeni Kitap Ekle Veritabanı
        [HttpPost]
        public IActionResult Create(Kitaplar kitap)
        {
            _context.Add(kitap);
            _context.SaveChanges();
            return  RedirectToAction("Index");
        }
    }
}