using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Ege.Models;
using Ege.Data;

namespace Ege.Controllers
{
    public class KullaniciController : Controller 
    {
        private readonly ApplicationDbContext _context;
        
        public KullaniciController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var kullanicilar =  _context.Kullanicilar.ToList();     
            if (kullanicilar == null || !kullanicilar.Any())
            {
                return Content("No data found"); 
            }
            return View(kullanicilar); 
        }
        

    }
}