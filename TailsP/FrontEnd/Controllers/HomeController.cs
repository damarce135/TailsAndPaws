using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BackEnd.Entities;

namespace FrontEnd.Controllers
{

    [Authorize(Roles = "Administrador,Encargado")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           
            return View(TPEntities.Calendario.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public JsonResult GetEvents()
        {
            
                var events = Calendario.ToList();
                return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            
        }

        [HttpPost]
        public JsonResult SaveEvent(Calendario e)
        {
            var status = false;
                if (e.idCalendario > 0)
                {
                    //Update the event
                    var v = Calendario.Where(a => a.idCalendario == e.idCalendario).FirstOrDefault();
                    if (v != null)
                    {
                        v.Subject = e.asunto;
                        v.Start = e.fechaInicio;
                        v.End = e.fechaFinal;
                        v.Description = e.descripcion;
                        v.IsFullDay = e.diaCompleto;
                        v.ThemeColor = e.temaColor;
                    }
                }
                else
                {
                    Calendario.Add(e);
                }
                SaveChanges();
                status = true;
            
            return new JsonResult { Data = new { status = status } };
        }

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
      
                var v = Calendario.Where(a => a.idCalendario == eventID).FirstOrDefault();
                if (v != null)
                {
                    Calendario.Remove(v);
                    SaveChanges();
                    status = true;
                }
            
            return new JsonResult { Data = new { status = status } };
        } 

    }
}