using animals.DTOs;
using animals.Models;

namespace animals.Services.Interfaces
{
    public interface ISpecieService
    {
        public Response GetSpeciesList(); //Obtenemos la lista de todas las especies

        public Response GetSpecieById(Guid specieId); // Obtenemos una especie por Id

        public Response AddSpecie(SpecieNewDTO SpecieNewDTO); // Agregamos una nueva especie
        
        public Response UpdateSpecieById(Guid specieId, SpecieNewDTO SpecieNewDTO); // Editamos una especie por Id

        public Response DeleteSpecieById(Guid specieId); // Eliminamos una especie por Id

        public Response GetSpecieShortList();


    }
}
