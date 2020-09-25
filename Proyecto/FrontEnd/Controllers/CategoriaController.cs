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
    public class CategoriaController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private CategoriaViewModel Convertir(categoria categoria)
        {
            CategoriaViewModel categoriaViewModel = new CategoriaViewModel
            {
                idCategoria = categoria.idCategoria,
                nombreCategoria = categoria.nombreCategoria
            };
            return categoriaViewModel;
        }

        private categoria Convertir(CategoriaViewModel categoriaViewModel)
        {
            categoria categoria = new categoria
            {
                idCategoria = categoriaViewModel.idCategoria,
                nombreCategoria = categoriaViewModel.nombreCategoria
            };
            return categoria;
        }

        //Página de Inicio del Mantenimiento de Categoria
        public ActionResult Inicio()
        {
            List<categoria> categorias;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new BDContext()))
            {
                categorias = unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();
            foreach (var item in categorias)
            {
                lista.Add(this.Convertir(item));
            }
            return View(lista);
        }

        //Creación de Categorías
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(CategoriaViewModel categoriaViewModel)
        {
            categoria categoria = this.Convertir(categoriaViewModel);

            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new BDContext()))
            {
                unidad.genericDAL.Add(categoria);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar Categorías
        public ActionResult Editar(int id)
        {
            categoria categoria;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new BDContext()))
            {
                categoria = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(categoria));
        }


        [HttpPost]
        public ActionResult Editar(CategoriaViewModel categoriaViewModel)
        {

            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new BDContext()))
            {
                unidad.genericDAL.Update(this.Convertir(categoriaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción de la categoría
        public ActionResult Detalles(int id)
        {
            categoria categoria;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new BDContext()))
            {
                categoria = unidad.genericDAL.Get(id);

            }

            return View(this.Convertir(categoria));
        }
    }
}