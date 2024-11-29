using animals.DTOs;
using animals.Models;
using animals.Services;
using animals.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace animals.Controllers
{
    [Route("api/animal")]
    [ApiController]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService; // cumplo con el contrato de la interface y digo que calse la implementa
        }

        [HttpGet("get-animals-list")]
        public Response GetAnimalsList()
        {
            return _animalService.GetAnimalsList();
        }

        [HttpGet("get-animal-by-id")]
        public Response GetAnimalById([FromQuery] Guid animalID)
        {
            return _animalService.GetAnimalById(animalID);          
        }

        [HttpPost("add-animal")]
        public Response AddAnimal([FromBody] AnimalNewDTO newAnimalDTO)
        {
            return _animalService.AddAnimal(newAnimalDTO);      
        }

        [HttpPut("updat-animal-by-id/{id}")]
        public Response UpdateAnimalById([FromRoute] Guid id,[FromBody] AnimalNewDTO animalNewDTO)
        {
            return _animalService.UpdateAnimalById(id, animalNewDTO);
        }

        [HttpDelete("delet-animal-by-id/{id}")]
        public Response DeletAnimalById([FromRoute] Guid id)
        {
            return _animalService.DeletAnimalById(id);
        }
    }
}
