using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;

namespace EF_CODE_Deneme.Controllers
{
    public class TurlersController : Controller
    {
        private readonly KutuphaneAksamContext _context;
        public TurlersController(KutuphaneAksamContext context)
        {
            _context = context;
        }
        //GEt-Listeleme
        public IActionResult Index()
        {
            return View(_context.Turlers.ToList());
        }
        //GEt-Detay
        public IActionResult Details(int id)
        {
            var secilenID = _context.Turlers.Find(id);
            return View(secilenID);
        }
        //Get-Düzeltme Sayfası
        public IActionResult Edit(int id)
        {
            var tur = _context.Turlers.Find(id);
            return View(tur);
        }
        //Post-Yapılan düzenlemeyi veritabanına gönderme
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,TurAd")] Turler tur)
        {
            _context.Update(tur);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Delete Sayfası bilgileri listeleme
        public IActionResult Delete(int id)
        {
            var turDelete = _context.Turlers.Find(id);
            return View(turDelete);
        }
        //Post-Silinecek terim
        [HttpPost, ActionName("DeleteConfirmed")]
        public IActionResult DeleteConfirmed(int id)
        {
            var secilenID = _context.Turlers.Find(id);
            _context.Remove(secilenID);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Kaydetme Sayfası
        public IActionResult Create()
        {
            return View();
        }
        //Post-Yeni Kayıt Sayfası
        [HttpPost]
        public IActionResult Create(Turler tur)
        {
            if (tur.TurAd == string.Empty)
            {
                
            }
            else
            {
                _context.Add(tur);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}