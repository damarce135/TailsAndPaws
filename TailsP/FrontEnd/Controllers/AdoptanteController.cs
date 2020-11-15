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
                habilitado = (bool)adoptante.habilitado,
                idProvincia = (int)adoptante.idProvincia,
                idCanton = (int)adoptante.idCanton,
                idDistrito = (int)adoptante.idDistrito,
                detalleDireccion = adoptante.detalleDireccion
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
                habilitado = (bool)adoptanteViewModel.habilitado,
                idProvincia = (int)adoptanteViewModel.idProvincia,
                idCanton = (int)adoptanteViewModel.idCanton,
                idDistrito = (int)adoptanteViewModel.idDistrito,
                detalleDireccion = adoptanteViewModel.detalleDireccion
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

                using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
                {
                    adoptanteViewModel.provincia = unidad.genericDAL.Get(adoptanteViewModel.idProvincia);
                }

                using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
                {
                    adoptanteViewModel.canton = unidad.genericDAL.Get(adoptanteViewModel.idCanton);
                }

                using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
                {
                    adoptanteViewModel.distrito = unidad.genericDAL.Get(adoptanteViewModel.idDistrito);
                }
                adoptantesVM.Add(adoptanteViewModel);
            }

            return View(adoptantesVM);
        }

        public ActionResult Crear()
        {
            AdoptanteViewModel adoptante = new AdoptanteViewModel { };

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                adoptante.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                adoptante.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                adoptante.distritos = unidad.genericDAL.GetAll().ToList();
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

            provincia provincia;
            List<provincia> provincias;
            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                provincias = unidad.genericDAL.GetAll().ToList();
                provincia = unidad.genericDAL.Get(adoptante.idProvincia);
            }
            provincias.Insert(0, provincia);
            adoptante.provincias = provincias;

            canton canton;
            List<canton> cantones;
            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                cantones = unidad.genericDAL.GetAll().ToList();
                canton = unidad.genericDAL.Get(adoptante.idCanton);
            }
            cantones.Insert(0, canton);
            adoptante.cantones = cantones;

            distrito distrito;
            List<distrito> distritos;
            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                distritos = unidad.genericDAL.GetAll().ToList();
                distrito = unidad.genericDAL.Get(adoptante.idDistrito);
            }
            distritos.Insert(0, distrito);
            adoptante.distritos = distritos;

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

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                adoptante.provincia = unidad.genericDAL.Get(adoptante.idProvincia);
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                adoptante.canton = unidad.genericDAL.Get(adoptante.idCanton);
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                adoptante.distrito = unidad.genericDAL.Get(adoptante.idDistrito);
            }

            return View(adoptante);
        }
    }
}