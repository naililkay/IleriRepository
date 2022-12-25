using IleriRepository.Context;
using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Diagnostics;
using IleriRepository.Repositories.Concretes;
using IleriRepository.Repositories.Abstract;

namespace IleriRepository.Controllers
{
    public class PersonelController : Controller
    {
        IUnit _unit;
    

        public PersonelController(IUnit unit)
        
        {
            _unit = unit;
            
        }

        public IActionResult ListGrade()
        {

            return View(_unit._personelRep.ListbyGrade());
            
        }

        public IActionResult Details(int Id)
        {
            Personel p = _unit._personelRep.FindDetail(Id);
            

            return View(p);
        }

        public IActionResult Update(int Id)
        {
             Personel p = _unit._personelRep.Find(Id);
           

            return View("Crud",p);
        }
        [HttpPost]
        public IActionResult Update(Personel p)
        {
           
            _unit._personelRep.Update(p);
            _unit.SaveChanges();
          
            return RedirectToAction("ListGrade");

        }

        public IActionResult Delete(Personel p)
        {
            _unit._personelRep.Delete(p);
            _unit.SaveChanges();
            return RedirectToAction("ListGrade");

        }


        public IActionResult ListDep()
        {

            return View(_unit._personelRep.ListbyDepatment());
        }
    }
}
