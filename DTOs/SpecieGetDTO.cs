using animals.Models;

namespace animals.DTOs
{
    public class SpecieGetDTO
    {
        public Guid SpecieId { get; set; }

        public string NameGroup { get; set; }

        public string Detail { get; set; }

        public List<SimpleAnimalDTO> simpleAnimalDTOs { get; set; } = new List<SimpleAnimalDTO>();
    }
}
