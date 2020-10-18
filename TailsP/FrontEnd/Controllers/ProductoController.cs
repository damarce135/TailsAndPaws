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
    public class ProductoController : Controller
    {
        private ProductoViewModel Convertir(producto producto)
        {
            ProductoViewModel productoViewModel = new ProductoViewModel
            {
                idProducto = producto.idProducto,
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                fechaIngreso = (DateTime)producto.fechaIngreso,
                cantidad = (int)producto.cantidad,
                habilitado = (bool)producto.habilitado
            };
            return productoViewModel;
        }

        private producto Convertir(ProductoViewModel productoViewModel)
        {
            producto producto = new producto
            {
                idProducto = productoViewModel.idProducto,
                nombre = productoViewModel.nombre,
                descripcion = productoViewModel.descripcion,
                fechaIngreso = (DateTime)productoViewModel.fechaIngreso,
                cantidad = (int)productoViewModel.cantidad,
                habilitado = (bool)productoViewModel.habilitado
            };
            return producto;
        }

        public ActionResult Inicio()
        {
            List<producto> productos;
            using (UnidadDeTrabajo<producto> Unidad = new UnidadDeTrabajo<producto>(new TPEntities()))
            {
                productos = Unidad.genericDAL.GetAll().ToList();
            }

            List<ProductoViewModel> lista = new List<ProductoViewModel>();

            foreach (var item in productos)
            {
                lista.Add(this.Convertir(item));
            }

            return View(lista);
        }

        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ProductoViewModel productoViewModel)
        {
            producto producto = this.Convertir(productoViewModel);

            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new TPEntities()))
            {
                unidad.genericDAL.Add(producto);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            producto producto;
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new TPEntities()))
            {
                producto = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(producto));
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel productoViewModel)
        {
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new TPEntities()))
            {
                unidad.genericDAL.Update(this.Convertir(productoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            producto producto;
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new TPEntities()))
            {
                producto = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(producto));
        }
    }
}