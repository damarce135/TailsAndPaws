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
        private AdoptanteViewModel Convertir(adoptante adoptante)
        {
            AdoptanteViewModel adoptanteViewModel = new AdoptanteViewModel
            {
                idAdoptante = adoptante.idAdoptante,
                cedula = adoptante.cedula,
                nombre = adoptante.nombre,
                apellido1 = adoptante.apellido1,
                apellido2 = adoptante.apellido2,
                email = adoptante.email,
                telefono = adoptante.telefono,
                idDireccion = (int)adoptante.idDireccion,
                habilitado = (bool)adoptante.habilitado
            };
            return adoptanteViewModel;
        }

        private adoptante Convertir(AdoptanteViewModel adoptanteViewModel)
        {
            adoptante adoptante = new adoptante
            {
                idAdoptante = adoptanteViewModel.idAdoptante,
                cedula = adoptanteViewModel.cedula,
                nombre = adoptanteViewModel.nombre,
                apellido1 = adoptanteViewModel.apellido1,
                apellido2 = adoptanteViewModel.apellido2,
                email = adoptanteViewModel.email,
                telefono = adoptanteViewModel.telefono,
                idDireccion = (int)adoptanteViewModel.idDireccion,
                habilitado = (bool)adoptanteViewModel.habilitado
            };
            return adoptante;
        }

        public ActionResult Inicio()
        {
            List<adoptante> adoptantes;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adoptantes = unidad.genericDAL.GetAll().ToList();
            }

            List<AdoptanteViewModel> adoptantesVM = new List<AdoptanteViewModel>();

            AdoptanteViewModel adoptanteViewModel;
            foreach (var item in adoptantes)
            {
                adoptanteViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
                {
                    adoptanteViewModel.direccion = unidad.genericDAL.Get(adoptanteViewModel.idDireccion);
                }
                adoptantesVM.Add(adoptanteViewModel);
            }

            return View(adoptantesVM);
        }

        public ActionResult Crear()
        {
            AdoptanteViewModel adoptante = new AdoptanteViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                adoptante.direcciones = unidad.genericDAL.GetAll().ToList();
            }

            return View(adoptante);
        }

        [HttpPost]
        public ActionResult Crear(adoptante adoptante)
        {
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                unidad.genericDAL.Add(adoptante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            adoptante adoptanteEntity;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adoptanteEntity = unidad.genericDAL.Get(id);
            }

            AdoptanteViewModel adoptante = this.Convertir(adoptanteEntity);

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
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
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                unidad.genericDAL.Update(adoptante);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
           adoptante adoptanteEntity;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adoptanteEntity = unidad.genericDAL.Get(id);
            }

            AdoptanteViewModel adoptante = this.Convertir(adoptanteEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                adoptante.direccion = unidad.genericDAL.Get(adoptante.idDireccion);
            }

            return View(adoptante);
        }
    }
}