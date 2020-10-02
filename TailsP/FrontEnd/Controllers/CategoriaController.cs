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
        
        public ActionResult Inicio()
        {
            List<categoria> categorias;
            using (UnidadDeTrabajo<categoria> Unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                categorias = Unidad.genericDAL.GetAll().ToList();
            }

            List<CategoriaViewModel> lista = new List<CategoriaViewModel>();

            foreach (var item in categorias)
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
        public ActionResult Crear(CategoriaViewModel categoriaViewModel)
        {
            categoria categoria = this.Convertir(categoriaViewModel);

            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                unidad.genericDAL.Add(categoria);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            categoria categoria;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                categoria = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(categoria));
        }

        [HttpPost]
        public ActionResult Editar(CategoriaViewModel categoriaViewModel)
        {
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                unidad.genericDAL.Update(this.Convertir(categoriaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            categoria categoria;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                categoria = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(categoria));
        }

        public ActionResult Eliminar(int id)
        {
            categoria categoria;
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                categoria = unidad.genericDAL.Get(id);
            }

            return View(this.Convertir(categoria));
        }

        [HttpPost]
        public ActionResult Eliminar(CategoriaViewModel categoriaViewModel)
        {
            using (UnidadDeTrabajo<categoria> unidad = new UnidadDeTrabajo<categoria>(new TPEntities()))
            {
                unidad.genericDAL.Remove(this.Convertir(categoriaViewModel));
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }
    }
}
