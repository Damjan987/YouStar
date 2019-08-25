using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouStar.Core.Models;
using YouStar.DataAccess.InMemory;

namespace YouStar.WebUI.Controllers
{
    public class UserManagerController : Controller
    {
        InMemoryRepository<User> context;

        public UserManagerController()
        {
            context = new InMemoryRepository<User>();
        }
        // GET: PostManager
        public ActionResult Index()
        {
            List<User> users = context.Collection().ToList();
            return View(users);
        }

        public ActionResult Create()
        {
            User user = new User();
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            else
            {
                context.Insert(user);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            User user = context.Find(Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public ActionResult Edit(User user, string Id)
        {
            User userToEdit = context.Find(Id);
            if (userToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(user);
                }

                userToEdit.FirstName = user.FirstName;
                userToEdit.LastName = user.LastName;
                userToEdit.Email = user.Email;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            User userToDelete = context.Find(Id);

            if (userToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(userToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            User userToDelete = context.Find(Id);

            if (userToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.Commit();
                return RedirectToAction("Index");
            }
        }
    }
}