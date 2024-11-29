using animals.Helpers;
using animals.DTOs;
using animals.Models;
using animals.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace animals.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly animalsContext _animalsContext;

        public AnimalService(animalsContext animalsContext)
        {
            _animalsContext = animalsContext;
        }

        public Response AddAnimal(AnimalNewDTO newAnimalDTO)
        {
            try
            {
                //Valido que exista la especie y cargo en el contexto los datos de SpecieId y NameGroup
                var specie = _animalsContext.Species.FirstOrDefault(x => x.SpecieId.Equals(newAnimalDTO.SpecieId))
                    ?? throw new Exception("Especie no encontrada"); 
                
                //Creo un nuevo animal
                Animal animalAdd = new ();
                _animalsContext.Entry(animalAdd).CurrentValues.SetValues(newAnimalDTO);//seteo sus atributos
                _animalsContext.Animals.Add(animalAdd);
                _animalsContext.SaveChanges();
               

                return ResponseHelper.OkResponse(animalAdd.ToAnimalGetDTO());
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response DeletAnimalById(Guid AnimalId)
        {
            try
            {
                var animalDelete = _animalsContext.Animals
                .Include(s => s.Specie)
                .FirstOrDefault((a) => a.AnimalId.Equals(AnimalId))
                    ?? throw new Exception("Animal no encontrado");
                _animalsContext.Animals.Remove(animalDelete);
                _animalsContext.SaveChanges();

                return ResponseHelper.OkResponse(animalDelete.ToAnimalGetDTO());

            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response GetAnimalsList()
        {
            try
            {
                var animalList = _animalsContext.Animals
                .Include(s => s.Specie)//incluyo el registro correspondiente de la tabla Specie
                .Select(a => a.ToAnimalGetDTO())//agrego el nombre de la especiea cada registro (NameGroup)
                .ToList();
                return ResponseHelper.OkResponse(animalList);
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }

        }

        public Response GetAnimalById(Guid AnimalId)
        {
            try
            {
                var animalGet = _animalsContext.Animals
                    .Include(a => a.Specie)
                    .FirstOrDefault(a => a.AnimalId == AnimalId) ?? throw new Exception("Animal no encontrado");

                return ResponseHelper.OkResponse(animalGet.ToAnimalGetDTO());
            }
            catch(Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response UpdateAnimalById(Guid animalId, AnimalNewDTO animalNewDTO)
        {
            try
            {
                // Validar que el animal exista
                var animalUpdate = _animalsContext.Animals.FirstOrDefault(a => a.AnimalId.Equals(animalId))
                    ?? throw new Exception("Animal no encontrado");
                // Validar que la especie exista 
                var specie = _animalsContext.Species.FirstOrDefault(s => s.SpecieId.Equals(animalNewDTO.SpecieId))
                    ?? throw new Exception("Especie no encontrada");

                _animalsContext.Entry(animalUpdate).CurrentValues.SetValues(animalNewDTO);//Mapeamos los valores modificados
                _animalsContext.Animals.Update(animalUpdate);
                _animalsContext.SaveChanges();

                return ResponseHelper.OkResponse(animalUpdate.ToAnimalGetDTO());
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }
    }

}
