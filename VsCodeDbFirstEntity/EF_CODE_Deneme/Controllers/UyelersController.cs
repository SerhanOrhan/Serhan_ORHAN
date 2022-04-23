using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;

namespace EF_CODE_Deneme.Controllers
{
    public class UyelersController : Controller
    {
        private readonly KutuphaneAksamContext _context;
        public UyelersController(KutuphaneAksamContext context)
        {
            _context = context;
        }
        //Get-Uye Listeleme
        public IActionResult Index()
        {
            foreach (var item in _context.Uyelers.Select(x=>x.Cinsiyet))
            {
                if (item=="E")
                {
                    
                }
            }
            return View(_context.Uyelers.ToList());
        }
        //Get-Uye Listeleme
        public IActionResult Details(int id)
        {
            var detailId = _context.Uyelers.Find(id);
            if (detailId.Cinsiyet == "E")
            {
                detailId.Cinsiyet = "Erkek";
            }
            else
            {
                detailId.Cinsiyet = "Kadın";
            }
            return View(detailId);
        }
        //Get-Uye Düzeltme
        public IActionResult Edit(int id)
        {
            var secilenId = _context.Uyelers.Find(id);
            if (secilenId.Cinsiyet == "E")
            {
                secilenId.Cinsiyet = "Erkek";
            }
            else
            {
                secilenId.Cinsiyet = "Kadın";
            }
            return View(secilenId);
        }
        //Post-Düzeltilen veriyi kaydetme.
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,AdSoyad,Cinsiyet")] Uyeler uye)
        {
            if (uye.Cinsiyet == "Erkek")
            {
                uye.Cinsiyet = "E";
            }
            else
            {
                uye.Cinsiyet = "K";
            }
            _context.Update(uye);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Silme Sayfası
        public IActionResult Delete(int id)
        {
            var uyeDelete = _context.Uyelers.Find(id);
            if (uyeDelete.Cinsiyet == "E")
            {
                uyeDelete.Cinsiyet = "Erkek";
            }
            else
            {
                uyeDelete.Cinsiyet = "Kadın";
            }
            return View(uyeDelete);
        }
        //Post-işlemi belirtilem id li kayıtı silme
        [HttpPost, ActionName("DeleteUye")]
        public IActionResult DeleteUye(int id)
        {
             var silinecekKitapTuru = _context.Uyelers.Find(id);
            _context.Uyelers.Remove(silinecekKitapTuru); // Bu satır databasedeki idli terimi siler
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        //Get-Create sayfası oluşturma
        public IActionResult Create(){
            return View();
        }
        //Post-Yeni üye kaydetme
        [HttpPost]
        public IActionResult Create(Uyeler uye){
            if (uye.Cinsiyet=="Erkek")
            {
                uye.Cinsiyet="E";
            }else{
                uye.Cinsiyet="K";
            }
            _context.Add(uye);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}