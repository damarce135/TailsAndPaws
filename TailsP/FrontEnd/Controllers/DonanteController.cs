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
    public class DonanteController : Controller
    {
        private DonanteViewModel Convertir(donante donante)
        {
           DonanteViewModel donanteViewModel = new DonanteViewModel
           {
                idDonante = donante.idDonante,
                nombre = donante.nombre,
                apellido1 = donante.apellido1,
                apellido2 = donante.apellido2,
                telefono = donante.telefono,
                email = donante.email,
                habilitado = (bool)donante.habilitado
            };
            return donanteViewModel;
        }

        private donante Convertir(DonanteViewModel donanteViewModel)
        {
            donante donante = new donante
            {
                idDonante = donanteViewModel.idDonante,
                nombre = donanteViewModel.nombre,
                apellido1 = donanteViewModel.apellido1,
                apellido2 = donanteViewModel.apellido2,
                telefono = donanteViewModel.telefono,
                email = donanteViewModel.email,
                habilitado = (bool)donanteViewModel.habilitado
            };
            return donante;
        }

        public ActionResult Inicio()
        {
            List<donante> donantes;
            using (UnidadDeTrabajo<donante> Unidad = new UnidadDeTrabajo<donante>(new TPEntities()))
            {
                donantes = Unidad.genericDAL.GetAll().ToList();
            }

            List<DonanteViewModel> lista = new List<DonanteViewModel>();

            foreach (var item in donantes)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(DonanteViewModel donanteViewModel)
        {
            donante donante= this.Convertir(donanteViewModel);

            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new TPEntities()))
            {
                unidad.genericDAL.Add(donante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            donante donante;
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new TPEntities()))
            {
                donante = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(donante));
        }

        [HttpPost]
        public ActionResult Editar(DonanteViewModel donanteViewModel)
        {
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new TPEntities()))
            {
                unidad.genericDAL.Update(this.Convertir(donanteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            donante donante;
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new TPEntities()))
            {
                donante = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(donante));
        }
    }
}