using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class DoctoresController : Controller
    {
        RepositoryDoctores repoDoc = new RepositoryDoctores();
        public IActionResult DoctoresView()
        {
            List<Doctor> doctores = this.repoDoc.GetDoctores();
            return View(doctores);
        }

        [HttpPost]
        public IActionResult DoctoresView(string especialidad)
        {
            List<Doctor> doctores = this.repoDoc.FindDoctoresByEspecialidad(especialidad);
            return View(doctores);
        }

        public IActionResult DoctoresEspecialidadOneModel()
        {
            List<Doctor> doctores = this.repoDoc.GetDoctores();
            List<string> especialidades = this.repoDoc.GetEspecialidades();
            ModelDoctores model = new ModelDoctores();
            model.Doctores = doctores;
            model.Especialidades = especialidades;

            ViewData["ESPECIALIDADES"] = especialidades;
            return View(model);
        }

        [HttpPost]
        public IActionResult DoctoresEspecialidadOneModel(string especialidad)
        {
            List<Doctor> doctores =
                this.repoDoc.FindDoctoresByEspecialidad(especialidad);
            List<string> especialidades = this.repoDoc.GetEspecialidades();
            ModelDoctores model = new ModelDoctores();
            model.Doctores = doctores;
            model.Especialidades = especialidades;

            ViewData["ESPECIALIDADES"] = especialidades;
            return View(model);
        }
    }
}
