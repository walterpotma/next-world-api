using System.ComponentModel.DataAnnotations.Schema;

namespace next_world_api.Model
{
    [Table("hq")]
    public class Hq
    {
        public int id { get; set; }

        public string? nome { get; set; }

        public string? autor { get; set; }

        public string? resumo { get; set; }

        public List<string>? generos { get; set; }

        public double nota { get; set; }

        public string? capa { get; set; }

        public string? banner { get; set; }

        public string? status { get; set; }
        // niveis de status, andamento, concluido, pausada

        public DateTime created_at { get; set; }
    }
}
