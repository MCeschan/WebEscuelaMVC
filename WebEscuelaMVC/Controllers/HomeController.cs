using Microsoft.AspNetCore.Mvc;
using System;

namespace WebEscuelaMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Encabezado = "Bienvenido al Portal de la Escuela nombre";
            ViewBag.Fecha = DateTime.Now.ToString();
            return View();
        }
    }
}
