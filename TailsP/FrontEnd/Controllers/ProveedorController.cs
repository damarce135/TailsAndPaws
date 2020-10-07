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
    public class ProveedorController : Controller
    {
        private ProveedorViewModel Convertir(proveedor proveedor)
        {
            ProveedorViewModel proveedorViewModel = new ProveedorViewModel
            {
                idProveedor = proveedor.idProveedor,
                nombreProveedor = proveedor.nombreProveedor,
                idDireccion = (int)proveedor.idDireccion,
                email = proveedor.email,
                telefono = proveedor.telefono,
                habilitado = (bool)proveedor.habilitado
            };
            return proveedorViewModel;
        }

        private proveedor Convertir(ProveedorViewModel proveedorViewModel)
        {
            proveedor proveedor = new proveedor
            {
                idProveedor = proveedorViewModel.idProveedor,
                nombreProveedor = proveedorViewModel.nombreProveedor,
                idDireccion = (int)proveedorViewModel.idDireccion,
                email = proveedorViewModel.email,
                telefono = proveedorViewModel.telefono,
                habilitado = (bool)proveedorViewModel.habilitado
            };
            return proveedor;
        }

        public ActionResult Inicio()
        {
            List<proveedor> proveedores;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                proveedores = unidad.genericDAL.GetAll().ToList();
            }

            List<ProveedorViewModel> proveedoresVM = new List<ProveedorViewModel>();

            ProveedorViewModel proveedorViewModel;
            foreach (var item in proveedores)
            {
                proveedorViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
                {
                    proveedorViewModel.direccion = unidad.genericDAL.Get(proveedorViewModel.idDireccion);
                }
                proveedoresVM.Add(proveedorViewModel);
            }

            return View(proveedoresVM);
        }

        public ActionResult Crear()
        {
            ProveedorViewModel proveedor = new ProveedorViewModel { };

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                proveedor.direcciones = unidad.genericDAL.GetAll().ToList();
            }

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Crear(proveedor proveedor)
        {
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                unidad.genericDAL.Add(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            proveedor proveedorEntity;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                proveedorEntity = unidad.genericDAL.Get(id);
            }

            ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

            direccion direccion;
            List<direccion> direcciones;
            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
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
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                unidad.genericDAL.Update(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            proveedor proveedorEntity;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                proveedorEntity = unidad.genericDAL.Get(id);
            }

            ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                proveedor.direccion = unidad.genericDAL.Get(proveedor.idDireccion);
            }

            return View(proveedor);
        }

        public ActionResult Eliminar(int id)
        {
            proveedor proveedorEntity;
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                proveedorEntity = unidad.genericDAL.Get(id);
            }

            ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

            using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
            {
                proveedor.direccion = unidad.genericDAL.Get(proveedor.idDireccion);
            }

            return View(proveedor);
        }

        [HttpPost]
        public ActionResult Eliminar(proveedor proveedor)
        {
            using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
            {
                unidad.genericDAL.Remove(proveedor);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }
    }
}