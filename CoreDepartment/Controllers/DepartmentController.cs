using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreDepartment.Models;

namespace CoreDepartment.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Departments.Where(o => o.IsDeleted == false).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult AddDepartmant()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddDepartmant(Department d)
        {
            setDefaultValues(d);

            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        private void setDefaultValues(Department d)
        {
            if (d.AddedOn <= DateTime.MinValue)
            {
                d.AddedOn = DateTime.Now;
            }
            else
            {
                d.UpdatedOn = DateTime.Now;
            }

            if (d.IsDeleted)
            {
                d.DeletedOn = DateTime.Now;
            }
        }

        public IActionResult DeleteDepartmant(int id)
        {
            var dep = c.Departments.Find(id);
            dep.IsDeleted = true;
            dep.DeletedOn = DateTime.Now;
            c.Departments.Update(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult FindDepartmant(int id)
        {
            var dep = c.Departments.Find(id);
            return View(dep);
        }

        public IActionResult UpdateDepartmant(Department dep)
        {
            setDefaultValues(dep);
            c.Departments.Update(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
