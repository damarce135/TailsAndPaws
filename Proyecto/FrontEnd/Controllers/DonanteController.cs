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
    public class DonanteController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private DonanteViewModel Convertir(donante donante)
        {
            DonanteViewModel donanteViewModel = new DonanteViewModel
            {
                idDonante = (int)donante.idDonante,
                nombre = donante.nombre,
                apellido1 = donante.apellido1,
                apellido2 = donante.apellido2,
                telefono = donante.telefono,
                email = donante.email,
                habilitado = donante.habilitado
            };
            return donanteViewModel;
        }

        private donante Convertir(DonanteViewModel donanteViewModel)
        {
            donante donante = new donante
            {
                idDonante = (int)donanteViewModel.idDonante,
                nombre = donanteViewModel.nombre,
                apellido1 = donanteViewModel.apellido1,
                apellido2 = donanteViewModel.apellido2,
                telefono = donanteViewModel.telefono,
                email = donanteViewModel.email,
                habilitado = donanteViewModel.habilitado
            };
            return donante;
        }

        //Página de Inicio del Mantenimiento de Donante
        public ActionResult Inicio()
        {
            List<donante> donantes;
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new BDContext()))
            {
                donantes = unidad.genericDAL.GetAll().ToList();
            }

            List<DonanteViewModel> lista = new List<DonanteViewModel>();
            foreach (var item in donantes)
            {
                lista.Add(this.Convertir(item));
            }
            return View(lista);
        }

        //Creación de Donantes
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(DonanteViewModel donanteViewModel)
        {
            donante donante = this.Convertir(donanteViewModel);

            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new BDContext()))
            {
                unidad.genericDAL.Add(donante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar Donantes
        public ActionResult Editar(int id)
        {
            donante donante;
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new BDContext()))
            {
                donante = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(donante));
        }

        [HttpPost]
        public ActionResult Editar(DonanteViewModel donanteViewModel)
        {

            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(donanteViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción del donante
        public ActionResult Detalles(int id)
        {
            donante donante;
            using (UnidadDeTrabajo<donante> unidad = new UnidadDeTrabajo<donante>(new BDContext()))
            {
                donante = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(donante));
        }

    }
}