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
    public class OrganizacionController : Controller
    {
        private OrganizacionViewModel Convertir(organizacion organizacion)
        {
            OrganizacionViewModel organizacionViewModel = new OrganizacionViewModel
            {
                idOrganizacion = organizacion.idOrganizacion,
                tipo = organizacion.tipo,
                nombre = organizacion.nombre,
                telefono = organizacion.telefono,
                email = organizacion.email,
                descripcion = organizacion.descripcion,
                habilitado = (bool)organizacion.habilitado,
                idProvincia = (int)organizacion.idProvincia,
                idCanton = (int)organizacion.idCanton,
                idDistrito = (int)organizacion.idDistrito,
                detalleDireccion = organizacion.detalleDireccion
            };
            return organizacionViewModel;
        }

        private organizacion Convertir(OrganizacionViewModel organizacionViewModel)
        {
            organizacion organizacion = new organizacion
            {
                idOrganizacion = organizacionViewModel.idOrganizacion,
                tipo = organizacionViewModel.tipo,
                nombre = organizacionViewModel.nombre,
                telefono = organizacionViewModel.telefono,
                email = organizacionViewModel.email,
                descripcion = organizacionViewModel.descripcion,
                habilitado = (bool)organizacionViewModel.habilitado,
                idProvincia = (int)organizacionViewModel.idProvincia,
                idCanton = (int)organizacionViewModel.idCanton,
                idDistrito = (int)organizacionViewModel.idDistrito,
                detalleDireccion = organizacionViewModel.detalleDireccion
            };
            return organizacion;
        }

        public ActionResult Inicio()
        {
            List<organizacion> organizaciones;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new TPEntities()))
            {
                organizaciones = unidad.genericDAL.GetAll().ToList();
            }

            List<OrganizacionViewModel> organizacionesVM = new List<OrganizacionViewModel>();

            OrganizacionViewModel organizacionViewModel;
            foreach (var item in organizaciones)
            {
                organizacionViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
                {
                    organizacionViewModel.provincia = unidad.genericDAL.Get(organizacionViewModel.idProvincia);
                }

                using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
                {
                    organizacionViewModel.canton = unidad.genericDAL.Get(organizacionViewModel.idCanton);
                }

                using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
                {
                    organizacionViewModel.distrito = unidad.genericDAL.Get(organizacionViewModel.idDistrito);
                }
                organizacionesVM.Add(organizacionViewModel);
            }

            return View(organizacionesVM);
        }

        public ActionResult Crear()
        {
            OrganizacionViewModel organizacion = new OrganizacionViewModel { };

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                organizacion.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                organizacion.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                organizacion.distritos = unidad.genericDAL.GetAll().ToList();
            }

            return View(organizacion);
        }

        [HttpPost]
        public ActionResult Crear(organizacion organizacion)
        {
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new TPEntities()))
            {
                unidad.genericDAL.Add(organizacion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            organizacion organizacionEntity;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new TPEntities()))
            {
                organizacionEntity = unidad.genericDAL.Get(id);
            }

           OrganizacionViewModel organizacion = this.Convertir(organizacionEntity);

            provincia provincia;
            List<provincia> provincias;
            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                provincias = unidad.genericDAL.GetAll().ToList();
                provincia = unidad.genericDAL.Get(organizacion.idProvincia);
            }
            provincias.Insert(0, provincia);
            organizacion.provincias = provincias;

            canton canton;
            List<canton> cantones;
            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                cantones = unidad.genericDAL.GetAll().ToList();
                canton = unidad.genericDAL.Get(organizacion.idCanton);
            }
            cantones.Insert(0, canton);
            organizacion.cantones = cantones;

            distrito distrito;
            List<distrito> distritos;
            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                distritos = unidad.genericDAL.GetAll().ToList();
                distrito = unidad.genericDAL.Get(organizacion.idDistrito);
            }
            distritos.Insert(0, distrito);
            organizacion.distritos = distritos;

            return View(organizacion);
        }

        [HttpPost]
        public ActionResult Editar(organizacion organizacion)
        {
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new TPEntities()))
            {
                unidad.genericDAL.Update(organizacion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            organizacion organizacionEntity;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new TPEntities()))
            {
                organizacionEntity = unidad.genericDAL.Get(id);
            }

            OrganizacionViewModel organizacion = this.Convertir(organizacionEntity);

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                organizacion.provincia = unidad.genericDAL.Get(organizacion.idProvincia);
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                organizacion.canton = unidad.genericDAL.Get(organizacion.idCanton);
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                organizacion.distrito = unidad.genericDAL.Get(organizacion.idDistrito);
            }

            return View(organizacion);
        }
    }
}