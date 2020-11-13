using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Kuis2.Entities;

namespace Kuis2.Controllers
{
    [Authorize]
    public class BukuController : Controller
    {
        // GET: Buku
        public ActionResult Index()
        {
            List<buku> p;
            using (var r = new BukuEntities())
            {
                p = r.buku.ToList();
            }
            return View(p);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                r.buku.Add(BukuModel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int code)
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                BukuModel = r.buku.FirstOrDefault(x => x.Id == code);
            }

            return View(BukuModel);
        }

        [HttpGet]
        [ActionName("Edit")]

        public ActionResult Edit_Get(int code)
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                BukuModel = r.buku.Where(x => x.Id == code).FirstOrDefault();
            }

            return View(BukuModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int code)
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                var b = r.buku.Where(x => x.Id == code).FirstOrDefault();
                TryUpdateModel(b);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult delete_get(int code)
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                BukuModel = r.buku.FirstOrDefault(x => x.Id == code);
            }

            return View(BukuModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult delete_post(int code)
        {
            var BukuModel = new buku();
            TryUpdateModel(BukuModel);

            using (var r = new BukuEntities())
            {
                var b = r.buku.Remove(r.buku.FirstOrDefault(x => x.Id == code));
                TryUpdateModel(b);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}