using BarraBonitaTurismo.Models;
using System.Globalization;

namespace BarraBonitaTurismo.Services
{
    public interface IDataService
    {
        CityInfo GetCityInfo();
        List<Attraction> GetAttractions();
        List<Attraction> GetAttractionsByCategory(string category);
        List<Event> GetEvents();
        List<Event> GetUpcomingEvents(int count);
        List<FAQ> GetFAQs();
        List<GuideItem> GetGuideItems();
        List<GuideItem> GetGuideItemsByType(string type);
        bool SendContactMessage(ContactMessage message);
    }

    public class DataService : IDataService
    {
        private List<Attraction> _attractions;
        private List<Event> _events;
        private List<FAQ> _faqs;
        private List<GuideItem> _guideItems;
        private CityInfo _cityInfo;

        public DataService()
        {
            InitializeData();
        }

        private void InitializeData()
        {
            // Informações da Cidade
            _cityInfo = new CityInfo
            {
                Name = "Barra Bonita",
                Foundation = "13 de setembro de 1890",
                Population = "35.000 habitantes",
                Area = "146 km²",
                Slogan = "Capital Náutica do Interior Paulista",
                History = @"Barra Bonita foi fundada em 13 de setembro de 1890 por José Theodoro de Souza 
                          e outros pioneiros. O nome 'Barra Bonita' origina-se da bela confluência dos rios 
                          Tietê e Piracicaba, formando um local de rara beleza natural. 
                          A cidade cresceu às margens do Rio Tietê e se tornou um importante polo 
                          turístico e econômico da região. 
                          <br/><br/>
                          Na década de 1960, com a construção da Usina Hidrelétrica de Barra Bonita, 
                          a cidade ganhou ainda mais destaque, formando o famoso Lago de Barra Bonita, 
                          que hoje é o principal cartão-postal e atração turística da região.",
                Images = new List<string> 
                { 
                    "/images/cidade/panorama1.jpg",
                    "/images/cidade/lago.jpg",
                    "/images/cidade/centro.jpg" 
                }
            };

            // Atrações Turísticas
            _attractions = new List<Attraction>
            {
                new Attraction
                {
                    Id = 1,
                    Name = "Lago de Barra Bonita",
                    Description = "Imenso lago formado pela represa da Usina Hidrelétrica, perfeito para esportes náuticos, pesca e passeios de barco. Com mais de 40km de extensão, é o principal ponto turístico da cidade.",
                    Category = "Náutica",
                    ImageUrl = "/images/atracoes/lago.jpg",
                    Address = "Margem do Rio Tietê, Barra Bonita - SP",
                    Schedule = "Acesso livre 24 horas",
                    Latitude = -22.4945,
                    Longitude = -48.5583,
                    FunFact = "O lago tem capacidade para gerar energia para mais de 500 mil pessoas!"
                },
                new Attraction
                {
                    Id = 2,
                    Name = "Usina Hidrelétrica de Barra Bonita",
                    Description = "Visita técnica à usina que transformou a região, com museu e mirante. Conheça a história da energia no estado de São Paulo.",
                    Category = "Cultura",
                    ImageUrl = "/images/atracoes/usina.jpg",
                    Address = "Rodovia SP-191, Km 12",
                    Schedule = "Terça a Domingo, 9h às 16h",
                    Latitude = -22.5123,
                    Longitude = -48.5247,
                    FunFact = "Inaugurada em 1963, foi a primeira grande usina do Rio Tietê!"
                },
                new Attraction
                {
                    Id = 3,
                    Name = "Recanto Ecológico",
                    Description = "Parque com trilhas ecológicas, mirantes e área para piquenique. Ideal para contato com a natureza e observação de aves.",
                    Category = "Natureza",
                    ImageUrl = "/images/atracoes/recanto.jpg",
                    Address = "Estrada Municipal, s/n - Bairro do Lago",
                    Schedule = "8h às 18h (fecha às segundas)",
                    Latitude = -22.4789,
                    Longitude = -48.5321,
                    FunFact = "Abriga mais de 150 espécies de aves nativas!"
                },
                new Attraction
                {
                    Id = 4,
                    Name = "Orla Fluvial",
                    Description = "Calçadão à beira do lago com quiosques, ciclovia e playground. Ponto de encontro para famílias aos finais de semana.",
                    Category = "Lazer",
                    ImageUrl = "/images/atracoes/orla.jpg",
                    Address = "Avenida Beira Lago, Centro",
                    Schedule = "Acesso livre 24 horas",
                    Latitude = -22.4951,
                    Longitude = -48.5567,
                    FunFact = "Palco do tradicional Réveillon de Barra Bonita!"
                },
                new Attraction
                {
                    Id = 5,
                    Name = "Museu Histórico Municipal",
                    Description = "Acervo com mais de 500 peças que contam a história da cidade e da região, incluindo objetos da época da fundação.",
                    Category = "Cultura",
                    ImageUrl = "/images/atracoes/museu.jpg",
                    Address = "Rua XV de Novembro, 150 - Centro",
                    Schedule = "Terça a Sexta, 9h às 17h",
                    Latitude = -22.4932,
                    Longitude = -48.5523,
                    FunFact = "O prédio foi a primeira escola da cidade, construída em 1912!"
                },
                new Attraction
                {
                    Id = 6,
                    Name = "Pesqueiro do Lago",
                    Description = "Estrutura completa para pesca esportiva com restaurante e área de lazer. Opção de aluguel de equipamentos.",
                    Category = "Náutica",
                    ImageUrl = "/images/atracoes/pesqueiro.jpg",
                    Address = "Estrada do Lago, Km 5",
                    Schedule = "Quinta a Domingo, 8h às 18h",
                    Latitude = -22.5012,
                    Longitude = -48.5456,
                    FunFact = "Campeonato anual de pesca atrai competidores de todo o estado!"
                },
                new Attraction
                {
                    Id = 7,
                    Name = "Feira Noturna",
                    Description = "Feira de artesanato e gastronomia típica, com música ao vivo. Ocorre todas as quintas-feiras.",
                    Category = "Lazer",
                    ImageUrl = "/images/atracoes/feira.jpg",
                    Address = "Praça da Matriz, Centro",
                    Schedule = "Quintas, 18h às 22h",
                    Latitude = -22.4948,
                    Longitude = -48.5512,
                    FunFact = "Comidas típicas como bolinho de peixe são destaque!"
                }
            };

            // Eventos
            _events = new List<Event>
            {
                new Event
                {
                    Id = 1,
                    Title = "Festa do Peixe",
                    Description = "Tradicional festival gastronômico com os melhores pratos à base de peixe da região, shows e atrações culturais.",
                    StartDate = new DateTime(2024, 7, 15),
                    EndDate = new DateTime(2024, 7, 30),
                    Location = "Centro de Eventos",
                    ImageUrl = "/images/eventos/peixe.jpg",
                    IsFeatured = true,
                    EventType = "Gastronômico"
                },
                new Event
                {
                    Id = 2,
                    Title = "Regata do Lago",
                    Description = "Competição de barcos a vela e jet-ski com participação de atletas de todo o estado.",
                    StartDate = new DateTime(2024, 8, 20),
                    EndDate = new DateTime(2024, 8, 22),
                    Location = "Lago de Barra Bonita",
                    ImageUrl = "/images/eventos/regata.jpg",
                    IsFeatured = true,
                    EventType = "Esportivo"
                },
                new Event
                {
                    Id = 3,
                    Title = "Aniversário da Cidade",
                    Description = "Desfile cívico, shows gratuitos e queima de fogos em comemoração aos 134 anos de Barra Bonita.",
                    StartDate = new DateTime(2024, 9, 13),
                    Location = "Orla Fluvial",
                    ImageUrl = "/images/eventos/aniversario.jpg",
                    IsFeatured = true,
                    EventType = "Cultural"
                },
                new Event
                {
                    Id = 4,
                    Title = "Festival de Inverno",
                    Description = "Apresentações de música clássica, teatro e exposições de arte.",
                    StartDate = new DateTime(2024, 6, 5),
                    EndDate = new DateTime(2024, 6, 25),
                    Location = "Teatro Municipal",
                    ImageUrl = "/images/eventos/inverno.jpg",
                    IsFeatured = false,
                    EventType = "Cultural"
                },
                new Event
                {
                    Id = 5,
                    Title = "Natal Iluminado",
                    Description = "Decoração especial, coral natalino e chegada do Papai Noel.",
                    StartDate = new DateTime(2024, 12, 1),
                    EndDate = new DateTime(2024, 12, 25),
                    Location = "Praça Central",
                    ImageUrl = "/images/eventos/natal.jpg",
                    IsFeatured = false,
                    EventType = "Cultural"
                }
            };

            // Perguntas Frequentes
            _faqs = new List<FAQ>
            {
                new FAQ { Id = 1, Question = "Qual a melhor época para visitar Barra Bonita?", Answer = "A cidade é agradável o ano todo. O verão (dezembro a março) é ideal para atividades náuticas, enquanto o inverno (junho a agosto) tem temperaturas amenas para passeios ao ar livre.", Order = 1 },
                new FAQ { Id = 2, Question = "Como chegar a Barra Bonita?", Answer = "A cidade está localizada a 280km de São Paulo, acesso pela Rodovia Marechal Rondon (SP-300) ou pela SP-191. Há também linhas de ônibus regulares da Viação Cometa e outras empresas.", Order = 2 },
                new FAQ { Id = 3, Question = "Precisa pagar para acessar o Lago?", Answer = "Não, o acesso ao Lago e à Orla é gratuito. Apenas atividades como aluguel de barcos e passeios turísticos têm custo.", Order = 3 },
                new FAQ { Id = 4, Question = "Onde se hospedar?", Answer = "A cidade conta com hotéis, pousadas e chalés às margens do lago. Recomendamos o Hotel Barra Bonita Resort, Pousada do Lago e Recanto do Pescador.", Order = 4 },
                new FAQ { Id = 5, Question = "É permitido nadar no Lago?", Answer = "A natação é permitida apenas em áreas designadas e com supervisão. Recomendamos usar os clubes e praias artificiais para maior segurança.", Order = 5 }
            };

            // Guia Turístico
            _guideItems = new List<GuideItem>
            {
                // Hospedagem
                new GuideItem { Id = 1, Type = "Hospedagem", Name = "Hotel Barra Bonita Resort", Description = "Resort completo com piscinas, sauna, academia e acesso direto ao lago.", Address = "Av. Beira Lago, 1000", Phone = "(14) 3604-1234", Website = "www.hotelbarrabonita.com", ImageUrl = "/images/guia/resort.jpg", Rating = 5 },
                new GuideItem { Id = 2, Type = "Hospedagem", Name = "Pousada do Lago", Description = "Aconchegante pousada familiar com vista para o lago e café colonial.", Address = "Rua das Flores, 45", Phone = "(14) 3604-5678", Website = "www.pousadadolago.com", ImageUrl = "/images/guia/pousada.jpg", Rating = 4 },
                new GuideItem { Id = 3, Type = "Hospedagem", Name = "Chalés Recanto do Pescador", Description = "Chalés rústicos com estrutura para pesca e churrasqueira.", Address = "Estrada do Lago, Km 3", Phone = "(14) 3604-9012", ImageUrl = "/images/guia/chales.jpg", Rating = 4 },
                
                // Gastronomia
                new GuideItem { Id = 4, Type = "Gastronomia", Name = "Restaurante Peixe Vivo", Description = "Especializado em peixes do lago, com destaque para a moqueca e o peixe na telha.", Address = "Av. Marginal, 200", Phone = "(14) 3604-3456", Website = "www.peixevivo.com", ImageUrl = "/images/guia/peixevivo.jpg", Rating = 5 },
                new GuideItem { Id = 5, Type = "Gastronomia", Name = "Cantina Italiana Bella Vista", Description = "Massas caseiras e pizzas artesanais com vista panorâmica.", Address = "Rua Italia, 78", Phone = "(14) 3604-7890", ImageUrl = "/images/guia/cantina.jpg", Rating = 4 },
                new GuideItem { Id = 6, Type = "Gastronomia", Name = "Churrascaria do Lago", Description = "Rodízio de carnes nobres com buffet completo e música ao vivo aos finais de semana.", Address = "Av. Beira Lago, 500", Phone = "(14) 3604-2345", ImageUrl = "/images/guia/churrascaria.jpg", Rating = 5 },
                new GuideItem { Id = 7, Type = "Gastronomia", Name = "Café Colonial da Vó", Description = "Café colonial com mais de 30 opções de doces, salgados e bolos caseiros.", Address = "Praça Central, 12", Phone = "(14) 3604-6789", ImageUrl = "/images/guia/cafe.jpg", Rating = 4 },
                
                // Atividades
                new GuideItem { Id = 8, Type = "Atividades", Name = "Aluguel de Barcos e Jet-skis", Description = "Aluguel de lanchas, jet-skis, caiaques e pedalinhos.", Address = "Marina Barra Bonita, Av. Beira Lago", Phone = "(14) 3604-1111", Website = "www.marinabarra.com", ImageUrl = "/images/guia/barcos.jpg", Rating = 5 },
                new GuideItem { Id = 9, Type = "Atividades", Name = "Passeio de Escuna", Description = "Passeio guiado pelo lago com parada para banho e almoço.", Address = "Píer Turístico", Phone = "(14) 3604-2222", ImageUrl = "/images/guia/escuna.jpg", Rating = 5 },
                new GuideItem { Id = 10, Type = "Atividades", Name = "Trilhas Ecológicas", Description = "Trilhas monitoradas com guias especializados e observação de aves.", Address = "Recanto Ecológico", Phone = "(14) 3604-3333", ImageUrl = "/images/guia/trilhas.jpg", Rating = 4 },
                new GuideItem { Id = 11, Type = "Atividades", Name = "Pesca Esportiva", Description = "Passeios de barco para pesca com equipamentos e iscas inclusos.", Address = "Pesqueiro do Lago", Phone = "(14) 3604-4444", ImageUrl = "/images/guia/pesca.jpg", Rating = 4 }
            };
        }

        public CityInfo GetCityInfo() => _cityInfo;
        
        public List<Attraction> GetAttractions() => _attractions;
        
        public List<Attraction> GetAttractionsByCategory(string category)
        {
            if (string.IsNullOrEmpty(category)) return _attractions;
            return _attractions.Where(a => a.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public List<Event> GetEvents() => _events.OrderBy(e => e.StartDate).ToList();
        
        public List<Event> GetUpcomingEvents(int count)
        {
            return _events.Where(e => e.StartDate >= DateTime.Now)
                         .OrderBy(e => e.StartDate)
                         .Take(count)
                         .ToList();
        }
        
        public List<FAQ> GetFAQs() => _faqs.OrderBy(f => f.Order).ToList();
        
        public List<GuideItem> GetGuideItems() => _guideItems;
        
        public List<GuideItem> GetGuideItemsByType(string type)
        {
            if (string.IsNullOrEmpty(type)) return _guideItems;
            return _guideItems.Where(g => g.Type.Equals(type, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        
        public bool SendContactMessage(ContactMessage message)
        {
            // Simula envio de email ou armazenamento
            // Em um sistema real, aqui enviaria email ou salvaria em arquivo
            if (message != null && 
                !string.IsNullOrEmpty(message.Name) && 
                !string.IsNullOrEmpty(message.Email) && 
                !string.IsNullOrEmpty(message.Message))
            {
                // Simula sucesso
                return true;
            }
            return false;
        }
    }
}