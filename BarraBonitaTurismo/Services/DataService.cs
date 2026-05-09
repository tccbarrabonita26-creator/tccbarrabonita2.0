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
                Name = "Passeios de Barco",
                Description = "Os passeios de barco são a principal atividade turística de Barra Bonita e representam a identidade da cidade. As embarcações percorrem o Rio Tietê em trajetos turísticos que permitem aos visitantes observar o lago formado pela barragem, áreas verdes, marinas, pontes e toda a estrutura da hidrovia. Os barcos são modernos, seguros e preparados para receber turistas durante todo o ano, especialmente aos finais de semana. Durante o passeio, muitos turistas têm a oportunidade de realizar a famosa eclusagem, experiência considerada única no interior paulista. Algumas embarcações oferecem restaurante, música ao vivo e eventos temáticos, transformando o passeio em uma experiência completa de lazer e contemplação.",
                Category = "Náutica",
                ImageUrl = "",
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
                Description = "A Eclusa de Barra Bonita é uma das estruturas turísticas mais importantes da cidade e um dos maiores símbolos da engenharia fluvial brasileira. Construída junto à Usina Hidrelétrica, ela funciona como um elevador aquático que permite que embarcações subam ou desçam diferentes níveis do Rio Tietê. O processo de eclusagem impressiona turistas pela quantidade de água movimentada e pela complexidade do funcionamento da estrutura.",
                Category = "Náutica",
                ImageUrl = "",
                Address = "Usina Hidrelétrica de Barra Bonita - Barra Bonita/SP",
                Schedule = "Todos os dias, das 8h às 17h",
                Latitude = -22.4898,
                Longitude = -48.5583,
                FunFact = "É considerada a primeira eclusa turística da América do Sul!"
            },
            new Attraction
            {
                Id = 3,
                Name = "Marina e Orla Fluvial",
                Description = "A marina e a orla fluvial representam uma das regiões mais movimentadas e turísticas de Barra Bonita. O espaço é utilizado para lazer náutico, passeios de barco, pesca esportiva e convivência social. A marina possui estrutura para embarcações de pequeno e médio porte, enquanto a orla oferece calçadão, áreas de descanso, iluminação noturna e ampla vista do Rio Tietê.",
                Category = "Náutica",
                ImageUrl = "",
                Address = "Avenida Rosa Zanela Petri - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4915,
                Longitude = -48.5564,
                FunFact = "A região da orla é um dos locais mais visitados durante o pôr do sol!"
            },
            new Attraction
            {
                Id = 4,
                Name = "Hidrovia Tietê–Paraná",
                Description = "A Hidrovia Tietê–Paraná é uma importante rota de navegação brasileira que passa diretamente por Barra Bonita. Utilizada para transporte de cargas, turismo e integração fluvial, a hidrovia conecta diversas cidades e estados através dos rios Tietê e Paraná. Em Barra Bonita, ela possui grande importância econômica e turística devido à presença da eclusa e da navegação turística.",
                Category = "Náutica",
                ImageUrl = "",
                Address = "Rio Tietê - Barra Bonita/SP",
                Schedule = "Funcionamento contínuo",
                Latitude = -22.4906,
                Longitude = -48.5572,
                FunFact = "A hidrovia interliga diferentes regiões brasileiras através da navegação fluvial!"
            },
            new Attraction
            {
                Id = 5,
                Name = "Museu Municipal Luiz Saffi",
                Description = "O Museu Municipal Luiz Saffi preserva grande parte da história de Barra Bonita e funciona em um prédio histórico ligado ao desenvolvimento ferroviário da cidade. O local reúne fotografias antigas, documentos históricos, móveis, objetos culturais e itens relacionados à navegação e ao crescimento econômico regional.",
                Category = "Cultura",
                ImageUrl = "",
                Address = "Rua Primeiro de Março, Centro - Barra Bonita/SP",
                Schedule = "Segunda a Sexta, das 9h às 17h",
                Latitude = -22.4909,
                Longitude = -48.5578,
                FunFact = "O museu funciona em um prédio histórico ligado à antiga ferrovia!"
            },
            new Attraction
            {
                Id = 6,
                Name = "Memorial do Rio Tietê",
                Description = "O Memorial do Rio Tietê é um espaço cultural e educativo voltado à valorização histórica, ambiental e econômica do Rio Tietê. O local possui painéis informativos, fotografias, equipamentos náuticos, maquetes e conteúdos educativos relacionados à navegação fluvial e à preservação ambiental.",
                Category = "Cultura",
                ImageUrl = "",
                Address = "Orla Turística - Barra Bonita/SP",
                Schedule = "Terça a Domingo, das 9h às 18h",
                Latitude = -22.4922,
                Longitude = -48.5551,
                FunFact = "O espaço promove atividades de conscientização ambiental!"
            },
            new Attraction
            {
                Id = 7,
                Name = "Usina Hidrelétrica de Barra Bonita",
                Description = "A Usina Hidrelétrica de Barra Bonita é uma das obras mais importantes do interior paulista. Construída sobre o Rio Tietê, ela é responsável pela geração de energia elétrica e pela formação do lago que transformou a paisagem da cidade. A estrutura possui grandes turbinas hidráulicas e integração direta com a eclusa turística.",
                Category = "Cultura",
                ImageUrl = "",
                Address = "Barragem de Barra Bonita - Barra Bonita/SP",
                Schedule = "Visitação mediante agendamento",
                Latitude = -22.4876,
                Longitude = -48.5597,
                FunFact = "A usina ajudou a transformar Barra Bonita em referência no turismo fluvial!"
            },
            new Attraction
            {
                Id = 8,
                Name = "Ponte Campos Salles",
                Description = "A Ponte Campos Salles é um dos símbolos históricos e arquitetônicos de Barra Bonita. Construída em 1915 com estrutura metálica importada da Alemanha, ela conecta Barra Bonita ao município de Igaraçu do Tietê. A ponte possui grande importância histórica para o desenvolvimento regional.",
                Category = "Cultura",
                ImageUrl = "",
                Address = "Ligação Barra Bonita e Igaraçu do Tietê",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4889,
                Longitude = -48.5529,
                FunFact = "A estrutura metálica original veio da Alemanha!"
            },
            new Attraction
            {
                Id = 9,
                Name = "Centro Cultural Célia Stangherlin",
                Description = "O Centro Cultural Célia Stangherlin é um importante espaço de valorização artística e cultural de Barra Bonita. O local recebe exposições, apresentações musicais, oficinas culturais, palestras e eventos educativos voltados à comunidade.",
                Category = "Cultura",
                ImageUrl = "",
                Address = "Centro de Barra Bonita/SP",
                Schedule = "Segunda a Sexta, das 8h às 18h",
                Latitude = -22.4918,
                Longitude = -48.5568,
                FunFact = "O espaço recebe eventos culturais durante todo o ano!"
            },
            new Attraction
            {
                Id = 10,
                Name = "Lago de Barra Bonita",
                Description = "O Lago de Barra Bonita foi formado após a construção da barragem da usina hidrelétrica e se tornou uma das paisagens naturais mais famosas do interior paulista. O enorme espelho d’água é utilizado para turismo, lazer, pesca esportiva e esportes náuticos.",
                Category = "Natureza",
                ImageUrl = "",
                Address = "Rio Tietê - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4941,
                Longitude = -48.5538,
                FunFact = "O lago é famoso pelo belo pôr do sol!"
            },
            new Attraction
            {
                Id = 11,
                Name = "Mirante Barra Bonita",
                Description = "O Mirante Barra Bonita oferece uma vista privilegiada da cidade, do Rio Tietê e das áreas turísticas próximas à orla. O espaço é muito utilizado para contemplação da paisagem, registros fotográficos e apreciação do pôr do sol.",
                Category = "Natureza",
                ImageUrl = "",
                Address = "Região elevada da Orla - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4937,
                Longitude = -48.5543,
                FunFact = "O mirante é um dos locais preferidos para fotos panorâmicas!"
            },
            new Attraction
            {
                Id = 12,
                Name = "Mirante Ana Catharina Ortigosa Spaulonci",
                Description = "O Mirante Ana Catharina Ortigosa Spaulonci é um espaço turístico voltado à contemplação da paisagem natural de Barra Bonita. O local oferece ampla vista do Rio Tietê, do lago e das áreas verdes próximas à cidade.",
                Category = "Natureza",
                ImageUrl = "",
                Address = "Área turística de Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4954,
                Longitude = -48.5527,
                FunFact = "O local possui uma das melhores vistas do pôr do sol!"
            },
            new Attraction
            {
                Id = 13,
                Name = "Áreas Verdes e Orla Arborizada",
                Description = "As áreas verdes e a orla arborizada de Barra Bonita ajudam a compor o clima tranquilo e turístico da cidade. Próximas ao Rio Tietê, essas regiões oferecem espaços para caminhadas, ciclismo, descanso e convivência social.",
                Category = "Natureza",
                ImageUrl = "",
                Address = "Orla do Rio Tietê - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4928,
                Longitude = -48.5547,
                FunFact = "A arborização da orla ajuda a refrescar a região próxima ao rio!"
            },
            new Attraction
            {
                Id = 14,
                Name = "Orla Turística",
                Description = "A Orla Turística é um dos espaços mais movimentados de Barra Bonita e reúne lazer, gastronomia e contato com o Rio Tietê. O local possui calçadão, ciclovia, playground, quiosques e áreas destinadas a eventos culturais e turísticos.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Avenida Rosa Zanela Petri - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4917,
                Longitude = -48.5555,
                FunFact = "A orla recebe festivais e apresentações musicais!"
            },
            new Attraction
            {
                Id = 15,
                Name = "Praça do Artesanato",
                Description = "A Praça do Artesanato é um importante espaço de valorização cultural e econômica de Barra Bonita. O local reúne artesãos da cidade e da região, oferecendo peças em madeira, tecido, cerâmica, bordado e decoração.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Centro Turístico - Barra Bonita/SP",
                Schedule = "Sexta a Domingo, das 10h às 22h",
                Latitude = -22.4903,
                Longitude = -48.5569,
                FunFact = "Os produtos são feitos manualmente por artesãos locais!"
            },
            new Attraction
            {
                Id = 16,
                Name = "Teleférico",
                Description = "O teleférico de Barra Bonita é uma das atrações mais conhecidas da cidade. O passeio oferece uma vista panorâmica do Rio Tietê, da orla e das áreas turísticas próximas.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Parque Turístico Municipal - Barra Bonita/SP",
                Schedule = "Sábado e Domingo, das 9h às 18h",
                Latitude = -22.4931,
                Longitude = -48.5574,
                FunFact = "O teleférico possui aproximadamente 700 metros de percurso!"
            },
            new Attraction
            {
                Id = 17,
                Name = "Jardineira Turística",
                Description = "A Jardineira Turística realiza passeios pelos principais pontos turísticos de Barra Bonita, especialmente pela orla e pela região central da cidade.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Saída da Orla Turística - Barra Bonita/SP",
                Schedule = "Finais de semana e feriados, das 10h às 17h",
                Latitude = -22.4925,
                Longitude = -48.5559,
                FunFact = "É uma das atrações favoritas das crianças!"
            },
            new Attraction
            {
                Id = 18,
                Name = "Pedalinhos",
                Description = "Os pedalinhos fazem parte das atrações de lazer mais tradicionais de Barra Bonita, oferecendo aos visitantes uma experiência recreativa nas águas próximas à orla turística.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Orla Turística de Barra Bonita/SP",
                Schedule = "Todos os dias, das 9h às 18h",
                Latitude = -22.4919,
                Longitude = -48.5558,
                FunFact = "Os pedalinhos são muito procurados por famílias!"
            },
            new Attraction
            {
                Id = 19,
                Name = "Mini Cidade da Criança",
                Description = "A Mini Cidade da Criança é um espaço recreativo voltado ao lazer infantil, com estruturas que simulam uma pequena cidade em tamanho reduzido.",
                Category = "Lazer",
                ImageUrl = "",
                Address = "Parque Turístico Municipal - Barra Bonita/SP",
                Schedule = "Todos os dias, das 9h às 17h",
                Latitude = -22.4939,
                Longitude = -48.5567,
                FunFact = "O espaço foi criado especialmente para atividades infantis!"
            },
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