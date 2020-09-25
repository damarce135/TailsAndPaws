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
    public class AdopcionController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private AdopcionViewModel Convertir(adopcion adopcion)
        {
            AdopcionViewModel adopcionViewModel = new AdopcionViewModel
            {
                idAdopcion = (int)adopcion.idAdopcion,
                idAnimal = (int)adopcion.idAnimal,
                idAdoptante = (int)adopcion.idAdoptante,
                fechaAdopcion = adopcion.fechaAdopcion,
                fechaSeguimiento = adopcion.fechaSeguimiento,
                habilitado = adopcion.habilitado
            };
            return adopcionViewModel;
        }

        private adopcion Convertir(AdopcionViewModel adopcionViewModel)
        {
            adopcion adopcion = new adopcion
            {
                idAdopcion = (int)adopcionViewModel.idAdopcion,
                idAnimal = (int)adopcionViewModel.idAnimal,
                idAdoptante = (int)adopcionViewModel.idAdoptante,
                fechaAdopcion = adopcionViewModel.fechaAdopcion,
                fechaSeguimiento = adopcionViewModel.fechaSeguimiento,
                habilitado = adopcionViewModel.habilitado
            };
            return adopcion;
        }

        //Página de Inicio del Mantenimiento de Adopción
        public ActionResult Inicio()
        {
            List<adopcion> adopciones;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new BDContext()))
            {
                adopciones = unidad.genericDAL.GetAll().ToList();
            }

            List<AdopcionViewModel> adopcionesVM = new List<AdopcionViewModel>();

            AdopcionViewModel adopcionViewModel;
            foreach (var item in adopciones)
            {
                adopcionViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
                {
                    adopcionViewModel.animal = unidad.genericDAL.Get(adopcionViewModel.idAnimal);
                }
                adopcionesVM.Add(adopcionViewModel);

                using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
                {
                    adopcionViewModel.adoptante = unidad.genericDAL.Get(adopcionViewModel.idAdoptante);
                }
                adopcionesVM.Add(adopcionViewModel);

            }

            return View(adopcionesVM);
        }

        //Creación de Adopciones
        public ActionResult Crear()
        {
            AdopcionViewModel adopcion = new AdopcionViewModel { };

            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                adopcion.animal = unidad.genericDAL.Get(adopcion.idAnimal);
            }

            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                adopcion.adoptante = unidad.genericDAL.Get(adopcion.idAdoptante);
            }

            return View(adopcion);
        }

        [HttpPost]
        public ActionResult Crear(adopcion adopcion)
        {
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new BDContext()))
            {
                unidad.genericDAL.Add(adopcion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar Adopciones
        public ActionResult Editar(int id)
        {
            adopcion adopcionEntity;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new BDContext()))
            {
                adopcionEntity = unidad.genericDAL.Get(id);
            }

            AdopcionViewModel adopcion = this.Convertir(adopcionEntity);

            animal animal;
            List<animal> animales;
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                animales = unidad.genericDAL.GetAll().ToList();
                animal = unidad.genericDAL.Get(adopcion.idAnimal);
            }
            animales.Insert(0, animal);
            adopcion.animales = animales;

            adoptante adoptante;
            List<adoptante> adoptantes;
            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
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
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new BDContext()))
            {
                unidad.genericDAL.Update(adopcion);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción de la adopción
        public ActionResult Detalles(int id)
        {
            adopcion adopcionEntity;
            using (UnidadDeTrabajo<adopcion> unidad = new UnidadDeTrabajo<adopcion>(new BDContext()))
            {
                adopcionEntity = unidad.genericDAL.Get(id);
            }

            AdopcionViewModel adopcion = this.Convertir(adopcionEntity);

            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                adopcion.animal = unidad.genericDAL.Get(adopcion.idAnimal);
            }

            using (UnidadDeTrabajo<adoptante> unidad = new UnidadDeTrabajo<adoptante>(new BDContext()))
            {
                adopcion.adoptante = unidad.genericDAL.Get(adopcion.idAdoptante);
            }

            return View(adopcion);
        }
    }
}