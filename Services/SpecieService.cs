using animals.DTOs;
using animals.Helpers;
using animals.Models;
using animals.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace animals.Services
{
    public class SpecieService : ISpecieService // Implementamos la interfaz
    {
        private readonly animalsContext _animalsContext;

        public SpecieService(animalsContext animalsContext)
        {
            _animalsContext = animalsContext;
        }

        public Response AddSpecie(SpecieNewDTO SpecieNewDTO)
        {
            try
            {
                Specie specie = new Specie();
                _animalsContext.Entry(specie).CurrentValues.SetValues(SpecieNewDTO);
                _animalsContext.Species.Add(specie);
                _animalsContext.SaveChanges();
                return ResponseHelper.OkResponse(specie.ToSpecieGetDTO());
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }

        }

        public Response DeleteSpecieById(Guid specieId)
        {
            try
            {
                //valido que la especie exista
                Specie specieDelete = _animalsContext.Species.FirstOrDefault(x => x.SpecieId.Equals(specieId))
                    ?? throw new Exception("Espece no encontrada.");

                _animalsContext.Species.Remove(specieDelete);
                _animalsContext.SaveChanges();

                return ResponseHelper.OkResponse(specieDelete);
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response GetSpecieById(Guid specieId)
        {
            try 
            {
                var specieGet = _animalsContext.Species
                    .Include(a => a.Animals)
                    .FirstOrDefault(s=>s.SpecieId.Equals(specieId))
                    ?? throw new Exception("Especie no encontrada.");
                return ResponseHelper.OkResponse(specieGet.ToSpecieGetDTO());
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
            
        }

        public Response GetSpecieShortList()
        {
            try
            {
                var specieShortList =  _animalsContext.Species
                .Select(s => new SimpleSpecieDTO { SpecieId = s.SpecieId, NameGroup = s.NameGroup })
                .ToList();
                return ResponseHelper.OkResponse(specieShortList);
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response GetSpeciesList()
        {
            try
            {
                var specieList = _animalsContext.Species
                .Include(a => a.Animals)// Incluyo el registro correspondiente de la tabla Animal
                .Select(s => s.ToSpecieGetDTO())// Agrego el id y nombre del animal asociado a una especie.
                .ToList();
                return ResponseHelper.OkResponse(specieList);
            }
            catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }

        public Response UpdateSpecieById(Guid specieId, SpecieNewDTO SpecieNewDTO)
        {
            try
            {
                //valido que la especie exista
                Specie specieUpdate = _animalsContext.Species.FirstOrDefault(x => x.SpecieId.Equals(specieId))
                    ?? throw new Exception("Espece no encontrada.");

                _animalsContext.Entry(specieUpdate).CurrentValues.SetValues(SpecieNewDTO);
                _animalsContext.Species.Update(specieUpdate);
                _animalsContext.SaveChanges();

                return ResponseHelper.OkResponse(specieUpdate);

            }catch (Exception ex)
            {
                return ResponseHelper.BadResponse(ex);
            }
        }
    }
}
