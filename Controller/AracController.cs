using Ege.Models;
using Ege.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ege.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Ege.Controllers
{
    public class AracController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AracController(ApplicationDbContext context)
        {
            _context = context;
            
        }


#region Views
public IActionResult Index()
        {
            var model = Get();

            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    
#endregion

        public IActionResult Karsilastir(int id) // id = seçilen aracın ID'si
        {
            var aracDetay = _context.AracDetay
                                    .Include(a => a.Arac) // Arac nesnesini de getir
                                    .FirstOrDefault(a => a.arac_ıd == id);

            if (aracDetay == null)
            {
                return NotFound();
            }

            return View(aracDetay);
        }

        #region Actions

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string ad, string soyad, int yas, string marka, string model, int yil, decimal fiyat)
        {
            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(marka) || string.IsNullOrEmpty(model))
            {
                ModelState.AddModelError("", "Tüm alanlar zorunludur.");
                return View();
            }

            try
            {
                var arac = new Araclar
                {
                    Marka = marka,
                    Model = model,
                    Yil = yil,
                    Fiyat = fiyat
                };

                _context.Araclar.Add(arac);
                _context.SaveChanges();

                var kullanici = new Kullanicilar
                {
                    Ad = ad,
                    Soyad = soyad,
                    Yas = yas,
                    AracId = arac.Id
                };

                _context.Kullanicilar.Add(kullanici);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu. Lütfen tekrar deneyin.");
                return View();
            }
        }
      [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Delete(int id)
{
    if (id == 0)
    {
        return NotFound();
    }

    var arac = _context.Araclar.Find(id);

    if (arac == null)
    {
        return NotFound();
    }

    _context.Araclar.Remove(arac);
    _context.SaveChanges();

    return RedirectToAction("Index");
}

        #endregion

        #region Model
    
        public AraclarKullanici Get()
        {
            var model = new AraclarKullanici
            {
                Araclar = _context.Araclar.ToList(),
                Kullanicilar = _context.Kullanicilar.Include(k => k.Arac).ToList()
            };

            return model;
        }
        #endregion
    }
    
}