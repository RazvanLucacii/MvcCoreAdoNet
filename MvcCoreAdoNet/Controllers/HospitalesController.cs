using Microsoft.AspNetCore.Mvc;
using MvcCoreAdoNet.Models;
using MvcCoreAdoNet.Repositories;

namespace MvcCoreAdoNet.Controllers
{
    public class HospitalesController : Controller
    {
        public IActionResult HospitalesView()
        {
            RepositoryHospital repositoryHospital = new RepositoryHospital();
            List<Hospital> hospitals = repositoryHospital.GetHospitales();
            return View(hospitals);
        }
    }
}
