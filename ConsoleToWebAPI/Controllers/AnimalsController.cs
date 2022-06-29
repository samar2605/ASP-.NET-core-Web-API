using ConsoleToWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private List<Animal> animals = null;
        public AnimalsController()
        {
            animals = new List<Animal>()
            {
                new Animal() { Id = 1, Name = "Dog" },
                new Animal() { Id = 2, Name = "Lion" }
            };
        }
        [Route("", Name = "All")]
        public IActionResult GetAnimals()
        {
            return Ok(animals);
        }

        [Route("test")]
        public IActionResult GetAnimalsTest()
        {
            return LocalRedirectPermanent("~/api/animals");
        }

        [Route("{name}")]
        public IActionResult GetAnimalsByName(string name)
        {
            if (!name.Contains("ABC"))
            {
                return BadRequest();
            }

            return Ok(animals);
        }

        [Route("{id:int}")]
        public IActionResult GetAnimalsById(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            var animal = animals.FirstOrDefault(x => x.Id == id);

            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }

        [HttpPost("")]
        public IActionResult GetAnimals(Animal animal)
        {
            animals.Add(animal);

            return CreatedAtAction("GetAnimalsById", new { id = animal.Id }, animal);
        }
    }
}