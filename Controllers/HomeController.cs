using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PortfolioV2.Models;

namespace PortfolioV2.Controllers;


public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private List<Empleo> ObtenerEmpleos() {
        //Creamos una funcion que nos devuelva la lista de empleos
        return new List<Empleo>(){ new Empleo
        {
            Empresa = "Aluar SAIC",
            Puesto = "Especialista Tecnico",
            ImagenURL = "https://www.ricoh.com/-/Media/Ricoh/Common/cmn_v1/img/og-image.gif",
            paginaWeb = "https://www.aluar.com.ar/"
        },
        new Empleo
        {
            Empresa = "Ricoh",
            Puesto = "Soporte Tecnico Nivel 1",
            ImagenURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSl73UdPAW238fvb3lQN3p0xFidO-J6lLyc1A&s",
            paginaWeb = "https://www.ricoh-americalatina.com/es-ar"
        },
        new Empleo
        {
            Empresa = "FIUBA",
            Puesto = "Desarrollador de software",
            ImagenURL = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR1my1Y9hkeHjftUykpwYZ2v6V0Z8uqLoJDXQ&s",
            paginaWeb = "https://www.fi.uba.ar/"
        },
        };
    }
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Trabajos()
    {
        var empleos = ObtenerEmpleos().Take(3).ToList();
        var modelo = new TrabajosViewModel() {Empleos = empleos};
        return View(modelo);
    }

    public IActionResult Contacto()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
