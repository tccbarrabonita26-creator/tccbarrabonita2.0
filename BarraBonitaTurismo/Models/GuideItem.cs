namespace BarraBonitaTurismo.Models
{
    public class GuideItem
    {
        public int Id { get; set; }
        public string Type { get; set; } // Hospedagem, Gastronomia, Atividades
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }
        public int Rating { get; set; } // 1-5
    }
}   