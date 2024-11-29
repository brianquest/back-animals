using animals.DTOs;
using animals.Models;
namespace animals.Helpers
{
    public static class Utils
    {
        public static AnimalGetDTO ToAnimalGetDTO(this Animal animal)
        {
            return new AnimalGetDTO
            {
                AnimalId = animal.AnimalId,
                AnimalName = animal.AnimalName,
                NumberLegs = animal.NumberLegs,
                AnimalLocomotion = animal.AnimalLocomotion,
                SpecieId = animal.Specie.SpecieId,
                NameGroup = animal.Specie.NameGroup
            };
        }

        public static SpecieGetDTO ToSpecieGetDTO(this Specie specie)
        {
            return new SpecieGetDTO
            {
                SpecieId = specie.SpecieId,
                NameGroup = specie.NameGroup,
                Detail = specie.Detail,
                simpleAnimalDTOs = specie.Animals.Select((a) => new SimpleAnimalDTO()
                {
                    AnimalId = a.AnimalId,
                    AnimalName = a.AnimalName
                }).ToList()
            };
        }

    }
}
