using Microsoft.EntityFrameworkCore;
using BarraBonitaTurismo.Models;

namespace BarraBonitaTurismo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<FAQ> FAQs { get; set; }
        public DbSet<GuideItem> GuideItems { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ── Atrações ──────────────────────────────────────────────────────
            modelBuilder.Entity<Attraction>().HasData(
                new Attraction
                {
                    Id = 1,
                    Name = "Passeios de Barco",
                    Description = "Os passeios de barco representam a principal atividade turística de Barra Bonita e são considerados um dos maiores símbolos da cidade. As embarcações realizam trajetos pelo Rio Tietê, permitindo aos visitantes contemplar o lago formado pela barragem, áreas verdes, pontes, marinas e toda a paisagem fluvial da região. Durante o passeio, os turistas podem acompanhar a movimentação da hidrovia e conhecer de perto a famosa Eclusa de Barra Bonita, experiência considerada única no interior paulista.",
                    Category = "Náutica",
                    ImageUrl = "https://bagagemdespachada.com/wp-content/uploads/2020/05/barco_passeio_rio_tiete-scaled-e1604590105256.jpg",
                    Address = "Estrada do Lago, Km 5 - Barra Bonita/SP",
                    Schedule = "Quinta a Domingo, das 8h às 18h",
                    Latitude = -22.5012,
                    Longitude = -48.5456,
                    FunFact = "Os barcos turísticos passam pela famosa Eclusa de Barra Bonita!"
                },
                new Attraction
                {
                    Id = 2,
                    Name = "Eclusa de Barra Bonita",
                    Description = "A Eclusa de Barra Bonita é uma das estruturas turísticas e de engenharia mais importantes do estado de São Paulo. Construída junto à Usina Hidrelétrica, ela funciona como um elevador aquático responsável por permitir a passagem de embarcações entre diferentes níveis do Rio Tietê.",
                    Category = "Náutica",
                    ImageUrl = "https://i.ytimg.com/vi/9I-jQ2s5FaE/maxresdefault.jpg",
                    Address = "Usina Hidrelétrica de Barra Bonita - Barra Bonita/SP",
                    Schedule = "Todos os dias, das 8h às 17h",
                    Latitude = -22.4898,
                    Longitude = -48.5583,
                    FunFact = "É considerada a primeira eclusa turística da América do Sul!"
                },
                new Attraction
                {
                    Id = 3,
                    Name = "Orla Fluvial",
                    Description = "A Orla Fluvial de Barra Bonita é um dos espaços mais visitados da cidade e reúne turismo, lazer e contato direto com o Rio Tietê. O espaço conta com calçadão, bancos, iluminação noturna, áreas arborizadas e vista privilegiada das embarcações turísticas.",
                    Category = "Náutica",
                    ImageUrl = "https://radardointerior.com.br/wp-content/uploads/2024/04/Fotos-artigos-RADAR-.png",
                    Address = "Avenida Rosa Zanela Petri - Barra Bonita/SP",
                    Schedule = "Aberto diariamente, 24 horas",
                    Latitude = -22.4915,
                    Longitude = -48.5564,
                    FunFact = "A orla é um dos locais mais frequentados da cidade durante o pôr do sol!"
                },
                new Attraction
                {
                    Id = 4,
                    Name = "Museu Municipal Luiz Saffi",
                    Description = "O Museu Municipal Luiz Saffi preserva grande parte da memória histórica e cultural de Barra Bonita. O museu reúne fotografias antigas, documentos históricos, objetos culturais, móveis e itens relacionados ao crescimento econômico e turístico da região.",
                    Category = "Cultura",
                    ImageUrl = "https://static.wixstatic.com/media/6347c0_c6e1ad7d63864cc8a4131060ad8193d0~mv2.jpg/v1/fill/w_300,h_154,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/20180115_123217_edited.jpg",
                    Address = "Rua Primeiro de Março, Centro - Barra Bonita/SP",
                    Schedule = "Terça a Sábado, das 9h às 17h",
                    Latitude = -22.4921,
                    Longitude = -48.5571,
                    FunFact = "O museu está instalado em um prédio histórico ligado à antiga ferrovia!"
                },
                new Attraction
                {
                    Id = 5,
                    Name = "Parque Turístico Municipal",
                    Description = "Espaço de lazer e recreação às margens do Rio Tietê, com área verde, quiosques, playground e estrutura para eventos ao ar livre.",
                    Category = "Lazer",
                    ImageUrl = "/images/atracoes/parque.jpg",
                    Address = "Parque Turístico Municipal - Barra Bonita/SP",
                    Schedule = "Todos os dias, das 9h às 17h",
                    Latitude = -22.4939,
                    Longitude = -48.5567,
                    FunFact = "O espaço foi criado especialmente para atividades infantis!"
                }
            );

            // ── Eventos ───────────────────────────────────────────────────────
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "Festa do Peixe",
                    Description = "Tradicional festival gastronômico com os melhores pratos à base de peixe da região, shows e atrações culturais.",
                    StartDate = new DateTime(2025, 7, 15),
                    EndDate = new DateTime(2025, 7, 30),
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
                    StartDate = new DateTime(2025, 8, 20),
                    EndDate = new DateTime(2025, 8, 22),
                    Location = "Lago de Barra Bonita",
                    ImageUrl = "/images/eventos/regata.jpg",
                    IsFeatured = true,
                    EventType = "Esportivo"
                },
                new Event
                {
                    Id = 3,
                    Title = "Aniversário da Cidade",
                    Description = "Desfile cívico, shows gratuitos e queima de fogos em comemoração ao aniversário de Barra Bonita.",
                    StartDate = new DateTime(2025, 9, 13),
                    EndDate = null,
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
                    StartDate = new DateTime(2025, 6, 5),
                    EndDate = new DateTime(2025, 6, 25),
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
                    StartDate = new DateTime(2025, 12, 1),
                    EndDate = new DateTime(2025, 12, 25),
                    Location = "Praça Central",
                    ImageUrl = "/images/eventos/natal.jpg",
                    IsFeatured = false,
                    EventType = "Cultural"
                }
            );

            // ── FAQs ──────────────────────────────────────────────────────────
            modelBuilder.Entity<FAQ>().HasData(
                new FAQ { Id = 1, Question = "Qual a melhor época para visitar Barra Bonita?", Answer = "A cidade é agradável o ano todo. O verão (dezembro a março) é ideal para atividades náuticas, enquanto o inverno (junho a agosto) tem temperaturas amenas para passeios ao ar livre.", Order = 1 },
                new FAQ { Id = 2, Question = "Como chegar a Barra Bonita?", Answer = "A cidade está localizada a 280km de São Paulo, acesso pela Rodovia Marechal Rondon (SP-300) ou pela SP-191. Há também linhas de ônibus regulares da Viação Cometa e outras empresas.", Order = 2 },
                new FAQ { Id = 3, Question = "Precisa pagar para acessar o Lago?", Answer = "Não, o acesso ao Lago e à Orla é gratuito. Apenas atividades como aluguel de barcos e passeios turísticos têm custo.", Order = 3 },
                new FAQ { Id = 4, Question = "Onde se hospedar?", Answer = "A cidade conta com hotéis, pousadas e chalés às margens do lago. Recomendamos o Hotel Barra Bonita Resort, Pousada do Lago e Recanto do Pescador.", Order = 4 },
                new FAQ { Id = 5, Question = "É permitido nadar no Lago?", Answer = "A natação é permitida apenas em áreas designadas e com supervisão. Recomendamos usar os clubes e praias artificiais para maior segurança.", Order = 5 }
            );

            // ── Guia Turístico ────────────────────────────────────────────────
            modelBuilder.Entity<GuideItem>().HasData(
                // Hospedagem
                new GuideItem { Id = 1, Type = "Hospedagem", Name = "Hotel Barra Bonita Resort", Description = "Resort completo com piscinas, sauna, academia e acesso direto ao lago.", Address = "Av. Beira Lago, 1000", Phone = "(14) 3604-1234", Website = "www.hotelbarrabonita.com", ImageUrl = "/images/guia/resort.jpg", Rating = 5 },
                new GuideItem { Id = 2, Type = "Hospedagem", Name = "Pousada do Lago", Description = "Aconchegante pousada familiar com vista para o lago e café colonial.", Address = "Rua das Flores, 45", Phone = "(14) 3604-5678", Website = "www.pousadadolago.com", ImageUrl = "/images/guia/pousada.jpg", Rating = 4 },
                new GuideItem { Id = 3, Type = "Hospedagem", Name = "Chalés Recanto do Pescador", Description = "Chalés rústicos com estrutura para pesca e churrasqueira.", Address = "Estrada do Lago, Km 3", Phone = "(14) 3604-9012", Website = null, ImageUrl = "/images/guia/chales.jpg", Rating = 4 },
                // Gastronomia
                new GuideItem { Id = 4, Type = "Gastronomia", Name = "Restaurante Peixe Vivo", Description = "Especializado em peixes do lago, com destaque para a moqueca e o peixe na telha.", Address = "Av. Marginal, 200", Phone = "(14) 3604-3456", Website = "www.peixevivo.com", ImageUrl = "/images/guia/peixevivo.jpg", Rating = 5 },
                new GuideItem { Id = 5, Type = "Gastronomia", Name = "Cantina Italiana Bella Vista", Description = "Massas caseiras e pizzas artesanais com vista panorâmica.", Address = "Rua Italia, 78", Phone = "(14) 3604-7890", Website = null, ImageUrl = "/images/guia/cantina.jpg", Rating = 4 },
                new GuideItem { Id = 6, Type = "Gastronomia", Name = "Churrascaria do Lago", Description = "Rodízio de carnes nobres com buffet completo e música ao vivo aos finais de semana.", Address = "Av. Beira Lago, 500", Phone = "(14) 3604-2345", Website = null, ImageUrl = "/images/guia/churrascaria.jpg", Rating = 5 },
                new GuideItem { Id = 7, Type = "Gastronomia", Name = "Café Colonial da Vó", Description = "Café colonial com mais de 30 opções de doces, salgados e bolos caseiros.", Address = "Praça Central, 12", Phone = "(14) 3604-6789", Website = null, ImageUrl = "/images/guia/cafe.jpg", Rating = 4 },
                // Atividades
                new GuideItem { Id = 8, Type = "Atividades", Name = "Aluguel de Barcos e Jet-skis", Description = "Aluguel de lanchas, jet-skis, caiaques e pedalinhos.", Address = "Marina Barra Bonita, Av. Beira Lago", Phone = "(14) 3604-1111", Website = "www.marinabarra.com", ImageUrl = "/images/guia/barcos.jpg", Rating = 5 },
                new GuideItem { Id = 9, Type = "Atividades", Name = "Passeio de Escuna", Description = "Passeio guiado pelo lago com parada para banho e almoço.", Address = "Píer Turístico", Phone = "(14) 3604-2222", Website = null, ImageUrl = "/images/guia/escuna.jpg", Rating = 5 },
                new GuideItem { Id = 10, Type = "Atividades", Name = "Trilhas Ecológicas", Description = "Trilhas monitoradas com guias especializados e observação de aves.", Address = "Recanto Ecológico", Phone = "(14) 3604-3333", Website = null, ImageUrl = "/images/guia/trilhas.jpg", Rating = 4 },
                new GuideItem { Id = 11, Type = "Atividades", Name = "Pesca Esportiva", Description = "Passeios de barco para pesca com equipamentos e iscas inclusos.", Address = "Pesqueiro do Lago", Phone = "(14) 3604-4444", Website = null, ImageUrl = "/images/guia/pesca.jpg", Rating = 4 }
            );
        }
    }
}
