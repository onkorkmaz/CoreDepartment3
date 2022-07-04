using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDepartment.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDepartment.Controllers
{
    public class PersonelController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var personels = c.Personels.ToList();
            return View(personels);
        }
    }
}
