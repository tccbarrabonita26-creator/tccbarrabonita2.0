namespace BarraBonitaTurismo.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Location { get; set; }
        public string ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public string EventType { get; set; } // Cultural, Esportivo, Gastronômico, Religioso
    }
}