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
                idDireccion = (int)organizacion.idDireccion,
                descripcion = organizacion.descripcion,
                habilitado = (bool)organizacion.habilitado
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
                idDireccion = (int)organizacionViewModel.idDireccion,
                descripcion = organizacionViewModel.descripcion,
                habilitado = (bool)organizacionViewModel.habilitado
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

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
                {
                    organizacionViewModel.direccion = unidad.genericDAL.Get(organizacionViewModel.idDireccion);
                }
                organizacionesVM.Add(organizacionViewModel);
            }

            return View(organizacionesVM);
        }

        public ActionResult Crear()
        {
            OrganizacionViewModel organizacion = new OrganizacionViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                organizacion.direcciones = unidad.genericDAL.GetAll().ToList();
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

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                direcciones = unidad.genericDAL.GetAll().ToList();
                direccion = unidad.genericDAL.Get(organizacion.idDireccion);
            }
            direcciones.Insert(0, direccion);
            organizacion.direcciones = direcciones;

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

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                organizacion.direccion = unidad.genericDAL.Get(organizacion.idDireccion);
            }

            return View(organizacion);
        }
    }
}