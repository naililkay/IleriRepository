using IleriRepository.Data;
using IleriRepository.DTO;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class CountyController : Controller
    {
        CountyModel _model;
        public IUnit _uow;


        public CountyController(IUnit uow, CountyModel model)
        {
            _uow = uow;
            _model = model;

        }
        public IActionResult List()
        { 
                  var colist =_uow._countyRep.Set().Select(x => new CountyDTO
                  {
                      
                      Id = x.Id,
                      CityName=x.City.CityName,
                      CountyName=x.CountyName                    
                  }).ToList();

            return View(colist);
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.City = _uow._cityRep.List();
            _model.County = new County();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(CountyModel m)
        {
            _uow._countyRep.Add(m.County);      
            _uow.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Update(int Id)
        {
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-primary";
            _model.County = _uow._countyRep.Find(Id);
            _model.City = _uow._cityRep.List();
            return View("Crud", _model);
        }
        [HttpPost]

        public IActionResult Update(CountyModel m)
        {
            _uow._countyRep.Update(m.County);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Silme";
            _model.Text = "Sil";
            _model.Cls = "btn btn-primary";
            _model.County = _uow._countyRep.Find(Id);
            _model.City = _uow._cityRep.List();
            return View("Crud", _model);
        }
        [HttpPost]

        public IActionResult Delete(County county)
        {
            _uow._countyRep.Delete(county);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }
      

    }
}