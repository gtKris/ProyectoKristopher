using Microsoft.AspNetCore.Mvc;
using PortafolioKristopher.Models;
using PortafolioKristopher.Service;
using PortafolioKristopher.Models;
using System.Diagnostics;
using static System.Net.WebRequestMethods;

namespace PortafolioKristopher.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServiceEmail serviceEmail;  

        public HomeController(ILogger<HomeController> logger, IServiceEmail serviceEmail)
        {
            _logger = logger; 
            this.serviceEmail = serviceEmail;
        }

        public IActionResult Index()
        {
            var projects = GetProjects().Take(9).ToList();
            var model    = new HomeIndexViewModel() { Projects = projects };
            return View(model);
        }

        private List <ProjectViewModel> GetProjects() 
        {
            return new List<ProjectViewModel>()
            {
                new ProjectViewModel()
                {
                    Title = "Fiesta 1 Cama King",
                    Description = "Ubicadas alrededor de nuestra piscina para\r\n adultos cerca del vestibulo del complejo,\r\nalgunas habitaciones tienen vistas al jardin y \r\ntodos los baños cuentan con duchas de pie y \r\nprocuctos de baño amigables con el ambiente ",
                    ImageURL    = "/Images/cama 1.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$140 / noche",
                
                 },

                new ProjectViewModel()
                {
                    Title       = "Fiesta 2 Camas dobles ",
                    Description = "Ubicadas alrededor de nuestra piscina para\r\n adultos cerca del vestibulo del complejo,\r\nalgunas habitaciones tienen vistas al jardin y \r\ntodos los baños cuentan con duchas de pie y \r\nprocuctos de baño amigables con el ambiente ",
                    ImageURL    = "/Images/cama 2.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$200 / noche",
                 },
                
                new ProjectViewModel()
                {
                    Title       = "Junior Suite vista al jardín",
                    Description = "Estas suites ofrecen vistas al jardín , un \r\ndormitorio principal con una cama King , una\r\nsala de estar independientemente con cama\r\nQueen , un baño con bañera/ducha y productos de\r\nbaño amigables con el ambiente ",
                    ImageURL    = "/Images/cama 3.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$220 / dia",
                 },

                new ProjectViewModel()
                {
                    Title       = "Junior Suite vista a la piscina",
                    Description = "Estas suites ofrecen vistas a la piscina , un\r\ndormitorio principal con una cama King , una \r\nsala de estar independiente con cama \r\nQueen , un baño con bañera/ducha y \r\nproductos de baño amigables con el ambiente.",
                    ImageURL    = "/Images/suit 4.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$220 / noche",
                 },

                new ProjectViewModel()
                {
                    Title       = "Junior Suite Familiar",
                    Description = "Estas suites , que ofrecen acceso directo a la\r\npiscina , cuentan con un dormitorio principal \r\ncon cama King ,una sala independiente con \r\ncama Queen , un baño con bañera/ducha.",
                    ImageURL    = "/Images/suit 5.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$300 / 2 dias ",
                 },

                 new ProjectViewModel()
                {
                    Title       = "Junior Suite Nupcial ",
                    Description = "Estas suites , cuentan con vistas a la piscina y \r\nel jardín , un dormitorio principal con cama\r\nextragrande y un baño con una ducha de\r\npie , un jacuzzi y productos de baño\r\namigables con el ambiente.",
                    ImageURL    = "/Images/suit 6.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$300 / 2 dias",
                 },

                  new ProjectViewModel()
                {
                    Title       = "Vista al Mar 1 Cama King",
                    Description = "Estas habitaciones cuentan con vistas al \r\nocéano Pacífico , un baño con una relajante bañera.",
                    ImageURL    = "/Images/vista 7.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$140 / dia",
                 },

                    new ProjectViewModel()
                {
                    Title       = "Vista al Mar 2 Camas Dobles",
                    Description = "Estas habitaciones cuentan con vistas al \r\nocéano Pacífico , un baño con una relajante bañera.",
                    ImageURL    = "/Images/vista 8.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$200 / noche",
                 },
                 
                   new ProjectViewModel()
                {
                    Title       = "Preferenciales por accesibilidad - una cama King",
                    Description = "Estas habitaciones se ubican totalmente \r\naccesibles en la planta baja , en una zona\r\ntranquila del hotel . Los muebles están colocados \r\nde forma que permiten un acceso de 130 cm entre\r\nellos para sillas de ruedas o scooters.",
                    ImageURL    = "/Images/preferencial 9.jpg",
                    Link        = "https://localhost:7262/Home/Privacy",
                    Price       ="$140 / dia",
                 },

            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Contact(ContactViewModel contactViewModel) 
        {
            await serviceEmail.Send(contactViewModel);
            return RedirectToAction("Thanks"); 
        }

        public IActionResult Thanks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}