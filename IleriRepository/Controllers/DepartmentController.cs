using IleriRepository.Data;
using IleriRepository.Models;
using IleriRepository.UnitOfWork;
using Microsoft.AspNetCore.Mvc;

namespace IleriRepository.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentModel _model;
        public IUnit _uow;

        public DepartmentController (IUnit uow, DepartmentModel model)
        {
            _uow = uow;
            _model = model;

        }

        public IActionResult List()
        {
            var dlist = _uow._departmanRep.List();
            return View(dlist);
        }

        public IActionResult Create()
        {
            _model.Head = "Yeni Giriş";
            _model.Text = "Kaydet";
            _model.Cls = "btn btn-primary";
            _model.Department = new Department();
            return View("Crud", _model);
        }
        [HttpPost]
        public IActionResult Create(DepartmentModel d)
        {
            _uow._departmanRep.Add(d.Department);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }
        public IActionResult Update(int Id)
        {
            _model.Head = "Güncelleme";
            _model.Text = "Güncelle";
            _model.Cls = "btn btn-primary";
            _model.Department = _uow._departmanRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]

        public IActionResult Update(DepartmentModel dm)
        {
            _uow._departmanRep.Update(dm.Department);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int Id)
        {
            _model.Head = "Silme İşlemi";
            _model.Text = "Sil";
            _model.Cls = "btn btn-danger";
            _model.Department = _uow._departmanRep.Find(Id);
            return View("Crud", _model);
        }
        [HttpPost]

        public IActionResult Delete(Department department)
        {
            _uow._departmanRep.Delete(department);
            _uow.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
