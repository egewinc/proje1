using Ege.Models;
using Ege.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ege.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    public HomeController(ApplicationDbContext context)
    {
        _context = context;
        
    }

    public IActionResult Anasayfa()
    {
        var model = new AnasayfaViewModel
        {
            Araclar = _context.Araclar.ToList()
        };

        if (model.Araclar == null)
        {
            model.Araclar = new List<Araclar>();
        }

        return View(model);
    }
    public IActionResult Hakkimizda()
    {
        return View();
    }
    public IActionResult Iletisim()
    {
        return View();
    }

   public IActionResult Karsilastir()
    {
        var model = new KarsilastirmaViewModel
        {
            Araclar = _context.Araclar.ToList()  
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Karsilastir(int id1, int id2)
    {
        var arac1 = _context.Araclar.Include(a => a.AracDetay).FirstOrDefault(a => a.Id == id1);
        var arac2 = _context.Araclar.Include(a => a.AracDetay).FirstOrDefault(a => a.Id == id2);

        if (arac1 == null || arac2 == null)
        {
            var model = new KarsilastirmaViewModel
            {
                Araclar = _context.Araclar.ToList(),
            };

            return View(model);
        }

        var modelResult = new KarsilastirmaViewModel
        {
            Araclar = _context.Araclar.ToList(),
            Arac1 = arac1,
            Arac2 = arac2
        };

        return View(modelResult);
    }
}
