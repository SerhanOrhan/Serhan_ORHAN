using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EF_CODE_Deneme.Models;

namespace EF_CODE_Deneme.Controllers
{
    public class YazarlarsController:Controller
    {
        private readonly KutuphaneAksamContext _context;
        public YazarlarsController(KutuphaneAksamContext context)
        {
            _context=context;
        }

        //Get-Yazarları Listeleme
        public IActionResult Index(){
            var yazarlar=_context.Yazarlars.ToList();
            return View(yazarlar);
        }
        //Get-Detay Sayfası
        public IActionResult Details(int id){
            var detayid=_context.Yazarlars.Find(id);
            return View(detayid);
        }
    }
}