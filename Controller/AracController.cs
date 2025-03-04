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

    public IActionResult Karsilastir(int id)
    {
        var aracDetay = _context.AracDetay
                                .Include(a => a.Arac)
                                .FirstOrDefault(a => a.arac_ıd == id);

        if (aracDetay == null)
        {
            return NotFound();
        }

        return View(aracDetay);
    }

    #region Actions

    // Yeni Create metodunu güncelleme
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(string ad, string soyad, int yas, string marka, string model, int yil, decimal fiyat,
                                decimal motorHacmi, int koltukSayisi, int motorGucu, decimal tork, string renk, int tramerKaydi,string degisenParca)
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

            var aracDetay = new AracDetay
            {
                arac_ıd = arac.Id,  // AracId'si aracın ID'si
                motorH = (int)motorHacmi,
                koltukSay = koltukSayisi,
                hp = motorGucu,
                tork = (int)tork,
                renk = renk,
                tramerKaydı = tramerKaydi,
                degisenParca = degisenParca,
                
            };

            _context.AracDetay.Add(aracDetay); // Aracın detaylarını ekleyin
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
}}
