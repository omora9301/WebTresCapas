using BusinessTresCapas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EntityPersona;

namespace WebTresCapas.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        BusPersona bp = new BusPersona();
        BusPersona xy = new BusPersona();
        BusEstadoCivil objec = new BusEstadoCivil();
        public ActionResult Index()
        {
            try
            {
                xy.Obtener();
                return View("Index",bp.Obtener());
                //return View(new BusPersona().Obtener());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", bp.Obtener());
                
                //return View(new BusPersona().Obtener());
            } }
        public ActionResult Agregar()
        {
                List<EntEstadoCivil> ec = new List<EntEstadoCivil>();
                ec = objec.Obtener();
                ViewBag.EstadoCivil = new SelectList(ec, "Id","NombreEC");
                return View();
           
        }
        public ActionResult AgregarPost(EntPersona persona) 
        {
            try
            {
                bp.ValidarCampos(persona);
                bp.ValidarEdad(persona);
                //bp.Validar(persona);
                TempData["resu"] = bp.AgregarPersona(persona);
                return View("Index",bp.Obtener());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Agregar", bp.Obtener());
            }
        }
        public ActionResult FormEditar(EntPersona persona)
        {
            try
            {
                EntPersona ep = bp.ObtenerPersona(persona.Id);
                List<EntEstadoCivil> ec = new List<EntEstadoCivil>();
                ec = objec.Obtener();
                ViewBag.EstadoCivil = new SelectList(ec, "id", "NombreEC");
                return View("FormEditar", ep);
            }
            catch (Exception ex)
            {
                TempData["error"] ="error   " + ex.Message;
                List<EntEstadoCivil> ec = new List<EntEstadoCivil>();
                ec = objec.Obtener();
                ViewBag.EstadoCivil = new SelectList(ec, "id", "NombreEC");
                return View("Index", bp.Obtener());
            }
        }
        public ActionResult ActualizaPersona(EntPersona persona) 
        {
            try
            {
                bp.ValidarCampos(persona);
                bp.EditarPersonaRepetido(persona);
                TempData["resu"] = bp.EditarPersona(persona);
                return View("Index", bp.Obtener());
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index", bp.Obtener());
            }
        }
        public ActionResult Eliminar(EntPersona persona) 
        {
            try
            {
                TempData["resu"] = bp.EliminarPersona(persona);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
            }
            return RedirectToAction("Index", bp.Obtener());

        }
        public ActionResult BuscarRegistro(string valor) 
        {
            try
            {
                List<EntPersona> ls = bp.Buscar(valor);
                return View("Index", ls);
            }
            catch (Exception ex)
            {
                TempData["error"] = ex.Message;
                return View("Index");
            }
            
        }
    }
}