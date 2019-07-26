using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YouStar.Core.Models;
using YouStar.DataAccess.InMemory;

namespace YouStar.WebUI.Controllers
{
    public class PostManagerController : Controller
    {
        PostRepository context;

        public PostManagerController()
        {
            context = new PostRepository();
        }
        // GET: PostManager
        public ActionResult Index()
        {
            List<Post> posts = context.Collection().ToList();
            return View(posts);
        }

        public ActionResult Create()
        {
            Post post = new Post();
            return View(post);
        }

        [HttpPost]
        public ActionResult Create(Post post) {
            if (!ModelState.IsValid) {
                return View(post);
            }
            else
            {
                context.Insert(post);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id) {
            Post post = context.Find(Id);
            if (post == null) {
                return HttpNotFound();
            }
            else
            {
                return View(post);
            }
        }

        [HttpPost]
        public ActionResult Edit(Post post, string Id) {
            Post postToEdit = context.Find(Id);
            if (postToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid) {
                    return View(post);
                }

                postToEdit.FirstName = post.FirstName;
                postToEdit.LastName = post.LastName;
                postToEdit.Description = post.Description;
                postToEdit.Image = post.Image;
                postToEdit.Stars = post.Stars;
                postToEdit.Comments = post.Comments;

                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id) {
            Post postToDelete = context.Find(Id);

            if (postToDelete == null) {
                return HttpNotFound();
            }
            else
            {
                return View(postToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id) {
            Post postToDelete = context.Find(Id);

            if (postToDelete == null)
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