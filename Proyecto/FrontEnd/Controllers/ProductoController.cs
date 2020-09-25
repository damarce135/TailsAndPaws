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
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private ProductoViewModel Convertir(producto producto)
        {
            ProductoViewModel productoViewModel = new ProductoViewModel
            {
                idProducto = (int)producto.idProducto,
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                fechaIngreso = producto.fechaIngreso,
                cantidad = (int)producto.cantidad,
                habilitado = producto.habilitado
            };
            return productoViewModel;
        }

        private producto Convertir(ProductoViewModel productoViewModel)
        {
            producto producto = new producto
            {
                idProducto = (int)productoViewModel.idProducto,
                nombre = productoViewModel.nombre,
                descripcion = productoViewModel.descripcion,
                fechaIngreso = productoViewModel.fechaIngreso,
                cantidad = (int)productoViewModel.cantidad,
                habilitado = productoViewModel.habilitado
            };
            return producto;
        }

        //Página de Inicio del Mantenimiento de Producto
        public ActionResult Inicio()
        {
            List<producto> productos;
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new BDContext()))
            {
                productos = unidad.genericDAL.GetAll().ToList();
            }

            List<ProductoViewModel> lista = new List<ProductoViewModel>();
            foreach (var item in productos)
            {
                lista.Add(this.Convertir(item));
            }
            return View(lista);
        }

        //Creación de Productos
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(ProductoViewModel productoViewModel)
        {
            producto producto = this.Convertir(productoViewModel);

            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new BDContext()))
            {
                unidad.genericDAL.Add(producto);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar Productos
        public ActionResult Editar(int id)
        {
            producto producto;
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new BDContext()))
            {
                producto = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(producto));
        }

        [HttpPost]
        public ActionResult Editar(ProductoViewModel productoViewModel)
        {
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(productoViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción del producto
        public ActionResult Detalles(int id)
        {
            producto producto;
            using (UnidadDeTrabajo<producto> unidad = new UnidadDeTrabajo<producto>(new BDContext()))
            {
                producto = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(producto));
        }
    }
}