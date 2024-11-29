namespace animals.DTOs
{
    public class AnimalGetDTO
    {
        public Guid AnimalId { get; set; }

        public string AnimalName { get; set; }

        public int NumberLegs { get; set; }

        public string AnimalLocomotion { get; set; }

        public Guid SpecieId { get; set; }

        public string NameGroup { get; set; }
    }
}
