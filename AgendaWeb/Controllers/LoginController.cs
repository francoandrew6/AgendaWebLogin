using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgendaWeb.Models;
namespace AgendaWeb.Controllers
{
    public class LoginController : Controller
    {
        public DB_AgendaWeb db = new DB_AgendaWeb();
        //
        // GET: /Login/
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.usuario.FirstOrDefault(u=> u.correo==usuario.correo && u.contraseña==usuario.contraseña);
            if (usr != null)
            {
                Session["nombreUsuario"] = usr.nombre;
                Session["idUsuario"] = usr.idUsuario;
                return VerificarSesion();
            }
            else
            {
                ModelState.AddModelError("", "Contraseña o Usuario incorrecto.");
            }
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            if (ModelState.IsValid) {
                Rol rol = db.rol.FirstOrDefault(r=> r.idRol==2);
                usuario.rol = rol;
                db.usuario.Add(usuario);
                db.SaveChanges();
                ViewBag.mensaje = "El usuario " + usuario.nombre + " fue registrado con exito.";
                ModelState.Clear();
            }
            return View();
        }

        public ActionResult VerificarSesion()
        {
            if (Session["idUsuario"] != null)
            {
                return RedirectToAction("../Home/Index");
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("idUsuario");
            Session.Remove("nombreUsuario");
            return RedirectToAction("Login");
        }
	}
}