using BarraBonitaTurismo.Data;
using System.Globalization;
using System.Text;

namespace BarraBonitaTurismo.Services
{
    /// <summary>
    /// Regrava o seed_inicial.sql com o estado atual do banco
    /// toda vez que uma operação de escrita é feita no painel admin.
    /// </summary>
    public class SeedExporter
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public SeedExporter(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public void Export()
        {
            try
            {
                var attractions = _db.Attractions.OrderBy(a => a.Id).ToList();
                var events = _db.Events.OrderBy(e => e.Id).ToList();
                var faqs = _db.FAQs.OrderBy(f => f.Order).ToList();
                var guide = _db.GuideItems.OrderBy(g => g.Id).ToList();

                var sb = new StringBuilder();
                sb.AppendLine("-- ============================================================");
                sb.AppendLine("-- SCRIPT DE DADOS INICIAIS - BARRA BONITA TURISMO");
                sb.AppendLine($"-- Gerado automaticamente em {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine("-- Execute este script UMA ÚNICA VEZ após criar o banco.");
                sb.AppendLine("-- ============================================================");
                sb.AppendLine();
                sb.AppendLine("USE barrabonita;");
                sb.AppendLine();

                // ── Atrações ──────────────────────────────────────────────────
                sb.AppendLine("-- ── Atrações ──────────────────────────────────────────────────");
                if (attractions.Any())
                {
                    sb.AppendLine("INSERT INTO Attractions (Name, Description, Category, ImageUrl, Address, Schedule, Latitude, Longitude, FunFact) VALUES");
                    var rows = attractions.Select(a =>
                        $"({Str(a.Name)}, {Str(a.Description)}, {Str(a.Category)}, {Str(a.ImageUrl)}, {Str(a.Address)}, {Str(a.Schedule)}, {Dbl(a.Latitude)}, {Dbl(a.Longitude)}, {Str(a.FunFact)})"
                    );
                    sb.AppendLine(string.Join(",\n", rows) + ";");
                }
                else
                {
                    sb.AppendLine("-- (nenhuma atração cadastrada)");
                }
                sb.AppendLine();

                // ── Eventos ───────────────────────────────────────────────────
                sb.AppendLine("-- ── Eventos ─────────────────────────────────────────────────");
                if (events.Any())
                {
                    sb.AppendLine("INSERT INTO Events (Title, Description, StartDate, EndDate, Location, ImageUrl, Color, IsFeatured, EventType) VALUES");
                    var rows = events.Select(e =>
                        $"({Str(e.Title)}, {Str(e.Description)}, {Date(e.StartDate)}, {NullableDate(e.EndDate)}, {Str(e.Location)}, {Str(e.ImageUrl)}, {Str(e.Color)}, {Bool(e.IsFeatured)}, {Str(e.EventType)})"
                    );
                    sb.AppendLine(string.Join(",\n", rows) + ";");
                }
                else
                {
                    sb.AppendLine("-- (nenhum evento cadastrado)");
                }
                sb.AppendLine();

                // ── FAQs ──────────────────────────────────────────────────────
                sb.AppendLine("-- ── FAQs ────────────────────────────────────────────────────");
                if (faqs.Any())
                {
                    sb.AppendLine("INSERT INTO FAQs (Question, Answer, `Order`) VALUES");
                    var rows = faqs.Select(f =>
                        $"({Str(f.Question)}, {Str(f.Answer)}, {f.Order})"
                    );
                    sb.AppendLine(string.Join(",\n", rows) + ";");
                }
                else
                {
                    sb.AppendLine("-- (nenhuma FAQ cadastrada)");
                }
                sb.AppendLine();

                // ── Guia ──────────────────────────────────────────────────────
                sb.AppendLine("-- ── Guia Turístico ──────────────────────────────────────────");
                if (guide.Any())
                {
                    sb.AppendLine("INSERT INTO GuideItems (Type, Name, Description, Address, Phone, Website, ImageUrl, Rating) VALUES");
                    var rows = guide.Select(g =>
                        $"({Str(g.Type)}, {Str(g.Name)}, {Str(g.Description)}, {Str(g.Address)}, {Str(g.Phone)}, {Str(g.Website)}, {Str(g.ImageUrl)}, {g.Rating})"
                    );
                    sb.AppendLine(string.Join(",\n", rows) + ";");
                }
                else
                {
                    sb.AppendLine("-- (nenhum item de guia cadastrado)");
                }

                // Salva na raiz do projeto (dois níveis acima do wwwroot)
                var projectRoot = Path.GetFullPath(Path.Combine(_env.ContentRootPath, ".."));
                var filePath = Path.Combine(projectRoot, "seed_inicial.sql");
                File.WriteAllText(filePath, sb.ToString(), Encoding.UTF8);
            }
            catch
            {
                // Falha silenciosa: não interrompe o fluxo do admin se o arquivo não puder ser escrito
            }
        }

        // ── Helpers de escape SQL ─────────────────────────────────────────────
        private static string Str(string? value)
            => value == null ? "NULL" : "'" + value.Replace("'", "''").Replace("\\", "\\\\") + "'";

        private static string Dbl(double? value)
            => value.HasValue ? value.Value.ToString("F6", CultureInfo.InvariantCulture) : "NULL";

        private static string Date(DateTime date)
            => "'" + date.ToString("yyyy-MM-dd") + "'";

        private static string NullableDate(DateTime? date)
            => date.HasValue ? "'" + date.Value.ToString("yyyy-MM-dd") + "'" : "NULL";

        private static string Bool(bool value)
            => value ? "1" : "0";
    }
}
