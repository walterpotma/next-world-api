using System.ComponentModel.DataAnnotations.Schema;

namespace next_world_api.Model
{
    [Table("paginas")]
    public class Paginas
    {
        public int id { get; set; }

        public int capitulo_id { get; set; }

        public int numero_page { get; set; }

        public string? imagem { get; set; }
    }
}
