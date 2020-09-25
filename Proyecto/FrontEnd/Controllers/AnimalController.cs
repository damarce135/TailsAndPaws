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
    public class AnimalController : Controller
    {
        /*Se convierten los datos al modelo o a la tabla/clase 
         * (si es necesario), para la lectura de datos*/
        private AnimalViewModel Convertir(animal animal)
        {
            AnimalViewModel animalViewModel = new AnimalViewModel
            {
                idAnimal = (int)animal.idAnimal,
                nombre = animal.nombre,
                sexo = animal.sexo,
                raza = animal.raza,
                castrado = animal.castrado,
                edad = animal.edad,
                fechaIngreso = animal.fechaIngreso,
                idGSanguineo = (int)animal.idGSanguineo,
                idOrganizacion = (int)animal.idOrganizacion,
                habilitado = animal.habilitado
            };
            return animalViewModel;
        }

        private animal Convertir(AnimalViewModel animalViewModel)
        {
            animal animal = new animal
            {
                idAnimal = (int)animalViewModel.idAnimal,
                nombre = animalViewModel.nombre,
                sexo = animalViewModel.sexo,
                raza = animalViewModel.raza,
                castrado = animalViewModel.castrado,
                edad = animalViewModel.edad,
                fechaIngreso = animalViewModel.fechaIngreso,
                idGSanguineo = (int)animalViewModel.idGSanguineo,
                idOrganizacion = (int)animalViewModel.idOrganizacion,
                habilitado = animalViewModel.habilitado
            };
            return animal;
        }

        //Página de Inicio del Mantenimiento de Animal
        public ActionResult Inicio()
        {
            List<animal> animales;
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                animales = unidad.genericDAL.GetAll().ToList();
            }

            List<AnimalViewModel> animalesVM = new List<AnimalViewModel>();

            AnimalViewModel animalViewModel;
            foreach (var item in animales)
            {
                animalViewModel = this.Convertir(item);

                using (UnidadDeTrabajo<grupoSanguineo> unidad = new UnidadDeTrabajo<grupoSanguineo>(new BDContext()))
                {
                    animalViewModel.grupoSanguineo = unidad.genericDAL.Get(animalViewModel.idGSanguineo);
                }
                animalesVM.Add(animalViewModel);

                using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
                {
                    animalViewModel.organizacion = unidad.genericDAL.Get(animalViewModel.idOrganizacion);
                }
                animalesVM.Add(animalViewModel);
            }

            return View(animalesVM);
        }

        //Creación de Animales
        public ActionResult Crear()
        {
            AnimalViewModel animal = new AnimalViewModel { };

            using (UnidadDeTrabajo<grupoSanguineo> unidad = new UnidadDeTrabajo<grupoSanguineo>(new BDContext()))
            {
                animal.grupoSanguineo = unidad.genericDAL.Get(animal.idGSanguineo);
            }

            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                animal.organizacion = unidad.genericDAL.Get(animal.idOrganizacion);
            }

            return View(animal);
        }

        [HttpPost]
        public ActionResult Crear(animal animal)
        {
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                unidad.genericDAL.Add(animal);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Modificar Animales
        public ActionResult Editar(int id)
        {
            animal animalEntity;
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                animalEntity = unidad.genericDAL.Get(id);
            }

            AnimalViewModel animal = this.Convertir(animalEntity);

            grupoSanguineo grupoSanguineo;
            List<grupoSanguineo> grupoSanguineos;
            using (UnidadDeTrabajo<grupoSanguineo> unidad = new UnidadDeTrabajo<grupoSanguineo>(new BDContext()))
            {
                grupoSanguineos = unidad.genericDAL.GetAll().ToList();
                grupoSanguineo = unidad.genericDAL.Get(animal.idGSanguineo);
            }
            grupoSanguineos.Insert(0, grupoSanguineo);
            animal.grupoSanguineos = grupoSanguineos;

            organizacion organizacion;
            List<organizacion> organizaciones;
            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                organizaciones = unidad.genericDAL.GetAll().ToList();
                organizacion = unidad.genericDAL.Get(animal.idOrganizacion);
            }
            organizaciones.Insert(0, organizacion);
            animal.organizaciones = organizaciones;

            return View(animal);
        }

        [HttpPost]
        public ActionResult Editar(animal animal)
        {
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                unidad.genericDAL.Update(animal);
                unidad.Complete();
            }

            return RedirectToAction("Inicio");
        }

        //Ver detalles/descripción del animal
        public ActionResult Detalles(int id)
        {
            animal animalEntity;
            using (UnidadDeTrabajo<animal> unidad = new UnidadDeTrabajo<animal>(new BDContext()))
            {
                animalEntity = unidad.genericDAL.Get(id);
            }

            AnimalViewModel animal = this.Convertir(animalEntity);

            using (UnidadDeTrabajo<grupoSanguineo> unidad = new UnidadDeTrabajo<grupoSanguineo>(new BDContext()))
            {
                animal.grupoSanguineo = unidad.genericDAL.Get(animal.idGSanguineo);
            }

            using (UnidadDeTrabajo<organizacion> unidad = new UnidadDeTrabajo<organizacion>(new BDContext()))
            {
                animal.organizacion = unidad.genericDAL.Get(animal.idOrganizacion);
            }

            return View(animal);
        }
    }
}