namespace BarraBonitaTurismo.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; } // Náutica, Cultura, Lazer, Natureza
        public string ImageUrl { get; set; }
        public string Address { get; set; }
        public string Schedule { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string FunFact { get; set; }
    }
}