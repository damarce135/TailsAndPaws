using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FrontEnd.Controllers
{

    [Authorize(Roles = "Administrador,Encargado")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            return View() ;
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
            List<calendario> calendarios;
            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                calendarios = unidad.genericDAL.GetAll().ToList();
                return new JsonResult { Data = calendarios, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            }
            //using (TPEntities tPEntities = new TPEntities()){
            //    var events = calendario.ToList();

        }



        [HttpPost]
        public JsonResult SaveEvent(calendario e)
        {
            var status = false;
            calendario calendario;
            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                calendario = unidad.genericDAL.Get(e.idCalendario);

                if (e.idCalendario > 0)
                {
                    //Update the event
                    var v = calendario;
                    if (v != null)
                    {
                        
                        v.asunto = e.asunto;
                        v.fechaInicio = e.fechaInicio;
                        v.fechaFinal = e.fechaFinal;
                        v.descripcion = e.descripcion;
                        v.diaCompleto = e.diaCompleto;
                        v.temaColor = e.temaColor;
                    }
                }
                else
                {
                    unidad.genericDAL.Add(calendario);
                }
                unidad.Complete();
                status = true;
            }
            return new JsonResult { Data = new { status = status } };
        }



        private CalendarioViewModel Convertir(calendario calendario)
        {
            CalendarioViewModel calendarioViewModel = new CalendarioViewModel
            {
                idCalendario = calendario.idCalendario,
                asunto = calendario.asunto,
                fechaInicio = calendario.fechaInicio,
                fechaFinal = calendario.fechaFinal,
                descripcion = calendario.descripcion,
                diaCompleto = (bool)calendario.diaCompleto,
                temaColor = calendario.temaColor
            };
            return calendarioViewModel;
        }

        private calendario Convertir(CalendarioViewModel calendarioViewModel)
        {
            calendario calendario = new calendario
            {
                idCalendario = calendarioViewModel.idCalendario,
                asunto = calendarioViewModel.asunto,
                fechaInicio = calendarioViewModel.fechaInicio,
                fechaFinal = calendarioViewModel.fechaFinal,
                descripcion = calendarioViewModel.descripcion,
                diaCompleto = (bool)calendarioViewModel.diaCompleto,
                temaColor = calendarioViewModel.temaColor
            };
            return calendario;
        }

        //public ActionResult Inicio()
        //{
        //    List<calendario> calendarios;
        //    using (UnidadDeTrabajo<calendario> Unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
        //    {
        //        calendarios = Unidad.genericDAL.GetAll().ToList();
        //    }

        //    List<CalendarioViewModel> lista = new List<CalendarioViewModel>();

        //    foreach (var item in calendarios)
        //    {
        //        lista.Add(this.Convertir(item));
        //    }

        //    return View(lista);
        //}

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CalendarioViewModel calendarioViewModel)
        {
            calendario calendario = this.Convertir(calendarioViewModel);

            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                unidad.genericDAL.Add(calendario);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            calendario calendario;
            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                calendario = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(calendario));
        }

        [HttpPost]
        public ActionResult Editar(CalendarioViewModel calendarioViewModel)
        {
            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                unidad.genericDAL.Update(this.Convertir(calendarioViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            calendario calendario;
            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                calendario = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(calendario));
        }

        //[HttpPost] 
        //public ActionResult Delete(CalendarioViewModel calendarioViewModel)
        //{
        //    using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
        //    {
        //        unidad.genericDAL.Remove(this.Convertir(calendarioViewModel));
        //        unidad.Complete();
        //    }
        //}

        [HttpPost]
        public JsonResult DeleteEvent(int eventID)
        {
            var status = false;
            calendario calendario;

            using (UnidadDeTrabajo<calendario> unidad = new UnidadDeTrabajo<calendario>(new TPEntities()))
            {
                calendario = unidad.genericDAL.Get(eventID);
                status = true;
                Convertir(calendario);
                unidad.genericDAL.Remove(calendario);
                unidad.Complete();
            }

            //return RedirectToAction("Inicio");
               
            return new JsonResult { Data = new { status = status } };
        }
    }
}