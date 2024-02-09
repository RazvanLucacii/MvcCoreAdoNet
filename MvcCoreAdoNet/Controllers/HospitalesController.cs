using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;
using System.Text.RegularExpressions;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        RepositoryHospital repositoryHospital = new RepositoryHospital();
        public IActionResult HospitalesView(int? eliminar)
        {
            if (eliminar != null)
            {
                this.repositoryHospital.DeleteHospital(eliminar.Value);
            }
            List<Hospital> hospitals = this.repositoryHospital.GetHospitales();
            return View(hospitals);
        }

        public IActionResult Details(int idHospital)
        {
            Hospital hospital = this.repositoryHospital.FindHospitalById(idHospital);
            return View(hospital);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Hospital hospital)
        {
            this.repositoryHospital.InsertHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MENSAJE"] = "Hospital insertado";
            return View();
        }

        public IActionResult Edit(int idHospital)
        {
            Hospital hospital = this.repositoryHospital.FindHospitalById(idHospital);
            return View(hospital);
        }

        [HttpPost]
        public IActionResult Edit(Hospital hospital)
        {
            this.repositoryHospital.UpdateHospital(hospital.IdHospital, hospital.Nombre,
                hospital.Direccion, hospital.Telefono, hospital.Camas);
            ViewData["MESNSAJE"] = "Hospital Modificado Correctamente";
            return RedirectToAction("HospitalesView");
        }
 
    }
}
