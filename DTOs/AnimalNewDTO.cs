using animals.Models;

namespace animals.DTOs
{
    public class AnimalNewDTO
    {
        public string AnimalName { get; set; }

        public int NumberLegs { get; set; }

        public string AnimalLocomotion { get; set; }

        public Guid SpecieId { get; set; }

    }
}
