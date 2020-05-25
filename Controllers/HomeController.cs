﻿using System;
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
            var persons = new DapperPerson().GetPersons();
            return View(persons);
        }
        [HttpGet]
        public IActionResult AddPerson(){
            return View();
        }
        [HttpPost]
        public IActionResult AddPerson(Person p){
            //var p = new Person{FirstName = firstName, MiddleName = middleName, LastName = lastName};
            new DapperPerson().InsertPerson(p);
            return RedirectToAction("Index");
        }
    }
}
