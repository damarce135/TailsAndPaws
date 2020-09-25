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
    public class AdoptanteController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private AdoptanteViewModel Convertir(adoptante adoptante)
        {
            AdoptanteViewModel adoptanteViewModel = new AdoptanteViewModel
            {
                idAdoptante = (int)adoptante.idAdoptante,
                cedula = adoptante.cedula,
                nombre = adoptante.nombre,
                apellido1 = adoptante.apellido1,
                apellido2 = adoptante.apellido2,
                email = adoptante.email,
                telefono = adoptante.telefono,
                idDireccion = (int)adoptante.idDireccion,
                habilitado = adoptante.habilitado
            };
            return adoptanteViewModel;
        }

        private adoptante Convertir(AdoptanteViewModel adoptanteViewModel)
        {
            adoptante adoptante = new adoptante
            {
                idAdoptante = (int)adoptanteViewModel.idAdoptante,
                cedula = adoptanteViewModel.cedula,
                nombre = adoptanteViewModel.nombre,
                apellido1 = adoptanteViewModel.apellido1,
                apellido2 = adoptanteViewModel.apellido2,
                email = adoptanteViewModel.email,
                telefono = adoptanteViewModel.telefono,
                idDireccion = (int)adoptanteViewModel.idDireccion,
                habilitado = adoptanteViewModel.habilitado
            };
            return adoptante; 
        }

        //Página de Inicio del Mantenimiento de Adoptante
        public ActionResult Inicio()
        {
            List<adoptante> adoptantes;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                adoptantes = unidad.genericDAL.GetAll().ToList();
            }

            List<AdoptanteViewModel> adoptantesVM = new List<AdoptanteViewModel>();

            AdoptanteViewModel adoptanteViewModel;
            foreach (var item in adoptantes)
            {
                adoptanteViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
                {
                    adoptanteViewModel.direccion = unidad.genericDAL.Get(adoptanteViewModel.idDireccion);
                }
                adoptantesVM.Add(adoptanteViewModel);
            }

            return View(adoptantesVM);
        }

        //Creación de Adoptantes
        public ActionResult Crear()
        {
            AdoptanteViewModel adoptante = new AdoptanteViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                adoptante.direccion = unidad.genericDAL.Get(adoptante.idDireccion);
            }

            return View(adoptante);
        }

        [HttpPost]
        public ActionResult Crear(adoptante adoptante)
        {
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                unidad.genericDAL.Add(adoptante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar un Adoptante
        public ActionResult Editar(int id)
        {
            adoptante adoptanteEntity;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                adoptanteEntity = unidad.genericDAL.Get(id);
            }

            AdoptanteViewModel adoptante = this.Convertir(adoptanteEntity);

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                direcciones = unidad.genericDAL.GetAll().ToList();
                direccion = unidad.genericDAL.Get(adoptante.idDireccion);
            }
            direcciones.Insert(0, direccion);
            adoptante.direcciones = direcciones;

            return View(adoptante);
        }

        [HttpPost]
        public ActionResult Editar(adoptante adoptante)
        {
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                unidad.genericDAL.Update(adoptante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción del adoptante
        public ActionResult Detalles(int id)
        {
            adoptante adoptanteEntity;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                adoptanteEntity = unidad.genericDAL.Get(id);
            }

            AdoptanteViewModel adoptante = this.Convertir(adoptanteEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                adoptante.direccion = unidad.genericDAL.Get(adoptante.idDireccion);
            }

            return View(adoptante);
        }

    }
}