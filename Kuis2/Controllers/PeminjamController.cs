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
    public class PeminjamController : Controller
    {
        // GET: Peminjam
        public ActionResult Index()
        {
            List<Peminjam> p;
            using (var r = new Peminjam1Entities())
            {
                p = r.Peminjam.ToList();
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
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using (var r = new Peminjam1Entities())
            {
                r.Peminjam.Add(PeminjamModel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int code)
        {
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using(var r = new Peminjam1Entities())
            {
                PeminjamModel = r.Peminjam.FirstOrDefault(x => x.id == code);
            }

            return View(PeminjamModel);
        }

        [HttpGet]
        [ActionName("Edit")]

        public ActionResult Edit_Get(int code)
        {
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using(var r = new Peminjam1Entities())
            {
                PeminjamModel = r.Peminjam.Where(x => x.id == code).FirstOrDefault();
            }

            return View(PeminjamModel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(int code)
        {
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using(var r = new Peminjam1Entities())
            {
                var m = r.Peminjam.Where(x => x.id == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult delete_get(int code)
        {
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using(var r = new Peminjam1Entities())
            {
                PeminjamModel = r.Peminjam.FirstOrDefault(x => x.id == code);
            }

            return View(PeminjamModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult delete_post(int code)
        {
            var PeminjamModel = new Peminjam();
            TryUpdateModel(PeminjamModel);

            using(var r = new Peminjam1Entities())
            {
                var m = r.Peminjam.Remove(r.Peminjam.FirstOrDefault(x => x.id == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}