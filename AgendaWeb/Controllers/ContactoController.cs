using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using PagedList;
using System.Web.Mvc;
using AgendaWeb.Models;

namespace AgendaWeb.Controllers
{
    public class ContactoController : Controller
    {
        private DB_AgendaWeb db = new DB_AgendaWeb();

        // GET: /Contacto/
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var contacto = from s in db.contacto select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                contacto = contacto.Where(s => s.nombreContacto.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    contacto = contacto.OrderByDescending(s => s.nombreContacto);
                    break;
                case "Date":
                    contacto = contacto.OrderBy(s => s.correoContacto);
                    break;
                case "date_desc":
                    contacto = contacto.OrderByDescending(s => s.correoContacto);
                    break;
                default:  // Name ascending 
                    contacto = contacto.OrderBy(s => s.nombreContacto);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(contacto.ToPagedList(pageNumber, pageSize));
    }
    

        // GET: /Contacto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // GET: /Contacto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Contacto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="idContacto,nombreContacto,telefonoCasa,telefonoMovil,correoContacto,direccion")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                Usuario usuario = db.usuario.FirstOrDefault(r => r.idUsuario == 1);
                contacto.usuario = usuario;
                db.contacto.Add(contacto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contacto);
        }

        // GET: /Contacto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: /Contacto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="idContacto,nombreContacto,telefonoCasa,telefonoMovil,correoContacto,direccion")] Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contacto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contacto);
        }

        // GET: /Contacto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contacto contacto = db.contacto.Find(id);
            if (contacto == null)
            {
                return HttpNotFound();
            }
            return View(contacto);
        }

        // POST: /Contacto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contacto contacto = db.contacto.Find(id);
            db.contacto.Remove(contacto);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
