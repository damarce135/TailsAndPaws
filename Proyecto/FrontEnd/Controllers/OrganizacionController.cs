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
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private OrganizacionViewModel Convertir(organizacion organizacion)
        {
            OrganizacionViewModel organizacionViewModel = new OrganizacionViewModel
            {
                idOrganizacion = (int)organizacion.idOrganizacion,
                tipo = organizacion.tipo,
                nombre = organizacion.nombre,
                telefono = organizacion.telefono,
                email = organizacion.email,
                idDireccion = (int)organizacion.idDireccion,
                descripcion = organizacion.descripcion,
                habilitado = organizacion.habilitado
            };
            return organizacionViewModel;
        }

        private organizacion Convertir(OrganizacionViewModel organizacionViewModel)
        {
            organizacion organizacion = new organizacion
            {
                idOrganizacion = (int)organizacionViewModel.idOrganizacion,
                tipo = organizacionViewModel.tipo,
                nombre = organizacionViewModel.nombre,
                telefono = organizacionViewModel.telefono,
                email = organizacionViewModel.email,
                idDireccion = (int)organizacionViewModel.idDireccion,
                descripcion = organizacionViewModel.descripcion,
                habilitado = organizacionViewModel.habilitado
            };
            return organizacion;
        }

        //Página de Inicio del Mantenimiento de Organizacion
        public ActionResult Inicio()
        {
            List<organizacion> organizaciones;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                organizaciones = unidad.genericDAL.GetAll().ToList();
            }

            List<OrganizacionViewModel> organizacionesVM = new List<OrganizacionViewModel>();

            OrganizacionViewModel organizacionViewModel;
            foreach (var item in organizaciones)
            {
                organizacionViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
                {
                    organizacionViewModel.direccion = unidad.genericDAL.Get(organizacionViewModel.idDireccion);
                }
                organizacionesVM.Add(organizacionViewModel);
            }

            return View(organizacionesVM);
        }

        //Creación de Organizaciones
        public ActionResult Crear()
        {
            OrganizacionViewModel organizacion = new OrganizacionViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
               organizacion.direccion = unidad.genericDAL.Get(organizacion.idDireccion);
            }

            return View(organizacion);
        }

        [HttpPost]
        public ActionResult Crear(organizacion organizacion)
        {
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                unidad.genericDAL.Add(organizacion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar una Organización
        public ActionResult Editar(int id)
        {
            organizacion organizacionEntity;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                organizacionEntity = unidad.genericDAL.Get(id);
            }

            OrganizacionViewModel organizacion= this.Convertir(organizacionEntity);

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
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
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                unidad.genericDAL.Update(organizacion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción de la organización
        public ActionResult Detalles(int id)
        {
            organizacion organizacionEntity;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                organizacionEntity = unidad.genericDAL.Get(id);
            }

            OrganizacionViewModel organizacion = this.Convertir(organizacionEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                organizacion.direccion = unidad.genericDAL.Get(organizacion.idDireccion);
            }

            return View(organizacion);
        }
    }
}