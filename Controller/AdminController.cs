using Ege.Models;
using Ege.ViewModels;
using Microsoft.EntityFrameworkCore;
using Ege.Data;
using Microsoft.AspNetCore.Mvc;

public class AdminController : Controller
{
    public IActionResult Admin()
    {
        return View();
    }
}