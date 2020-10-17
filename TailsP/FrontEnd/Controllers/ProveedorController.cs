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
                email = proveedor.email,
                telefono = proveedor.telefono,
                habilitado = (bool)proveedor.habilitado,
                idProvincia = (int)proveedor.idProvincia,
                idCanton = (int)proveedor.idCanton,
                idDistrito = (int)proveedor.idDistrito,
                detalleDireccion = proveedor.detalleDireccion
            };
            return proveedorViewModel;
        }

        private proveedor Convertir(ProveedorViewModel proveedorViewModel)
        {
            proveedor proveedor = new proveedor
            {
                idProveedor = proveedorViewModel.idProveedor,
                nombreProveedor = proveedorViewModel.nombreProveedor,
                email = proveedorViewModel.email,
                telefono = proveedorViewModel.telefono,
                habilitado = (bool)proveedorViewModel.habilitado,
                idProvincia = (int)proveedorViewModel.idProvincia,
                idCanton = (int)proveedorViewModel.idCanton,
                idDistrito = (int)proveedorViewModel.idDistrito,
                detalleDireccion = proveedorViewModel.detalleDireccion
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

                using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
                {
                    proveedorViewModel.provincia = unidad.genericDAL.Get(proveedorViewModel.idProvincia);
                }

                using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
                {
                    proveedorViewModel.canton = unidad.genericDAL.Get(proveedorViewModel.idCanton);
                }

                using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
                {
                    proveedorViewModel.distrito = unidad.genericDAL.Get(proveedorViewModel.idDistrito);
                }
                proveedoresVM.Add(proveedorViewModel);
            }

            return View(proveedoresVM);
        }

        public ActionResult Crear()
        {
            ProveedorViewModel proveedor = new ProveedorViewModel { };

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                proveedor.provincias = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                proveedor.cantones = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                proveedor.distritos = unidad.genericDAL.GetAll().ToList();
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

            provincia provincia;
            List<provincia> provincias;
            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                provincias = unidad.genericDAL.GetAll().ToList();
                provincia = unidad.genericDAL.Get(proveedor.idProvincia);
            }
            provincias.Insert(0, provincia);
            proveedor.provincias = provincias;

            canton canton;
            List<canton> cantones;
            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                cantones = unidad.genericDAL.GetAll().ToList();
                canton = unidad.genericDAL.Get(proveedor.idCanton);
            }
            cantones.Insert(0, canton);
            proveedor.cantones = cantones;

            distrito distrito;
            List<distrito> distritos;
            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                distritos = unidad.genericDAL.GetAll().ToList();
                distrito = unidad.genericDAL.Get(proveedor.idDistrito);
            }
            distritos.Insert(0, distrito);
            proveedor.distritos = distritos;

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

            using (UnidadDeTrabajo<provincia> unidad = new UnidadDeTrabajo<provincia>(new TPEntities()))
            {
                proveedor.provincia = unidad.genericDAL.Get(proveedor.idProvincia);
            }

            using (UnidadDeTrabajo<canton> unidad = new UnidadDeTrabajo<canton>(new TPEntities()))
            {
                proveedor.canton = unidad.genericDAL.Get(proveedor.idCanton);
            }

            using (UnidadDeTrabajo<distrito> unidad = new UnidadDeTrabajo<distrito>(new TPEntities()))
            {
                proveedor.distrito = unidad.genericDAL.Get(proveedor.idDistrito);
            }

            return View(proveedor);
        }

        //public ActionResult Eliminar(int id)
        //{
        //    proveedor proveedorEntity;
        //    using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
        //    {
        //        proveedorEntity = unidad.genericDAL.Get(id);
        //    }

        //    ProveedorViewModel proveedor = this.Convertir(proveedorEntity);

        //    using (UnidadDeTrabajo<direccion> unidad = new UnidadDeTrabajo<direccion>(new TPEntities()))
        //    {
        //        proveedor.direccion = unidad.genericDAL.Get(proveedor.idDireccion);
        //    }

        //    return View(proveedor);
        //}

        //[HttpPost]
        //public ActionResult Eliminar(proveedor proveedor)
        //{
        //    using (UnidadDeTrabajo<proveedor> unidad = new UnidadDeTrabajo<proveedor>(new TPEntities()))
        //    {
        //        unidad.genericDAL.Remove(proveedor);
        //        unidad.Complete();
        //    }

        //    return RedirectToAction("Inicio");
        //}
    }
}