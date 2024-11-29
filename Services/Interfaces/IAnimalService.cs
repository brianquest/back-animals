using animals.DTOs;
using animals.Models;

namespace animals.Services.Interfaces
{
    public interface IAnimalService
    {
        public Response GetAnimalsList(); //Obtenemos la lista de todos los animeles
        
        public Response GetAnimalById(Guid AnimalId); // Obtenemos una animal por Id

        public Response AddAnimal(AnimalNewDTO AnimalDTO); // Agregamos un nueva animal

        public Response UpdateAnimalById(Guid animalId, AnimalNewDTO animalNewDTO); // Editamos una animal por Id

        public Response DeletAnimalById(Guid AnimalId); // Eliminamos una animal por Id
    }
}
