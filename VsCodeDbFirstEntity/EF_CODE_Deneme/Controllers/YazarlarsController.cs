using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EF_CODE_Deneme.Controllers
{
    public class YazarlarsController : Controller
    {
        private readonly KutuphaneAksamContext _context;
        public YazarlarsController(KutuphaneAksamContext context)
        {
            _context = context;
        }

        //Get-Yazarları Listeleme
        public IActionResult Index()
        {
            var yazarlar = _context.Yazarlars.ToList();
            return View(yazarlar);
        }
        //Get-Detay Sayfası
        public IActionResult Details(int id)
        {
            var detayid = _context.Yazarlars.Find(id);
            ViewData["Yazar"] = new SelectList(_context.Turlers, "Id", "TurAd", detayid.TurlerId);
            return View(detayid);
        }
        //Get-Düzeltme Sayfası
        public IActionResult Edit(int id)
        {
            var secilenYazar = _context.Yazarlars.Find(id);
            ViewData["Yazar"] = new SelectList(_context.Turlers, "Id", "TurAd", secilenYazar.TurlerId);
            return View(secilenYazar);
        }
        //Post-Düzeltme Olayı
        [HttpPost]
        public IActionResult Edit(Yazarlar yazar)
        {
            _context.Yazarlars.Update(yazar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Silme Sayfası
        public IActionResult Delete(int id)
        {
            var silincekId=_context.Yazarlars.Find(id);
            ViewData["Yazar"] = new SelectList(_context.Turlers, "Id", "TurAd", silincekId.TurlerId);
            return View(silincekId);
        }
        //Post-Silme
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteEvent(int id)
        {
            var silineckeId=_context.Yazarlars.Find(id);
            _context.Remove(silineckeId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Yeni bir Yazar Ekleme Sayfası
        public IActionResult Create()
        {
            ViewData["Yazar"]= new SelectList(_context.Turlers,"Id", "TurAd",_context.Yazarlars.Include(x=>x.Turler).ToList());
            return View();
        }
        //Post-Yeni bir Yazar Kaydet.
        [HttpPost]
        public IActionResult Create(Yazarlar yazar)
        {
            _context.Add(yazar);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}