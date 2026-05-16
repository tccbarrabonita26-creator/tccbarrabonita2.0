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
                Foundation = "13 de setembro de 1886",
                Population = "35.000 habitantes",
                Area = "146 km²",
                Slogan = "Capital Náutica do Interior Paulista",
                History = @"Barra Bonita foi fundada em 13 de setembro de 1886 por José Theodoro de Souza e outros pioneiros. O nome 'Barra Bonita' origina-se da bela confluência dos rios Tietê e Piracicaba, formando um local de rara beleza natural. A cidade cresceu às margens do Rio Tietê e se tornou um importante polo turístico e econômico da região. <br/><br/> Na década de 1960, com a construção da Usina Hidrelétrica de Barra Bonita, a cidade ganhou ainda mais destaque, formando o famoso Lago de Barra Bonita, que hoje é o principal cartão-postal e atração turística da região.",
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
                Description = "Os passeios de barco representam a principal atividade turística de Barra Bonita e são considerados um dos maiores símbolos da cidade. As embarcações realizam trajetos pelo Rio Tietê, permitindo aos visitantes contemplar o lago formado pela barragem, áreas verdes, pontes, marinas e toda a paisagem fluvial da região. Durante o passeio, os turistas podem acompanhar a movimentação da hidrovia e conhecer de perto a famosa Eclusa de Barra Bonita, experiência considerada única no interior paulista. Muitos barcos oferecem estrutura completa com restaurante, música ao vivo, apresentações temáticas e espaços de convivência, tornando o passeio uma experiência de lazer, turismo e contemplação da natureza.",
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
                Description = "A Eclusa de Barra Bonita é uma das estruturas turísticas e de engenharia mais importantes do estado de São Paulo. Construída junto à Usina Hidrelétrica, ela funciona como um elevador aquático responsável por permitir a passagem de embarcações entre diferentes níveis do Rio Tietê. O processo de eclusagem impressiona turistas pela quantidade de água movimentada e pela dimensão da estrutura. Além de possuir importância para a navegação fluvial brasileira, a eclusa se tornou um dos principais cartões-postais de Barra Bonita e uma das experiências mais procuradas pelos visitantes da cidade.",
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
                Description = "A Orla Fluvial de Barra Bonita é um dos espaços mais visitados da cidade e reúne turismo, lazer e contato direto com o Rio Tietê. Localizada às margens do rio, a orla oferece ampla estrutura para caminhadas, ciclismo, descanso e contemplação da paisagem fluvial. O espaço conta com calçadão, bancos, iluminação noturna, áreas arborizadas e vista privilegiada das embarcações turísticas que circulam pela hidrovia. Além disso, a região concentra restaurantes, quiosques e áreas de convivência utilizadas tanto por moradores quanto por turistas durante todo o ano.",
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
                Description = "O Museu Municipal Luiz Saffi preserva grande parte da memória histórica e cultural de Barra Bonita. Instalado em um prédio histórico ligado ao antigo desenvolvimento ferroviário da cidade, o museu reúne fotografias antigas, documentos históricos, objetos culturais, móveis e itens relacionados ao crescimento econômico e turístico da região. O espaço permite aos visitantes conhecer melhor a evolução de Barra Bonita, sua ligação com o Rio Tietê e a importância da navegação e da ferrovia para o desenvolvimento local.",
                Category = "Cultura",
                ImageUrl = "https://static.wixstatic.com/media/6347c0_c6e1ad7d63864cc8a4131060ad8193d0~mv2.jpg/v1/fill/w_300,h_154,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/20180115_123217_edited.jpg",
                Address = "Rua Primeiro de Março, Centro - Barra Bonita/SP",
                Schedule = "Segunda a Sexta, das 9h às 17h",
                Latitude = -22.4909,
                Longitude = -48.5578,
                FunFact = "O museu funciona em um prédio histórico ligado à antiga ferrovia!"
            },
            new Attraction
            {
                Id = 5,
                Name = "Memorial do Rio Tietê",
                Description = "O Memorial do Rio Tietê é um espaço cultural e educativo voltado à valorização histórica, ambiental e econômica do Rio Tietê. O local apresenta painéis informativos, fotografias históricas, maquetes, equipamentos náuticos e conteúdos educativos relacionados à navegação fluvial e à preservação ambiental. O memorial busca conscientizar visitantes sobre a importância do rio para o desenvolvimento de Barra Bonita e de diversas cidades do estado de São Paulo, além de destacar o turismo fluvial como parte fundamental da identidade cultural da região.",
                Category = "Cultura",
                ImageUrl = "https://images.openai.com/static-rsc-4/JzvyWYBfLRqy5fLvwoAtcFrR1r-EP19RJG-27R7QEbbTqNy1QrRwuwnmygrUNNkUcPCAeehpzgIbdGqw7nAgUV7yJgabbLNtbH3Ivc-FHi1dUk_WdHsnooJb4W-ZrgOtGLYgnSN2WuYJn_sJ_pCLHk5C8Pfrb3Zym64FliZ-x1xbhZ3TUXTdblIsj4xzukBJ?purpose=fullsize",
                Address = "Orla Turística - Barra Bonita/SP",
                Schedule = "Terça a Domingo, das 9h às 18h",
                Latitude = -22.4922,
                Longitude = -48.5551,
                FunFact = "O espaço promove atividades de conscientização ambiental!"
            },
            new Attraction
            {
                Id = 6,
                Name = "Usina Hidrelétrica de Barra Bonita",
                Description = "A Usina Hidrelétrica de Barra Bonita é uma das obras de engenharia mais importantes do interior paulista e possui papel fundamental no desenvolvimento econômico e turístico da cidade. Construída sobre o Rio Tietê, a usina é responsável pela geração de energia elétrica e pela formação do lago que transformou a paisagem da região. Sua estrutura possui grandes turbinas hidráulicas e integração direta com a Eclusa de Barra Bonita, tornando o local um importante ponto de interesse para turistas que desejam conhecer mais sobre energia, navegação e engenharia fluvial.",
                Category = "Cultura",
                ImageUrl = "https://s02.video.glbimg.com/x216/12032749.jpg",
                Address = "Barragem de Barra Bonita - Barra Bonita/SP",
                Schedule = "Visitação mediante agendamento",
                Latitude = -22.4876,
                Longitude = -48.5597,
                FunFact = "A usina ajudou a transformar Barra Bonita em referência no turismo fluvial!"
            },
            new Attraction
            {
                Id = 7,
                Name = "Ponte Campos Salles",
                Description = "A Ponte Campos Salles é um dos principais patrimônios históricos e arquitetônicos de Barra Bonita. Inaugurada em 1915, a ponte metálica conecta Barra Bonita ao município de Igaraçu do Tietê e possui estrutura importada da Alemanha. Além de sua importância para o desenvolvimento regional, a ponte se tornou um símbolo histórico da cidade e um dos cenários mais conhecidos da região. O local também oferece bela vista do Rio Tietê e das áreas próximas à orla turística.",
                Category = "Cultura",
                ImageUrl = "https://conteudo.solutudo.com.br/wp-content/uploads/2022/03/269696364_137157208696085_988517361013370868_n.jpg",
                Address = "Ligação Barra Bonita e Igaraçu do Tietê",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4889,
                Longitude = -48.5529,
                FunFact = "A estrutura metálica original veio da Alemanha!"
            },
            new Attraction
            {
                Id = 8,
                Name = "Centro Cultural Célia Stangherlin",
                Description = "O Centro Cultural Célia Stangherlin é um espaço dedicado à valorização artística, cultural e educativa de Barra Bonita. O local recebe exposições, apresentações musicais, oficinas culturais, palestras e eventos voltados à comunidade e aos visitantes. O espaço também contribui para o incentivo às manifestações artísticas locais e para a realização de atividades culturais durante diferentes períodos do ano.",
                Category = "Cultura",
                ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/desenvolvimento-economico/J6pYr0Vfug.jpg",
                Address = "Centro de Barra Bonita/SP",
                Schedule = "Segunda a Sexta, das 8h às 18h",
                Latitude = -22.4918,
                Longitude = -48.5568,
                FunFact = "O espaço recebe eventos culturais durante todo o ano!"
            },
            new Attraction
            {
                Id = 9,
                Name = "Rio Tietê",
                Description = "O Rio Tietê é um dos principais símbolos naturais e turísticos de Barra Bonita. Suas águas são responsáveis pela formação da paisagem fluvial que caracteriza a cidade e atrai visitantes durante todo o ano. Além da importância histórica e econômica para a navegação e geração de energia, o rio é amplamente utilizado para passeios turísticos, esportes náuticos, pesca esportiva e atividades de lazer. Em Barra Bonita, o Rio Tietê se tornou um dos maiores cartões-postais da região, oferecendo belas paisagens e experiências ligadas ao turismo fluvial.",
                Category = "Natureza",
                ImageUrl = "https://images.openai.com/static-rsc-4/2erMYNeutCQO96SosttlgUwG4wqPjV8LzEp2eI9cqX4yVu_RJ4b4ODUS-fTa_moNA8W5KEhGexiRuwoyhMCTe70pQcdwAD7tTw81E7g2l4_oO3kCIiuCZZa_WjL7RkQejEnXNt5Vr_Qt0ReLSAzrlVjYn7eubvF4L8y4XP022hRivadyvzQHcBF2_odiSLWL?purpose=fullsize",
                Address = "Rio Tietê - Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4908,
                Longitude = -48.5562,
                FunFact = "O Rio Tietê em Barra Bonita é um dos principais pontos do turismo fluvial paulista."
            },
            new Attraction
            {
                Id = 10,
                Name = "Mirante Ana Catharina Ortigosa Spaulonci",
                Description = "O Mirante Ana Catharina Ortigosa Spaulonci é um espaço turístico voltado à contemplação da paisagem natural de Barra Bonita. O local oferece vista privilegiada do Rio Tietê, das áreas verdes e da região turística da cidade, sendo muito procurado por moradores e visitantes durante o pôr do sol. O ambiente proporciona tranquilidade, contato com a natureza e um espaço ideal para descanso, fotografia e apreciação da paisagem urbana e fluvial.",
                Category = "Lazer",
                ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/turismo/8uyNwHk7LAR4zNYtzw945zpuQpMptzTWDTNErYsJ.jpg",
                Address = "Área turística de Barra Bonita/SP",
                Schedule = "Aberto diariamente, 24 horas",
                Latitude = -22.4954,
                Longitude = -48.5527,
                FunFact = "O local possui uma das melhores vistas do pôr do sol!"
            },
            new Attraction
            {
                Id = 11,
                Name = "Praça do Artesanato",
                Description = "A Praça do Artesanato é um importante espaço de valorização cultural e econômica de Barra Bonita. O local reúne artesãos da cidade e da região, oferecendo produtos feitos manualmente, como peças em madeira, tecidos, bordados, cerâmicas e artigos decorativos. Além de incentivar o comércio local, a praça se tornou um ponto turístico bastante visitado por moradores e turistas em busca de lembranças e produtos típicos da cidade.",
                Category = "Lazer",
                ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/planejamento-urbano-e-obras/swsqwpB3cFeDWQFXlb6AYZFsaLYqBKmHNeBkmpUc.jpg",
                Address = "Centro Turístico - Barra Bonita/SP",
                Schedule = "Sexta a Domingo, das 10h às 22h",
                Latitude = -22.4903,
                Longitude = -48.5569,
                FunFact = "Os produtos são feitos manualmente por artesãos locais!"
            },
            new Attraction
            {
                Id = 12,
                Name = "Teleférico",
                Description = "O Teleférico de Barra Bonita é uma das atrações mais conhecidas e tradicionais da cidade. O passeio oferece uma vista panorâmica do Rio Tietê, da orla turística e das áreas próximas ao complexo turístico municipal. Durante o trajeto, os visitantes podem observar a paisagem fluvial e diferentes pontos da cidade de uma perspectiva elevada, tornando a experiência uma das mais procuradas por turistas que visitam Barra Bonita.",
                Category = "Lazer",
                ImageUrl = "https://barrabonita.sp.gov.br/storage/turismo/pontos-turisticos/ELqeSjHRFF.jpg",
                Address = "Parque Turístico Municipal - Barra Bonita/SP",
                Schedule = "Sábado e Domingo, das 9h às 18h",
                Latitude = -22.4931,
                Longitude = -48.5574,
                FunFact = "O teleférico possui aproximadamente 700 metros de percurso!"
            },
            new Attraction
            {
                Id = 13,
                Name = "Bonde Turístico",
                Description = "O Bonde Turístico de Barra Bonita realiza passeios recreativos pelos principais pontos turísticos da cidade, proporcionando uma experiência divertida e descontraída para visitantes de todas as idades. O trajeto percorre regiões próximas à orla, áreas centrais e espaços turísticos, permitindo aos turistas conhecer melhor a cidade enquanto aproveitam o passeio temático. O bonde é bastante procurado por famílias e visitantes durante finais de semana e períodos de maior movimento turístico.",
                Category = "Lazer",
                ImageUrl = "https://images.openai.com/static-rsc-4/U3HKOGgjD_ImgO2ZNHcvynoyR42gyvbM6tfm-3Agha5Xsbfbf-UBZfkNHTPtMf0H0SRweGlgNV_d8R-zySAepx69K9rJwh8JpIEEjXEa3apoqnngZmimBXzTkD6ENhynScOJ-3__YFfiSh9nensCd6EA4NAARF-lJQ3AdzLC7BVCajjV1ExDegw6AVLYRRgc?purpose=fullsize",
                Address = "Saída da Orla Turística - Barra Bonita/SP",
                Schedule = "Finais de semana e feriados, das 10h às 17h",
                Latitude = -22.4925,
                Longitude = -48.5559,
                FunFact = "É uma das atrações favoritas das crianças!"
            },
            new Attraction
            {
                Id = 14,
                Name = "Lago dos Pedalinhos",
                Description = "O Lago dos Pedalinhos é uma atração recreativa bastante procurada por famílias e visitantes em Barra Bonita. Localizado próximo à área turística da cidade, o espaço oferece passeios de pedalinho em um ambiente tranquilo e voltado ao lazer. A atividade proporciona contato com a água, diversão ao ar livre e momentos de descanso, sendo especialmente frequentada por crianças e turistas durante finais de semana e feriados.",
                Category = "Lazer",
                ImageUrl = "https://www.brasilvip.net/wp-content/uploads/2013/09/pedalinho-barra-bonita.jpg",
                Address = "Orla Turística de Barra Bonita/SP",
                Schedule = "Todos os dias, das 9h às 18h",
                Latitude = -22.4919,
                Longitude = -48.5558,
                FunFact = "Os pedalinhos são muito procurados por famílias!"
            },
            new Attraction
            {
                Id = 15,
                Name = "Mini Cidade da Criança",
                Description = "A Mini Cidade da Criança é um espaço recreativo voltado ao lazer infantil e ao entretenimento familiar em Barra Bonita. O local possui estruturas que simulam uma pequena cidade em tamanho reduzido, permitindo que as crianças explorem ambientes lúdicos e educativos de forma divertida e interativa. A atração é bastante frequentada por famílias e se tornou um importante espaço de recreação infantil dentro do complexo turístico da cidade.",
                Category = "Lazer",
                ImageUrl = "https://solutudo-cdn.s3-sa-east-1.amazonaws.com/prod/plc_places/2734/6203d7d1-7de0-4157-bc80-7fa5ac1e09ff.jpg",
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