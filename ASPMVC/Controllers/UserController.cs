using ASPMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPMVC.Controllers
{
    public class UserController : Controller
    {
        private UserRepository _repo = new UserRepository();
        // GET: User
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InternalCreate(User u)
        {
            _repo.Add(u);
            return RedirectToAction("Details", new { Id = u.Id });
        }
        
        public ActionResult Update(int? id)
        {
            if (id == null)
                return RedirectToAction("Index");
            var model = _repo.GetById(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(User u)
        {
            _repo.Update(u);
            return RedirectToAction("Details", new { id = u.Id });
        }

        public ActionResult Remove(int id)
        {
            _repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model =  _repo.GetById(id);
            return View(model);
        }

        // equiv to get all
        public ActionResult Index()
        {
            var temp = _repo.GetAll().Select(u => new UserViewModel() { Id = u.Id, Name = u.Name, Email = u.Email });
            UserListViewModel ulvm = new UserListViewModel() {
                Users = temp
            };
            return View(ulvm);
        }
    }
}