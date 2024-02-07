using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;

namespace MvcCoreAdoNet.Controllers
{
    public class MascotasController : Controller
    {
        public IActionResult MascotasView()
        {
            List<Mascota> listaMascotas = new List<Mascota>();
            listaMascotas.Add(new Mascota( "Max",   "Leon",   22 ));
            listaMascotas.Add(new Mascota( "Mia",  "Tigre",  16 ));
            listaMascotas.Add(new Mascota("Mira",  "Gato",7 ));
            return View(listaMascotas);
        }
    }
}
