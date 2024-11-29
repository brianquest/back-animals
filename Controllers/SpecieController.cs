using animals.DTOs;
using animals.Models;
using animals.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace animals.Controllers
{
    [Route("api/specie")]
    [ApiController]
    public class SpecieController : Controller
    {
        private readonly ISpecieService _specieService;

        public SpecieController(ISpecieService specieService)
        {
            _specieService = specieService; // cumplo con el contrato de la interface y digo que calse la implementa
        }

        [HttpGet ("get-species-list")]
        public Response GetSpeciesList()
        {
            return _specieService.GetSpeciesList();
        }

        [HttpGet ("get-species-short-list")]
        public Response GetSpecieShortList()
        {
            return _specieService.GetSpecieShortList();
        }

        [HttpGet("get-species-by-id")]
        public Response GetSpecieById([FromQuery] Guid specieId)
        {
            return _specieService.GetSpecieById(specieId);
        }

        [HttpPost("add-specie")]
        public Response AddSpecie([FromBody] SpecieNewDTO SpecieNewDTO)
        {
            return _specieService.AddSpecie(SpecieNewDTO);
        }

        [HttpPut ("update-specie-by-id/{id}")]
        public Response UpdateSpecieById([FromRoute] Guid id, [FromBody] SpecieNewDTO SpecieNewDTO)
        {
            return _specieService.UpdateSpecieById(id, SpecieNewDTO);
        }

        [HttpDelete ("delete-secie-by-id/{id}")]
        public Response DeleteSpecieById(Guid id)
        {
            return _specieService.DeleteSpecieById(id);
        }
    }
}
