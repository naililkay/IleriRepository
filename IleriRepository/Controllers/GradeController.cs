using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class GradeController : Controller
    {
        GradeModel _model;
        public IUnit _uow;

        public GradeController(IUnit uow, GradeModel model)
        {
            _uow = uow;
            _model = model;
        }

        public IActionResult List()
        {
            var glist = _uow._gradeRep.List();
              
            return View(glist);
        }
        public IActionResult Create()
        {
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.Grade = new Grade();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(GradeModel gm)
        {
            _uow._gradeRep.Add(gm.Grade);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }
            public IActionResult Update(string Id)
            {
                _model.Head = "Güncelleme";
                _model.Text = "Güncelle";
                _model.Cls = "btn btn-primary";
                _model.Grade = _uow._gradeRep.Find(Id);
                return View("Crud", _model);
            }
            [HttpPost]

            public IActionResult Update(GradeModel gm)
            {
                _uow._gradeRep.Update(gm.Grade);
                _uow.SaveChanges();
                return RedirectToAction("List");
            }
             public IActionResult Delete(string Id)
            {
            _model.Head = "Silme İşlemi";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.Grade = _uow._gradeRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]

        public IActionResult Delete(Grade grade)
        {
            _uow._gradeRep.Delete(grade);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }


    }
    }



