using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TP.Data;
using TP.Models;

namespace TP.Controllers
{
    public class AnimalController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AnimalController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Animal
        public async Task<IActionResult> Index()
        {
            var tPContext = _context.Animal.Include(a => a.IdGsanguineoNavigation).Include(a => a.IdOrganizacionNavigation);
            return View(await tPContext.ToListAsync());
        }

        // GET: Animal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.IdGsanguineoNavigation)
                .Include(a => a.IdOrganizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // GET: Animal/Create
        public IActionResult Create()
        {
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var razas = new List<string> { "Mixto","Blue Lacy","Queensland Heeler","Rhod Ridgeback","Retriever","Chinese Sharpei","Black Mouth Cur",
                "Catahoula","Staffordshire","Affenpinscher","Afghan Hound","Airedale Terrier","Akita","Australian Kelpie","Alaskan Malamute",
                "English Bulldog","American Bulldog","American English Coonhound","American Eskimo Dog (Miniature)",
                "American Eskimo Dog (Standard)","American Eskimo Dog (Toy)","American Foxhound","American Hairless Terrier",
                "American Staffordshire Terrier","American Water Spaniel","Anatolian Shepherd Dog","Australian Cattle Dog",
                "Australian Shepherd","Australian Terrier","Basenji","Basset Hound","Beagle","Bearded Collie","Beauceron","Bedlington Terrier",
                "Belgian Malinois","Belgian Sheepdog","Belgian Tervuren","Bergamasco","Berger Picard","Bernese Mountain Dog","Bichon Fris",
                "Black and Tan Coonhound","Black Russian Terrier","Bloodhound","Bluetick Coonhound","Boerboel","Border Collie","Border Terrier",
                "Borzoi","Boston Terrier","Bouvier des Flandres","Boxer","Boykin Spaniel","Briard","Brittany","Brussels Griffon","Bull Terrier",
                "Bull Terrier (Miniature)","Bulldog","Bullmastiff","Cairn Terrier","Canaan Dog","Cane Corso","Cardigan Welsh Corgi",
                "Cavalier King Charles Spaniel","Cesky Terrier","Chesapeake Bay Retriever","Chihuahua","Chinese Crested Dog",
                "Chinese Shar Pei","Chinook","Chow Chow","Cirneco dell'Etna","Clumber Spaniel","Cocker Spaniel","Collie","Coton de Tulear",
                "Curly-Coated Retriever","Dachshund","Dalmatian","Dandie Dinmont Terrier","Doberman Pinsch","Doberman Pinscher",
                "Dogue De Bordeaux","English Cocker Spaniel","English Foxhound","English Setter","English Springer Spaniel",
                "English Toy Spaniel","Entlebucher Mountain Dog","Field Spaniel","Finnish Lapphund","Finnish Spitz","Flat-Coated Retriever",
                "French Bulldog","German Pinscher","German Shepherd","German Shorthaired Pointer","German Wirehaired Pointer","Giant Schnauzer",
                "Glen of Imaal Terrier","Golden Retriever","Gordon Setter","Great Dane","Great Pyrenees","Greater Swiss Mountain Dog",
                "Greyhound","Harrier","Havanese","Ibizan Hound","Icelandic Sheepdog","Irish Red and White Setter","Irish Setter",
                "Irish Terrier","Irish Water Spaniel","Irish Wolfhound","Italian Greyhound","Japanese Chin","Keeshond","Kerry Blue Terrier",
                "Komondor","Kuvasz","Labrador Retriever","Lagotto Romagnolo","Lakeland Terrier","Leonberger","Lhasa Apso","L_wchen","Maltés",
                "Manchester Terrier","Mastiff","Miniature American Shepherd","Miniature Bull Terrier","Miniature Pinscher","Miniature Schnauzer",
                "Neapolitan Mastiff","Newfoundland","Norfolk Terrier","Norwegian Buhund","Norwegian Elkhound","Norwegian Lundehund",
                "Norwich Terrier","Nova Scotia Duck Tolling Retriever","Old English Sheepdog","Otterhound","Papillon","Parson Russell Terrier",
                "Pekingese","Pembroke Welsh Corgi","Petit Basset Griffon Vend_en","Pharaoh Hound","Plott","Pointer","Polish Lowland Sheepdog",
                "Pomeranian","Standard Poodle","Miniature Poodle","Toy Poodle","Portuguese Podengo Pequeno","Portuguese Water Dog","Pug","Puli",
                "Pyrenean Shepherd","Rat Terrier","Redbone Coonhound","Rhodesian Ridgeback","Rottweiler","Russell Terrier","St. Bernard",
                "Saluki","Samoyed","Schipperke","Scottish Deerhound","Scottish Terrier","Sealyham Terrier","Shetland Sheepdog","Shiba Inu",
                "Shih Tzu","Siberian Husky","Silky Terrier","Skye Terrier","Sloughi","Smooth Fox Terrier","Soft-Coated Wheaten Terrier",
                "Spanish Water Dog","Spinone Italiano","Staffordshire Bull Terrier","Standard Schnauzer","Sussex Spaniel","Swedish Vallhund",
                "Tibetan Mastiff","Tibetan Spaniel","Tibetan Terrier","Toy Fox Terrier","Treeing Walker Coonhound","Vizsla","Weimaraner",
                "Welsh Springer Spaniel","Welsh Terrier","West Highland White Terrier","Whippet","Wire Fox Terrier",
                "Wirehaired Pointing Griffon","Wirehaired Vizsla","Xoloitzcuintli","Yorkshire Terrier" };
            ViewData["Raza"] = new SelectList(razas);

            ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo");
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion, "IdOrganizacion", "Nombre");
            return View();
        }

        // POST: Animal/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnimal,Nombre,Sexo,Raza,Castrado,Edad,FechaIngreso,IdGsanguineo,IdOrganizacion,Especie,Adoptado")] Animal animal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(animal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var razas = new List<string> { "Mixto","Blue Lacy","Queensland Heeler","Rhod Ridgeback","Retriever","Chinese Sharpei","Black Mouth Cur",
                "Catahoula","Staffordshire","Affenpinscher","Afghan Hound","Airedale Terrier","Akita","Australian Kelpie","Alaskan Malamute",
                "English Bulldog","American Bulldog","American English Coonhound","American Eskimo Dog (Miniature)",
                "American Eskimo Dog (Standard)","American Eskimo Dog (Toy)","American Foxhound","American Hairless Terrier",
                "American Staffordshire Terrier","American Water Spaniel","Anatolian Shepherd Dog","Australian Cattle Dog",
                "Australian Shepherd","Australian Terrier","Basenji","Basset Hound","Beagle","Bearded Collie","Beauceron","Bedlington Terrier",
                "Belgian Malinois","Belgian Sheepdog","Belgian Tervuren","Bergamasco","Berger Picard","Bernese Mountain Dog","Bichon Fris",
                "Black and Tan Coonhound","Black Russian Terrier","Bloodhound","Bluetick Coonhound","Boerboel","Border Collie","Border Terrier",
                "Borzoi","Boston Terrier","Bouvier des Flandres","Boxer","Boykin Spaniel","Briard","Brittany","Brussels Griffon","Bull Terrier",
                "Bull Terrier (Miniature)","Bulldog","Bullmastiff","Cairn Terrier","Canaan Dog","Cane Corso","Cardigan Welsh Corgi",
                "Cavalier King Charles Spaniel","Cesky Terrier","Chesapeake Bay Retriever","Chihuahua","Chinese Crested Dog",
                "Chinese Shar Pei","Chinook","Chow Chow","Cirneco dell'Etna","Clumber Spaniel","Cocker Spaniel","Collie","Coton de Tulear",
                "Curly-Coated Retriever","Dachshund","Dalmatian","Dandie Dinmont Terrier","Doberman Pinsch","Doberman Pinscher",
                "Dogue De Bordeaux","English Cocker Spaniel","English Foxhound","English Setter","English Springer Spaniel",
                "English Toy Spaniel","Entlebucher Mountain Dog","Field Spaniel","Finnish Lapphund","Finnish Spitz","Flat-Coated Retriever",
                "French Bulldog","German Pinscher","German Shepherd","German Shorthaired Pointer","German Wirehaired Pointer","Giant Schnauzer",
                "Glen of Imaal Terrier","Golden Retriever","Gordon Setter","Great Dane","Great Pyrenees","Greater Swiss Mountain Dog",
                "Greyhound","Harrier","Havanese","Ibizan Hound","Icelandic Sheepdog","Irish Red and White Setter","Irish Setter",
                "Irish Terrier","Irish Water Spaniel","Irish Wolfhound","Italian Greyhound","Japanese Chin","Keeshond","Kerry Blue Terrier",
                "Komondor","Kuvasz","Labrador Retriever","Lagotto Romagnolo","Lakeland Terrier","Leonberger","Lhasa Apso","L_wchen","Maltés",
                "Manchester Terrier","Mastiff","Miniature American Shepherd","Miniature Bull Terrier","Miniature Pinscher","Miniature Schnauzer",
                "Neapolitan Mastiff","Newfoundland","Norfolk Terrier","Norwegian Buhund","Norwegian Elkhound","Norwegian Lundehund",
                "Norwich Terrier","Nova Scotia Duck Tolling Retriever","Old English Sheepdog","Otterhound","Papillon","Parson Russell Terrier",
                "Pekingese","Pembroke Welsh Corgi","Petit Basset Griffon Vend_en","Pharaoh Hound","Plott","Pointer","Polish Lowland Sheepdog",
                "Pomeranian","Standard Poodle","Miniature Poodle","Toy Poodle","Portuguese Podengo Pequeno","Portuguese Water Dog","Pug","Puli",
                "Pyrenean Shepherd","Rat Terrier","Redbone Coonhound","Rhodesian Ridgeback","Rottweiler","Russell Terrier","St. Bernard",
                "Saluki","Samoyed","Schipperke","Scottish Deerhound","Scottish Terrier","Sealyham Terrier","Shetland Sheepdog","Shiba Inu",
                "Shih Tzu","Siberian Husky","Silky Terrier","Skye Terrier","Sloughi","Smooth Fox Terrier","Soft-Coated Wheaten Terrier",
                "Spanish Water Dog","Spinone Italiano","Staffordshire Bull Terrier","Standard Schnauzer","Sussex Spaniel","Swedish Vallhund",
                "Tibetan Mastiff","Tibetan Spaniel","Tibetan Terrier","Toy Fox Terrier","Treeing Walker Coonhound","Vizsla","Weimaraner",
                "Welsh Springer Spaniel","Welsh Terrier","West Highland White Terrier","Whippet","Wire Fox Terrier",
                "Wirehaired Pointing Griffon","Wirehaired Vizsla","Xoloitzcuintli","Yorkshire Terrier" };
            ViewData["Raza"] = new SelectList(razas);

            ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion, "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // GET: Animal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var razas = new List<string> { "Mixto","Blue Lacy","Queensland Heeler","Rhod Ridgeback","Retriever","Chinese Sharpei","Black Mouth Cur",
                "Catahoula","Staffordshire","Affenpinscher","Afghan Hound","Airedale Terrier","Akita","Australian Kelpie","Alaskan Malamute",
                "English Bulldog","American Bulldog","American English Coonhound","American Eskimo Dog (Miniature)",
                "American Eskimo Dog (Standard)","American Eskimo Dog (Toy)","American Foxhound","American Hairless Terrier",
                "American Staffordshire Terrier","American Water Spaniel","Anatolian Shepherd Dog","Australian Cattle Dog",
                "Australian Shepherd","Australian Terrier","Basenji","Basset Hound","Beagle","Bearded Collie","Beauceron","Bedlington Terrier",
                "Belgian Malinois","Belgian Sheepdog","Belgian Tervuren","Bergamasco","Berger Picard","Bernese Mountain Dog","Bichon Fris",
                "Black and Tan Coonhound","Black Russian Terrier","Bloodhound","Bluetick Coonhound","Boerboel","Border Collie","Border Terrier",
                "Borzoi","Boston Terrier","Bouvier des Flandres","Boxer","Boykin Spaniel","Briard","Brittany","Brussels Griffon","Bull Terrier",
                "Bull Terrier (Miniature)","Bulldog","Bullmastiff","Cairn Terrier","Canaan Dog","Cane Corso","Cardigan Welsh Corgi",
                "Cavalier King Charles Spaniel","Cesky Terrier","Chesapeake Bay Retriever","Chihuahua","Chinese Crested Dog",
                "Chinese Shar Pei","Chinook","Chow Chow","Cirneco dell'Etna","Clumber Spaniel","Cocker Spaniel","Collie","Coton de Tulear",
                "Curly-Coated Retriever","Dachshund","Dalmatian","Dandie Dinmont Terrier","Doberman Pinsch","Doberman Pinscher",
                "Dogue De Bordeaux","English Cocker Spaniel","English Foxhound","English Setter","English Springer Spaniel",
                "English Toy Spaniel","Entlebucher Mountain Dog","Field Spaniel","Finnish Lapphund","Finnish Spitz","Flat-Coated Retriever",
                "French Bulldog","German Pinscher","German Shepherd","German Shorthaired Pointer","German Wirehaired Pointer","Giant Schnauzer",
                "Glen of Imaal Terrier","Golden Retriever","Gordon Setter","Great Dane","Great Pyrenees","Greater Swiss Mountain Dog",
                "Greyhound","Harrier","Havanese","Ibizan Hound","Icelandic Sheepdog","Irish Red and White Setter","Irish Setter",
                "Irish Terrier","Irish Water Spaniel","Irish Wolfhound","Italian Greyhound","Japanese Chin","Keeshond","Kerry Blue Terrier",
                "Komondor","Kuvasz","Labrador Retriever","Lagotto Romagnolo","Lakeland Terrier","Leonberger","Lhasa Apso","L_wchen","Maltés",
                "Manchester Terrier","Mastiff","Miniature American Shepherd","Miniature Bull Terrier","Miniature Pinscher","Miniature Schnauzer",
                "Neapolitan Mastiff","Newfoundland","Norfolk Terrier","Norwegian Buhund","Norwegian Elkhound","Norwegian Lundehund",
                "Norwich Terrier","Nova Scotia Duck Tolling Retriever","Old English Sheepdog","Otterhound","Papillon","Parson Russell Terrier",
                "Pekingese","Pembroke Welsh Corgi","Petit Basset Griffon Vend_en","Pharaoh Hound","Plott","Pointer","Polish Lowland Sheepdog",
                "Pomeranian","Standard Poodle","Miniature Poodle","Toy Poodle","Portuguese Podengo Pequeno","Portuguese Water Dog","Pug","Puli",
                "Pyrenean Shepherd","Rat Terrier","Redbone Coonhound","Rhodesian Ridgeback","Rottweiler","Russell Terrier","St. Bernard",
                "Saluki","Samoyed","Schipperke","Scottish Deerhound","Scottish Terrier","Sealyham Terrier","Shetland Sheepdog","Shiba Inu",
                "Shih Tzu","Siberian Husky","Silky Terrier","Skye Terrier","Sloughi","Smooth Fox Terrier","Soft-Coated Wheaten Terrier",
                "Spanish Water Dog","Spinone Italiano","Staffordshire Bull Terrier","Standard Schnauzer","Sussex Spaniel","Swedish Vallhund",
                "Tibetan Mastiff","Tibetan Spaniel","Tibetan Terrier","Toy Fox Terrier","Treeing Walker Coonhound","Vizsla","Weimaraner",
                "Welsh Springer Spaniel","Welsh Terrier","West Highland White Terrier","Whippet","Wire Fox Terrier",
                "Wirehaired Pointing Griffon","Wirehaired Vizsla","Xoloitzcuintli","Yorkshire Terrier" };
            ViewData["Raza"] = new SelectList(razas);

            ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion, "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // POST: Animal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnimal,Nombre,Sexo,Raza,Castrado,Edad,FechaIngreso,IdGsanguineo,IdOrganizacion,Especie,Adoptado")] Animal animal)
        {
            if (id != animal.IdAnimal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(animal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimalExists(animal.IdAnimal))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            var edades = new List<string> { "Menos de 1 mes", "1 mes", "2 meses", "3 meses", "4 meses", "5 meses", "6 meses",
                "7 meses", "8 meses", "9 meses", "10 meses", "11 meses", "1 año", "2 años", "3 años", "4 años", "5 años",
                "6 años", "7 años", "8 años", "9 años", "10 años", "11 años", "12 años", "13 años", "14 años", "15 años", "16 años", "17 años"};
            ViewData["Edad"] = new SelectList(edades);
            var especies = new List<string> { "Perro", "Gato", "Ave", "Roedor" };
            ViewData["Especie"] = new SelectList(especies);
            var sexos = new List<string> { "Hembra", "Macho" };
            ViewData["Sexo"] = new SelectList(sexos);
            var razas = new List<string> { "Mixto","Blue Lacy","Queensland Heeler","Rhod Ridgeback","Retriever","Chinese Sharpei","Black Mouth Cur",
                "Catahoula","Staffordshire","Affenpinscher","Afghan Hound","Airedale Terrier","Akita","Australian Kelpie","Alaskan Malamute",
                "English Bulldog","American Bulldog","American English Coonhound","American Eskimo Dog (Miniature)",
                "American Eskimo Dog (Standard)","American Eskimo Dog (Toy)","American Foxhound","American Hairless Terrier",
                "American Staffordshire Terrier","American Water Spaniel","Anatolian Shepherd Dog","Australian Cattle Dog",
                "Australian Shepherd","Australian Terrier","Basenji","Basset Hound","Beagle","Bearded Collie","Beauceron","Bedlington Terrier",
                "Belgian Malinois","Belgian Sheepdog","Belgian Tervuren","Bergamasco","Berger Picard","Bernese Mountain Dog","Bichon Fris",
                "Black and Tan Coonhound","Black Russian Terrier","Bloodhound","Bluetick Coonhound","Boerboel","Border Collie","Border Terrier",
                "Borzoi","Boston Terrier","Bouvier des Flandres","Boxer","Boykin Spaniel","Briard","Brittany","Brussels Griffon","Bull Terrier",
                "Bull Terrier (Miniature)","Bulldog","Bullmastiff","Cairn Terrier","Canaan Dog","Cane Corso","Cardigan Welsh Corgi",
                "Cavalier King Charles Spaniel","Cesky Terrier","Chesapeake Bay Retriever","Chihuahua","Chinese Crested Dog",
                "Chinese Shar Pei","Chinook","Chow Chow","Cirneco dell'Etna","Clumber Spaniel","Cocker Spaniel","Collie","Coton de Tulear",
                "Curly-Coated Retriever","Dachshund","Dalmatian","Dandie Dinmont Terrier","Doberman Pinsch","Doberman Pinscher",
                "Dogue De Bordeaux","English Cocker Spaniel","English Foxhound","English Setter","English Springer Spaniel",
                "English Toy Spaniel","Entlebucher Mountain Dog","Field Spaniel","Finnish Lapphund","Finnish Spitz","Flat-Coated Retriever",
                "French Bulldog","German Pinscher","German Shepherd","German Shorthaired Pointer","German Wirehaired Pointer","Giant Schnauzer",
                "Glen of Imaal Terrier","Golden Retriever","Gordon Setter","Great Dane","Great Pyrenees","Greater Swiss Mountain Dog",
                "Greyhound","Harrier","Havanese","Ibizan Hound","Icelandic Sheepdog","Irish Red and White Setter","Irish Setter",
                "Irish Terrier","Irish Water Spaniel","Irish Wolfhound","Italian Greyhound","Japanese Chin","Keeshond","Kerry Blue Terrier",
                "Komondor","Kuvasz","Labrador Retriever","Lagotto Romagnolo","Lakeland Terrier","Leonberger","Lhasa Apso","L_wchen","Maltés",
                "Manchester Terrier","Mastiff","Miniature American Shepherd","Miniature Bull Terrier","Miniature Pinscher","Miniature Schnauzer",
                "Neapolitan Mastiff","Newfoundland","Norfolk Terrier","Norwegian Buhund","Norwegian Elkhound","Norwegian Lundehund",
                "Norwich Terrier","Nova Scotia Duck Tolling Retriever","Old English Sheepdog","Otterhound","Papillon","Parson Russell Terrier",
                "Pekingese","Pembroke Welsh Corgi","Petit Basset Griffon Vend_en","Pharaoh Hound","Plott","Pointer","Polish Lowland Sheepdog",
                "Pomeranian","Standard Poodle","Miniature Poodle","Toy Poodle","Portuguese Podengo Pequeno","Portuguese Water Dog","Pug","Puli",
                "Pyrenean Shepherd","Rat Terrier","Redbone Coonhound","Rhodesian Ridgeback","Rottweiler","Russell Terrier","St. Bernard",
                "Saluki","Samoyed","Schipperke","Scottish Deerhound","Scottish Terrier","Sealyham Terrier","Shetland Sheepdog","Shiba Inu",
                "Shih Tzu","Siberian Husky","Silky Terrier","Skye Terrier","Sloughi","Smooth Fox Terrier","Soft-Coated Wheaten Terrier",
                "Spanish Water Dog","Spinone Italiano","Staffordshire Bull Terrier","Standard Schnauzer","Sussex Spaniel","Swedish Vallhund",
                "Tibetan Mastiff","Tibetan Spaniel","Tibetan Terrier","Toy Fox Terrier","Treeing Walker Coonhound","Vizsla","Weimaraner",
                "Welsh Springer Spaniel","Welsh Terrier","West Highland White Terrier","Whippet","Wire Fox Terrier",
                "Wirehaired Pointing Griffon","Wirehaired Vizsla","Xoloitzcuintli","Yorkshire Terrier" };
            ViewData["Raza"] = new SelectList(razas);

            ViewData["IdGsanguineo"] = new SelectList(_context.GrupoSanguineo, "IdGsanguineo", "NombreGsanguineo", animal.IdGsanguineo);
            ViewData["IdOrganizacion"] = new SelectList(_context.Organizacion, "IdOrganizacion", "Nombre", animal.IdOrganizacion);
            return View(animal);
        }

        // GET: Animal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var animal = await _context.Animal
                .Include(a => a.IdGsanguineoNavigation)
                .Include(a => a.IdOrganizacionNavigation)
                .FirstOrDefaultAsync(m => m.IdAnimal == id);
            if (animal == null)
            {
                return NotFound();
            }

            return View(animal);
        }

        // POST: Animal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _context.Animal.FindAsync(id);
            _context.Animal.Remove(animal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnimalExists(int id)
        {
            return _context.Animal.Any(e => e.IdAnimal == id);
        }
    }
}
