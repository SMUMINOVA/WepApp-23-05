using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FirstWebApp.Models;

namespace FirstWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var p = new DapperPerson().GetPersons();
            return View(p);
        }
        [HttpGet]
        public IActionResult AddPerson(){
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person p){
            new DapperPerson().InsertPerson(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult LookingForPerson(){
            return View();
        }
        [HttpGet]
        public IActionResult SelectById(){
            return View();
        }
        [HttpPost]
        public IActionResult SelectById(Person p){
            var SelectedPerson = new DapperPerson().GetPersonById(p.Id);
            return RedirectToAction("ViewPerson", new Person {Id = SelectedPerson[0].Id, FirstName = SelectedPerson[0].FirstName, MiddleName = SelectedPerson[0].MiddleName, LastName = SelectedPerson[0].LastName});
        }
        [HttpGet]
        public IActionResult SelectByFIO(){
            return View();
        }
        [HttpPost]
        public IActionResult SelectByFIO(Person p){
            var SelectedPerson = new DapperPerson().GetPersonByFIO(p);
            return RedirectToAction("ViewPerson", new Person {Id = SelectedPerson[0].Id, FirstName = SelectedPerson[0].FirstName, MiddleName = SelectedPerson[0].MiddleName, LastName = SelectedPerson[0].LastName});
        }
        public IActionResult ViewPerson(Person p){
            return View(p);
        }
    }
}
