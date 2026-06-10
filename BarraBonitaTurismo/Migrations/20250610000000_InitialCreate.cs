using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarraBonitaTurismo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attractions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    Category = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Schedule = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Latitude = table.Column<double>(type: "double", nullable: true),
                    Longitude = table.Column<double>(type: "double", nullable: true),
                    FunFact = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Attractions", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Subject = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Message = table.Column<string>(type: "varchar(1000)", maxLength: 1000, nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsRead = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_ContactMessages", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    Location = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    IsFeatured = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EventType = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table => table.PrimaryKey("PK_Events", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FAQs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Question = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Answer = table.Column<string>(type: "longtext", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_FAQs", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "GuideItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: true),
                    Address = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    Phone = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true),
                    Website = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ImageUrl = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: true),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table => table.PrimaryKey("PK_GuideItems", x => x.Id))
                .Annotation("MySql:CharSet", "utf8mb4");

            // ── Seed: Atrações ────────────────────────────────────────────────
            migrationBuilder.InsertData("Attractions",
                new[] { "Id","Name","Description","Category","ImageUrl","Address","Schedule","Latitude","Longitude","FunFact" },
                new object[,]
                {
                    { 1, "Passeios de Barco", "Os passeios de barco representam a principal atividade turística de Barra Bonita e são considerados um dos maiores símbolos da cidade. As embarcações realizam trajetos pelo Rio Tietê, permitindo aos visitantes contemplar o lago formado pela barragem, áreas verdes, pontes, marinas e toda a paisagem fluvial da região.", "Náutica", "https://bagagemdespachada.com/wp-content/uploads/2020/05/barco_passeio_rio_tiete-scaled-e1604590105256.jpg", "Estrada do Lago, Km 5 - Barra Bonita/SP", "Quinta a Domingo, das 8h às 18h", -22.5012, -48.5456, "Os barcos turísticos passam pela famosa Eclusa de Barra Bonita!" },
                    { 2, "Eclusa de Barra Bonita", "A Eclusa de Barra Bonita é uma das estruturas turísticas e de engenharia mais importantes do estado de São Paulo. Construída junto à Usina Hidrelétrica, ela funciona como um elevador aquático responsável por permitir a passagem de embarcações entre diferentes níveis do Rio Tietê.", "Náutica", "https://i.ytimg.com/vi/9I-jQ2s5FaE/maxresdefault.jpg", "Usina Hidrelétrica de Barra Bonita - Barra Bonita/SP", "Todos os dias, das 8h às 17h", -22.4898, -48.5583, "É considerada a primeira eclusa turística da América do Sul!" },
                    { 3, "Orla Fluvial", "A Orla Fluvial de Barra Bonita é um dos espaços mais visitados da cidade e reúne turismo, lazer e contato direto com o Rio Tietê. O espaço conta com calçadão, bancos, iluminação noturna e áreas arborizadas.", "Náutica", "https://radardointerior.com.br/wp-content/uploads/2024/04/Fotos-artigos-RADAR-.png", "Avenida Rosa Zanela Petri - Barra Bonita/SP", "Aberto diariamente, 24 horas", -22.4915, -48.5564, "A orla é um dos locais mais frequentados da cidade durante o pôr do sol!" },
                    { 4, "Museu Municipal Luiz Saffi", "O Museu Municipal Luiz Saffi preserva grande parte da memória histórica e cultural de Barra Bonita. O museu reúne fotografias antigas, documentos históricos, objetos culturais e itens relacionados ao crescimento da região.", "Cultura", "https://static.wixstatic.com/media/6347c0_c6e1ad7d63864cc8a4131060ad8193d0~mv2.jpg/v1/fill/w_300,h_154,al_c,q_80,usm_0.66_1.00_0.01,enc_avif,quality_auto/20180115_123217_edited.jpg", "Rua Primeiro de Março, Centro - Barra Bonita/SP", "Terça a Sábado, das 9h às 17h", -22.4921, -48.5571, "O museu está instalado em um prédio histórico ligado à antiga ferrovia!" },
                    { 5, "Parque Turístico Municipal", "Espaço de lazer e recreação às margens do Rio Tietê, com área verde, quiosques, playground e estrutura para eventos ao ar livre.", "Lazer", "/images/atracoes/parque.jpg", "Parque Turístico Municipal - Barra Bonita/SP", "Todos os dias, das 9h às 17h", -22.4939, -48.5567, "O espaço foi criado especialmente para atividades infantis!" }
                });

            // ── Seed: Eventos ─────────────────────────────────────────────────
            migrationBuilder.InsertData("Events",
                new[] { "Id","Title","Description","StartDate","EndDate","Location","ImageUrl","IsFeatured","EventType" },
                new object[,]
                {
                    { 1, "Festa do Peixe", "Tradicional festival gastronômico com os melhores pratos à base de peixe da região, shows e atrações culturais.", new DateTime(2025,7,15), new DateTime(2025,7,30), "Centro de Eventos", "/images/eventos/peixe.jpg", true, "Gastronômico" },
                    { 2, "Regata do Lago", "Competição de barcos a vela e jet-ski com participação de atletas de todo o estado.", new DateTime(2025,8,20), new DateTime(2025,8,22), "Lago de Barra Bonita", "/images/eventos/regata.jpg", true, "Esportivo" },
                    { 3, "Aniversário da Cidade", "Desfile cívico, shows gratuitos e queima de fogos em comemoração ao aniversário de Barra Bonita.", new DateTime(2025,9,13), null, "Orla Fluvial", "/images/eventos/aniversario.jpg", true, "Cultural" },
                    { 4, "Festival de Inverno", "Apresentações de música clássica, teatro e exposições de arte.", new DateTime(2025,6,5), new DateTime(2025,6,25), "Teatro Municipal", "/images/eventos/inverno.jpg", false, "Cultural" },
                    { 5, "Natal Iluminado", "Decoração especial, coral natalino e chegada do Papai Noel.", new DateTime(2025,12,1), new DateTime(2025,12,25), "Praça Central", "/images/eventos/natal.jpg", false, "Cultural" }
                });

            // ── Seed: FAQs ────────────────────────────────────────────────────
            migrationBuilder.InsertData("FAQs",
                new[] { "Id","Question","Answer","Order" },
                new object[,]
                {
                    { 1, "Qual a melhor época para visitar Barra Bonita?", "A cidade é agradável o ano todo. O verão (dezembro a março) é ideal para atividades náuticas, enquanto o inverno (junho a agosto) tem temperaturas amenas para passeios ao ar livre.", 1 },
                    { 2, "Como chegar a Barra Bonita?", "A cidade está localizada a 280km de São Paulo, acesso pela Rodovia Marechal Rondon (SP-300) ou pela SP-191. Há também linhas de ônibus regulares da Viação Cometa e outras empresas.", 2 },
                    { 3, "Precisa pagar para acessar o Lago?", "Não, o acesso ao Lago e à Orla é gratuito. Apenas atividades como aluguel de barcos e passeios turísticos têm custo.", 3 },
                    { 4, "Onde se hospedar?", "A cidade conta com hotéis, pousadas e chalés às margens do lago. Recomendamos o Hotel Barra Bonita Resort, Pousada do Lago e Recanto do Pescador.", 4 },
                    { 5, "É permitido nadar no Lago?", "A natação é permitida apenas em áreas designadas e com supervisão. Recomendamos usar os clubes e praias artificiais para maior segurança.", 5 }
                });

            // ── Seed: GuideItems ──────────────────────────────────────────────
            migrationBuilder.InsertData("GuideItems",
                new[] { "Id","Type","Name","Description","Address","Phone","Website","ImageUrl","Rating" },
                new object[,]
                {
                    { 1,  "Hospedagem",  "Hotel Barra Bonita Resort",    "Resort completo com piscinas, sauna, academia e acesso direto ao lago.",             "Av. Beira Lago, 1000",               "(14) 3604-1234", "www.hotelbarrabonita.com", "/images/guia/resort.jpg",       5 },
                    { 2,  "Hospedagem",  "Pousada do Lago",              "Aconchegante pousada familiar com vista para o lago e café colonial.",               "Rua das Flores, 45",                 "(14) 3604-5678", "www.pousadadolago.com",    "/images/guia/pousada.jpg",      4 },
                    { 3,  "Hospedagem",  "Chalés Recanto do Pescador",   "Chalés rústicos com estrutura para pesca e churrasqueira.",                          "Estrada do Lago, Km 3",              "(14) 3604-9012", null,                       "/images/guia/chales.jpg",       4 },
                    { 4,  "Gastronomia", "Restaurante Peixe Vivo",       "Especializado em peixes do lago, com destaque para a moqueca e o peixe na telha.",  "Av. Marginal, 200",                  "(14) 3604-3456", "www.peixevivo.com",        "/images/guia/peixevivo.jpg",    5 },
                    { 5,  "Gastronomia", "Cantina Italiana Bella Vista", "Massas caseiras e pizzas artesanais com vista panorâmica.",                          "Rua Italia, 78",                     "(14) 3604-7890", null,                       "/images/guia/cantina.jpg",      4 },
                    { 6,  "Gastronomia", "Churrascaria do Lago",         "Rodízio de carnes nobres com buffet completo e música ao vivo aos finais de semana.","Av. Beira Lago, 500",                "(14) 3604-2345", null,                       "/images/guia/churrascaria.jpg", 5 },
                    { 7,  "Gastronomia", "Café Colonial da Vó",          "Café colonial com mais de 30 opções de doces, salgados e bolos caseiros.",           "Praça Central, 12",                  "(14) 3604-6789", null,                       "/images/guia/cafe.jpg",         4 },
                    { 8,  "Atividades",  "Aluguel de Barcos e Jet-skis", "Aluguel de lanchas, jet-skis, caiaques e pedalinhos.",                               "Marina Barra Bonita, Av. Beira Lago","(14) 3604-1111", "www.marinabarra.com",      "/images/guia/barcos.jpg",       5 },
                    { 9,  "Atividades",  "Passeio de Escuna",            "Passeio guiado pelo lago com parada para banho e almoço.",                           "Píer Turístico",                     "(14) 3604-2222", null,                       "/images/guia/escuna.jpg",       5 },
                    { 10, "Atividades",  "Trilhas Ecológicas",           "Trilhas monitoradas com guias especializados e observação de aves.",                  "Recanto Ecológico",                  "(14) 3604-3333", null,                       "/images/guia/trilhas.jpg",      4 },
                    { 11, "Atividades",  "Pesca Esportiva",              "Passeios de barco para pesca com equipamentos e iscas inclusos.",                    "Pesqueiro do Lago",                  "(14) 3604-4444", null,                       "/images/guia/pesca.jpg",        4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "Attractions");
            migrationBuilder.DropTable(name: "ContactMessages");
            migrationBuilder.DropTable(name: "Events");
            migrationBuilder.DropTable(name: "FAQs");
            migrationBuilder.DropTable(name: "GuideItems");
        }
    }
}
