using BarraBonitaTurismo.Models;

namespace BarraBonitaTurismo.Data
{
    /// <summary>
    /// Popula o banco com dados iniciais SOMENTE se as tabelas estiverem vazias.
    /// Assim as alterações feitas pelo painel admin persistem entre execuções.
    /// </summary>
    public static class DbInitializer
    {
        public static void Seed(AppDbContext db)
        {
            // ── Atrações ──────────────────────────────────────────────────────
            if (!db.Attractions.Any())
            {
                db.Attractions.AddRange(
                    new Attraction
                    {
                        Name = "Passeios de Barco",
                        Description = "Os passeios de barco representam a principal atividade turística de Barra Bonita e são considerados um dos maiores símbolos da cidade. As embarcações realizam trajetos pelo Rio Tietê, permitindo aos visitantes contemplar o Rio formado pela barragem, áreas verdes, pontes, marinas e toda a paisagem fluvial da região. Durante o passeio, os turistas podem acompanhar a movimentação da hidrovia e conhecer de perto a famosa Eclusa de Barra Bonita, experiência considerada única no interior paulista.",
                        Category = "Náutica",
                        ImageUrl = "https://bagagemdespachada.com/wp-content/uploads/2020/05/barco_passeio_rio_tiete-scaled-e1604590105256.jpg",
                        Address = "Estrada do Rio, Km 5 - Barra Bonita/SP",
                        Schedule = "Quinta a Domingo, das 8h às 18h",
                        Latitude = -22.5012,
                        Longitude = -48.5456,
                        FunFact = "Os barcos turísticos passam pela famosa Eclusa de Barra Bonita!"
                    },
                    new Attraction
                    {
                        Name = "Orla Fluvial",
                        Description = "A Orla Fluvial de Barra Bonita é um dos espaços mais visitados da cidade e reúne turismo, lazer e contato direto com o Rio Tietê. O espaço conta com calçadão, bancos, iluminação noturna, áreas arborizadas e vista privilegiada das embarcações turísticas.",
                        Category = "Náutica",
                        ImageUrl = "https://barrabonita.sp.gov.br/storage/turismo/pontos-turisticos/fmw6wneFGw.jpg",
                        Address = "Avenida Rosa Zanela Petri - Barra Bonita/SP",
                        Schedule = "Aberto diariamente, 24 horas",
                        Latitude = -22.4915,
                        Longitude = -48.5564,
                        FunFact = "A orla é um dos locais mais frequentados da cidade durante o pôr do sol!"
                    },
                    new Attraction
                    {
                        Name = "Museu Municipal Luiz Saffi",
                        Description = "O Museu Municipal Luiz Saffi preserva grande parte da memória histórica e cultural de Barra Bonita. O museu reúne fotografias antigas, documentos históricos, objetos culturais, móveis e itens relacionados ao crescimento econômico e turístico da região.",
                        Category = "Cultura",
                        ImageUrl = "https://c1.staticflickr.com/5/4904/46028552182_32ccaf5b9a_b.jpg",
                        Address = "Rua Primeiro de Março, Centro - Barra Bonita/SP",
                        Schedule = "Terça a Sábado, das 9h às 17h",
                        Latitude = -22.4921,
                        Longitude = -48.5571,
                        FunFact = "O museu está instalado em um prédio histórico ligado à antiga ferrovia!"
                    },
                    new Attraction
                    {
                        Name = "Marina da Barra",
                        Description = "Estrutura náutica localizada na orla turística de Barra Bonita, oferecendo suporte para embarcações de pequeno e médio porte, incluindo lanchas, jet-skis e veleiros. É um importante ponto de apoio para turistas que desejam explorar o Rio Tietê.",
                        Category = "Náutica",
                        ImageUrl = "https://macamp.com.br/guia/wp-content/uploads/2020/09/Apoio-RV-Marina-Vale-do-Tiete-Barra-Bonita8-scaled.jpg",
                        Address = "Orla da Avenida Pedro Ometto, 674 - Barra Bonita/SP",
                        Schedule = "Diariamente",
                        Latitude = -22.4895,
                        Longitude = -48.5520,
                        FunFact = "A marina possui capacidade para até 80 embarcações."
                    },
                    new Attraction
                    {
                        Name = "Píer e Atracadouro Municipal",
                        Description = "Local destinado à atracação de pequenas embarcações e contemplação do Rio Tietê. Possui estrutura acessível e é bastante procurado para apreciar o pôr do sol.",
                        Category = "Náutica",
                        ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/esportes-e-lazer/h8ajukAUZN.jpg",
                        Address = "Orla da Avenida Pedro Ometto - Barra Bonita/SP",
                        Schedule = "Aberto diariamente",
                        Latitude = -22.4902,
                        Longitude = -48.5548,
                        FunFact = "É considerado um dos melhores pontos para fotografar o Rio Tietê."
                    },
                    new Attraction
                    {
                        Name = "Usina Hidrelétrica de Barra Bonita",
                        Description = "Importante complexo energético localizado junto à barragem do Rio Tietê. Sua construção impulsionou o desenvolvimento da navegação e do turismo fluvial na região.",
                        Category = "Náutica",
                        ImageUrl = "https://static.brasilenergia.com.br/upload/2025/1/00e47a1bb8924ab78f55f97fecd2532a-770x0.jpg",
                        Address = "Rodovia Jaú–São Manoel, s/n - Barra Bonita/SP",
                        Schedule = "Visitação externa",
                        Latitude = -22.4890,
                        Longitude = -48.5590,
                        FunFact = "A eclusa turística funciona integrada à estrutura da usina."
                    },
                    new Attraction
                    {
                        Name = "Memorial do Rio Tietê",
                        Description = "Espaço cultural dedicado à preservação da história, biodiversidade e importância econômica do Rio Tietê, reunindo painéis, maquetes, equipamentos náuticos e documentos históricos.",
                        Category = "Cultura",
                        ImageUrl = "https://static.wixstatic.com/media/6347c0_ada3b74a0834446f870ada9108ec9682~mv2.jpg/v1/fill/w_320,h_217,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/J6pYr0Vfug_edited_edited.jpg",
                        Address = "Avenida Pedro Ometto, 467 - Barra Bonita/SP",
                        Schedule = "Todos os dias, das 8h às 18h",
                        Latitude = -22.4910,
                        Longitude = -48.5550,
                        FunFact = "Recebe cerca de 30 mil estudantes por ano em visitas educativas."
                    },
                    new Attraction
                    {
                        Name = "Teatro Municipal Professora Zita de Marchi",
                        Description = "Principal espaço cultural da cidade, recebendo apresentações de teatro, dança, música, festivais e eventos artísticos ao longo do ano.",
                        Category = "Cultura",
                        ImageUrl = "https://barrabonita.sp.gov.br/storage/prefeitura/predios-municipais/GyoBLLtpOe.jpg",
                        Address = "Rua João Gerin, 222 - Vila Operária - Barra Bonita/SP",
                        Schedule = "Conforme programação cultural",
                        Latitude = -22.4942,
                        Longitude = -48.5588,
                        FunFact = "É palco de importantes festivais culturais da região."
                    },
                    new Attraction
                    {
                        Name = "Praça da Marinha",
                        Description = "Área arborizada na orla turística que reúne monumentos históricos da Marinha do Brasil e oferece vista privilegiada do Rio Tietê.",
                        Category = "Natureza",
                        ImageUrl = "https://conteudo.solutudo.com.br/wp-content/uploads/2022/01/2-2-1024x683.jpg",
                        Address = "Avenida Rosa Zanela Petri - Barra Bonita/SP",
                        Schedule = "Aberto diariamente",
                        Latitude = -22.4905,
                        Longitude = -48.5555,
                        FunFact = "Possui equipamentos militares históricos expostos ao público."
                    },
                    new Attraction
                    {
                        Name = "Praça do Teleférico",
                        Description = "Parque turístico municipal com lago para pedalinhos, área de eventos, quiosques e o tradicional teleférico que atravessa o parque.",
                        Category = "Lazer",
                        ImageUrl = "https://dynamic-media-cdn.tripadvisor.com/media/photo-o/16/1f/06/e2/teleferico-de-barra-bonita.jpg?w=1200&h=-1&s=1",
                        Address = "Orla Turística - Centro - Barra Bonita/SP",
                        Schedule = "Aberto diariamente",
                        Latitude = -22.4918,
                        Longitude = -48.5556,
                        FunFact = "O teleférico possui aproximadamente 700 metros de percurso."
                    },
                    new Attraction
                    {
                        Name = "Minicidade da Criança",
                        Description = "Espaço infantil localizado na orla turística com réplicas de construções, playground e atrações voltadas para crianças.",
                        Category = "Lazer",
                        ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/planejamento-urbano-e-obras/4A50aeSvMW.jpg",
                        Address = "Praça do Teleférico - Barra Bonita/SP",
                        Schedule = "Aberto diariamente",
                        Latitude = -22.4916,
                        Longitude = -48.5557,
                        FunFact = "Abriga réplicas de construções em escala infantil."
                    },
                    new Attraction
                    {
                        Name = "Praça da Juventude",
                        Description = "Área de esportes e recreação com pista de skate, quadras, campos de areia, espaços de convivência e opções de alimentação.",
                        Category = "Lazer",
                        ImageUrl = "https://barrabonita.sp.gov.br/storage/noticias/planejamento-urbano-e-obras/EQlu8sa2FpNf6ZDeb8CkpAQuAiFhtNBcyBOPpkuQ.jpg",
                        Address = "Orla da Avenida Pedro Ometto - Barra Bonita/SP",
                        Schedule = "Aberto diariamente",
                        Latitude = -22.4924,
                        Longitude = -48.5560,
                        FunFact = "É um dos principais pontos de encontro dos jovens da cidade."
                    }
                );
                db.SaveChanges();
            }

            // ── Eventos ───────────────────────────────────────────────────────
            if (!db.Events.Any())
            {
                db.Events.AddRange(
                    new Event
                    {
                        Title = "Festa do Peixe",
                        Description = "Tradicional festival gastronômico com os melhores pratos à base de peixe da região, shows e atrações culturais.",
                        StartDate = new DateTime(2025, 7, 15),
                        EndDate = new DateTime(2025, 7, 30),
                        Location = "Centro de Eventos",
                        ImageUrl = "https://images.unsplash.com/photo-1504674900247-0877df9cc836?w=600&q=80",
                        Color = "#383939",
                        IsFeatured = true,
                        EventType = "Gastronômico"
                    },
                    new Event
                    {
                        Title = "Regata do Rio",
                        Description = "Competição de barcos a vela e jet-ski com participação de atletas de todo o estado.",
                        StartDate = new DateTime(2025, 8, 20),
                        EndDate = new DateTime(2025, 8, 22),
                        Location = "Rio de Barra Bonita",
                        ImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=600&q=80",
                        Color = "#8B5CF6",
                        IsFeatured = true,
                        EventType = "Esportivo"
                    },
                    new Event
                    {
                        Title = "Aniversário da Cidade",
                        Description = "Desfile cívico, shows gratuitos e queima de fogos em comemoração ao aniversário de Barra Bonita.",
                        StartDate = new DateTime(2025, 9, 13),
                        EndDate = null,
                        Location = "Orla Fluvial",
                        ImageUrl = "https://images.unsplash.com/photo-1467810563316-b5476525c0f9?w=600&q=80",
                        Color = "#0EA5E9",
                        IsFeatured = true,
                        EventType = "Cultural"
                    },
                    new Event
                    {
                        Title = "Festival de Inverno",
                        Description = "Apresentações de música clássica, teatro e exposições de arte.",
                        StartDate = new DateTime(2025, 6, 5),
                        EndDate = new DateTime(2025, 6, 25),
                        Location = "Teatro Municipal",
                        ImageUrl = "https://images.unsplash.com/photo-1514320291840-2e0a9bf2a9ae?w=600&q=80",
                        Color = "#FF5A00",
                        IsFeatured = false,
                        EventType = "Cultural"
                    },
                    new Event
                    {
                        Title = "Natal Iluminado",
                        Description = "Decoração especial, coral natalino e chegada do Papai Noel.",
                        StartDate = new DateTime(2025, 12, 1),
                        EndDate = new DateTime(2025, 12, 25),
                        Location = "Praça Central",
                        ImageUrl = "https://images.unsplash.com/photo-1512389142860-9c449e58a543?w=600&q=80",
                        Color = "#4e051c",
                        IsFeatured = false,
                        EventType = "Cultural"
                    }
                );
                db.SaveChanges();
            }

            // ── FAQs ──────────────────────────────────────────────────────────
            if (!db.FAQs.Any())
            {
                db.FAQs.AddRange(
                    new FAQ { Question = "Qual a melhor época para visitar Barra Bonita?", Answer = "A cidade é agradável o ano todo. O verão (dezembro a março) é ideal para atividades náuticas, enquanto o inverno (junho a agosto) tem temperaturas amenas para passeios ao ar livre.", Order = 1 },
                    new FAQ { Question = "Como chegar a Barra Bonita?", Answer = "A cidade está localizada a 280km de São Paulo, acesso pela Rodovia Marechal Rondon (SP-300) ou pela SP-191. Há também linhas de ônibus regulares da Viação Cometa e outras empresas.", Order = 2 },
                    new FAQ { Question = "Precisa pagar para acessar o Rio?", Answer = "Não, o acesso ao Rio e à Orla é gratuito. Apenas atividades como aluguel de barcos e passeios turísticos têm custo.", Order = 3 },
                    new FAQ { Question = "Onde se hospedar?", Answer = "A cidade conta com hotéis, pousadas e chalés às margens do Rio. Recomendamos o Hotel Barra Bonita Resort, Pousada do Rio e Recanto do Pescador.", Order = 4 },
                    new FAQ { Question = "É permitido nadar no Rio?", Answer = "A natação é permitida apenas em áreas designadas e com supervisão. Recomendamos usar os clubes e praias artificiais para maior segurança.", Order = 5 }
                );
                db.SaveChanges();
            }

            // ── Guia Turístico ────────────────────────────────────────────────
            if (!db.GuideItems.Any())
            {
                db.GuideItems.AddRange(
                    new GuideItem { Type = "Hospedagem", Name = "Hotel Barra Bonita Resort", Description = "Resort completo com piscinas, sauna, academia e acesso direto ao Rio.", Address = "Av. Beira Rio, 1000", Phone = "(14) 3604-1234", Website = "www.hotelbarrabonita.com", ImageUrl = "https://images.unsplash.com/photo-1566073771259-6a8506099945?w=400&q=80", Rating = 5 },
                    new GuideItem { Type = "Hospedagem", Name = "Pousada do Rio", Description = "Aconchegante pousada familiar com vista para o Rio e café colonial.", Address = "Rua das Flores, 45", Phone = "(14) 3604-5678", Website = "www.pousadadoRio.com", ImageUrl = "https://images.unsplash.com/photo-1510798831971-661eb04b3739?w=400&q=80", Rating = 4 },
                    new GuideItem { Type = "Hospedagem", Name = "Chalés Recanto do Pescador", Description = "Chalés rústicos com estrutura para pesca e churrasqueira.", Address = "Estrada do Rio, Km 3", Phone = "(14) 3604-9012", Website = null, ImageUrl = "https://images.unsplash.com/photo-1449158743715-0a90ebb6d2d8?w=400&q=80", Rating = 4 },
                    new GuideItem { Type = "Gastronomia", Name = "Restaurante Peixe Vivo", Description = "Especializado em peixes do Rio, com destaque para a moqueca e o peixe na telha.", Address = "Av. Marginal, 200", Phone = "(14) 3604-3456", Website = "www.peixevivo.com", ImageUrl = "https://images.unsplash.com/photo-1519708227418-c8fd9a32b7a2?w=400&q=80", Rating = 5 },
                    new GuideItem { Type = "Gastronomia", Name = "Cantina Italiana Bella Vista", Description = "Massas caseiras e pizzas artesanais com vista panorâmica.", Address = "Rua Italia, 78", Phone = "(14) 3604-7890", Website = null, ImageUrl = "https://images.unsplash.com/photo-1555396273-367ea4eb4db5?w=400&q=80", Rating = 4 },
                    new GuideItem { Type = "Gastronomia", Name = "Churrascaria do Rio", Description = "Rodízio de carnes nobres com buffet completo e música ao vivo aos finais de semana.", Address = "Av. Beira Rio, 500", Phone = "(14) 3604-2345", Website = null, ImageUrl = "https://images.unsplash.com/photo-1558030006-450675393462?w=400&q=80", Rating = 5 },
                    new GuideItem { Type = "Gastronomia", Name = "Café Colonial da Vó", Description = "Café colonial com mais de 30 opções de doces, salgados e bolos caseiros.", Address = "Praça Central, 12", Phone = "(14) 3604-6789", Website = null, ImageUrl = "https://images.unsplash.com/photo-1521017432531-fbd92d768814?w=400&q=80", Rating = 4 },
                    new GuideItem { Type = "Atividades", Name = "Aluguel de Barcos e Jet-skis", Description = "Aluguel de lanchas, jet-skis, caiaques e pedalinhos.", Address = "Marina Barra Bonita, Av. Beira Rio", Phone = "(14) 3604-1111", Website = "www.marinabarra.com", ImageUrl = "https://images.unsplash.com/photo-1544551763-46a013bb70d5?w=400&q=80", Rating = 5 },
                    new GuideItem { Type = "Atividades", Name = "Passeio de Escuna", Description = "Passeio guiado pelo Rio com parada para banho e almoço.", Address = "Píer Turístico", Phone = "(14) 3604-2222", Website = null, ImageUrl = "https://images.unsplash.com/photo-1501854140801-50d01698950b?w=400&q=80", Rating = 5 },
                    new GuideItem { Type = "Atividades", Name = "Trilhas Ecológicas", Description = "Trilhas monitoradas com guias especializados e observação de aves.", Address = "Recanto Ecológico", Phone = "(14) 3604-3333", Website = null, ImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=400&q=80", Rating = 4 },
                    new GuideItem { Type = "Atividades", Name = "Pesca Esportiva", Description = "Passeios de barco para pesca com equipamentos e iscas inclusos.", Address = "Pesqueiro do Rio", Phone = "(14) 3604-4444", Website = null, ImageUrl = "https://images.unsplash.com/photo-1500909019491-73dc3c1f8086?w=400&q=80", Rating = 4 }
                );
                db.SaveChanges();
            }
        }
    }
}
