using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.Repositories.Abstract;
using IleriRepository.Repositories.Concretes;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace IleriRepository.Controllers
{
    public class CityController : Controller
    {
        CityModel _model;
        public IUnit _uow;
     
      
        public CityController(IUnit uow,CityModel model)
        {
            _uow=uow;
            _model = model;
          
        }
        public IActionResult List()
        {
           var clist= _uow._cityRep.List();
          return View(clist);
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.City = new City();
            return View ("Crud",_model);

        }
        [HttpPost]
        public IActionResult Create(CityModel m)
        {
            _uow._cityRep.Add(m.City);
            //Herşey uow de olacak
            //Add
            //Updat
            _uow.SaveChanges();
            return RedirectToAction("List");
            //Program.cs de newledik.
        }

        public IActionResult Update(int Id)
        {
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-primary";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]

         public IActionResult Update(CityModel m)
            {
                _uow._cityRep.Update(m.City);
                _uow.SaveChanges();
                return RedirectToAction("List");

             }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Silme İşlemi";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.City = _uow._cityRep.Find(Id);
            return View("Crud",_model);
        }
        [HttpPost]

        public IActionResult Delete(City city)
        {
            _uow._cityRep.Delete(city);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }

    }
}
