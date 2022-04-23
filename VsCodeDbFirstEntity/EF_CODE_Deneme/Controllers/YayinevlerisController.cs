using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;

namespace Controllers
{
    public class YayinevlerisController : Controller
    {
        private readonly KutuphaneAksamContext _context;
        public YayinevlerisController(KutuphaneAksamContext context)
        {
            _context = context;
        }
        //Get-Listeleme
        public IActionResult Index()
        {
            return View(_context.Yayinevleris.ToList());
        }
        //Get-Detay Sayfası
        public IActionResult Details(int id)
        {
            var secilenId = _context.Yayinevleris.Find(id);
            return View(secilenId);
        }

        //Get-Düzelt Sayfası
        public IActionResult Edit(int id)
        {
            var secilenId = _context.Yayinevleris.Find(id);
            return View(secilenId);
        }
        //Post-Veritabanında Düzeltme
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Ad,Adres,Tel")] Yayinevleri yayinevi)
        {
            _context.Update(yayinevi);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //Get-Yayınevi Silme
        public IActionResult Delete(int id)
        {
            var silmeId = _context.Yayinevleris.Find(id);
            return View(silmeId);
        }
        [HttpPost, ActionName("DeleteYayinevi")]
        public IActionResult DeleteYayinevi(int id)
        {
            var silinecekId = _context.Yayinevleris.Find(id);
            _context.Remove(silinecekId);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Yeni bir Yayınevi ekleme sayfası
        public IActionResult Create()
        {
            return View();
        }
        //Post- Yeni bir kayıt ekleme
        [HttpPost]
        public IActionResult Create(Yayinevleri yayinevleri){
            _context.Add(yayinevleri);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}