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
    [Authorize(Roles = "Seller")]
    public class AdopcionController : Controller
    {
        private AdopcionViewModel Convertir(adopcion adopcion)
        {
            AdopcionViewModel adopcionViewModel = new AdopcionViewModel
            {
                idAdopcion = adopcion.idAdopcion,
                idAnimal = (int)adopcion.idAnimal,
                idAdoptante = (int)adopcion.idAdoptante,
                fechaAdopcion = (DateTime)adopcion.fechaAdopcion,
                fechaSeguimiento = (DateTime)adopcion.fechaSeguimiento,
                habilitado = (bool)adopcion.habilitado
            };
            return adopcionViewModel;
        }

        private adopcion Convertir(AdopcionViewModel adopcionViewModel)
        {
            adopcion adopcion= new adopcion
            {
                idAdopcion = adopcionViewModel.idAdopcion,
                idAnimal = (int)adopcionViewModel.idAnimal,
                idAdoptante = (int)adopcionViewModel.idAdoptante,
                fechaAdopcion = (DateTime)adopcionViewModel.fechaAdopcion,
                fechaSeguimiento = (DateTime)adopcionViewModel.fechaSeguimiento,
                habilitado = (bool)adopcionViewModel.habilitado
            };
            return adopcion;
        }

        public ActionResult Inicio()
        {
            List<adopcion> adopciones;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new TPEntities()))
            {
                using (TPEntities dbContext = new TPEntities())
                {
                    dbContext.Database.Exists();
                }
                adopciones = unidad.genericDAL.GetAll().ToList();
            }

            List<AdopcionViewModel> adopcionesVM = new List<AdopcionViewModel>();

            AdopcionViewModel adopcionViewModel;
            foreach (var item in adopciones)
            {
                adopcionViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new TPEntities()))
                {
                    adopcionViewModel.animal = unidad.genericDAL.Get(adopcionViewModel.idAnimal);
                }
                
                using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
                {
                    adopcionViewModel.adoptante = unidad.genericDAL.Get(adopcionViewModel.idAdoptante);
                }
                adopcionesVM.Add(adopcionViewModel);
            }

            return View(adopcionesVM);
        }

        public ActionResult Crear()
        {
            AdopcionViewModel adopcion = new AdopcionViewModel { };

            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new TPEntities()))
            {
                adopcion.animales = unidad.genericDAL.GetAll().ToList();
            }

            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adopcion.adoptantes = unidad.genericDAL.GetAll().ToList();
            }

            return View(adopcion);
        }

        [HttpPost]
        public ActionResult Crear(adopcion adopcion)
        {
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new TPEntities()))
            {
                unidad.genericDAL.Add(adopcion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Editar(int id)
        {
            adopcion adopcionEntity;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new TPEntities()))
            {
                adopcionEntity = unidad.genericDAL.Get(id);
            }

            AdopcionViewModel adopcion = this.Convertir(adopcionEntity);

            animal animal;
            List<animal> animales;
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new TPEntities()))
            {
                animales = unidad.genericDAL.GetAll().ToList();
                animal = unidad.genericDAL.Get(adopcion.idAnimal);
            }
            animales.Insert(0, animal);
            adopcion.animales = animales;

            adoptante adoptante;
            List<adoptante> adoptantes;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adoptantes = unidad.genericDAL.GetAll().ToList();
                adoptante = unidad.genericDAL.Get(adopcion.idAdoptante);
            }
            adoptantes.Insert(0, adoptante);
            adopcion.adoptantes = adoptantes;

            return View(adopcion);
        }

        [HttpPost]
        public ActionResult Editar(adopcion adopcion)
        {
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new TPEntities()))
            {
                unidad.genericDAL.Update(adopcion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        public ActionResult Detalles(int id)
        {
            adopcion adopcionEntity;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new TPEntities()))
            {
                adopcionEntity = unidad.genericDAL.Get(id);
            }

            AdopcionViewModel adopcion = this.Convertir(adopcionEntity);

            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new TPEntities()))
            {
                adopcion.animal = unidad.genericDAL.Get(adopcion.idAnimal);
            }

            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new TPEntities()))
            {
                adopcion.adoptante = unidad.genericDAL.Get(adopcion.idAdoptante);
            }

            return View(adopcion);
        }
    }
}