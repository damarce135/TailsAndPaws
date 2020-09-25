using BackEnd.DAL;
using BackEnd.Entities;
using FrontEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace FrontEnd.Controllers
{
    public class ProveedorController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private ProveedorViewModel Convertir(proveedor proveedor)
        {
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel
            {
                idProveedor = (int)proveedor.idProveedor,
                nombreProveedor = proveedor.nombreProveedor,
                idDireccion = (int)proveedor.idDireccion,
                email = proveedor.email,
                telefono = proveedor.telefono,
                habilitado = proveedor.habilitado
            };
            return proveedorViewModel;
        }

        private proveedor Convertir(ProveedorViewModel proveedorViewModel)
        {
            proveedor proveedor = new proveedor
            {
                idProveedor = (int)proveedorViewModel.idProveedor,
                nombreProveedor = proveedorViewModel.nombreProveedor,
                idDireccion = (int)proveedorViewModel.idDireccion,
                email = proveedorViewModel.email,
                telefono = proveedorViewModel.telefono,
                habilitado = proveedorViewModel.habilitado
            };
            return proveedor;
        }

        //Página de Inicio del Mantenimiento de Proveedor
        public ActionResult Inicio()
        {
            List<proveedor> proveedores;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new BDContext()))
            {
                proveedores = unidad.genericDAL.GetAll().ToList();
            }

            List<ProveedorViewModel> proveedoresVM = new List<ProveedorViewModel>();

            ProveedorViewModel proveedorViewModel;
            foreach (var item in proveedores)
            {
                proveedorViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
                {
                    proveedorViewModel.direccion = unidad.genericDAL.Get(proveedorViewModel.idDireccion);
                }
                proveedoresVM.Add(proveedorViewModel);
            }

            return View(proveedoresVM);
        }

        //Creación de Proveedores
        public ActionResult Crear()
        {
            ProveedorViewModel proveedor = new ProveedorViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                proveedor.direccion = unidad.genericDAL.Get(proveedor.idDireccion);
            }

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Crear(proveedor proveedor)
        {
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new BDContext()))
            {
                unidad.genericDAL.Add(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar un Proveedor
        public ActionResult Editar(int id)
        {
            proveedor proveedorEntity;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new BDContext()))
            {
                proveedorEntity = unidad.genericDAL.Get(id);
            }

           ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                direcciones = unidad.genericDAL.GetAll().ToList();
                direccion = unidad.genericDAL.Get(proveedor.idDireccion);
            }
            direcciones.Insert(0, direccion);
            proveedor.direcciones = direcciones;

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Editar(proveedor proveedor)
        {
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new BDContext()))
            {
                unidad.genericDAL.Update(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción del proveedor
        public ActionResult Detalles(int id)
        {
            proveedor proveedorEntity;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new BDContext()))
            {
                proveedorEntity = unidad.genericDAL.Get(id);
            }

            ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new BDContext()))
            {
                proveedor.direccion = unidad.genericDAL.Get(proveedor.idDireccion);
            }

            return View(proveedor);
        }
    }
}