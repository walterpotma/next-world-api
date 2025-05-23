using System.ComponentModel.DataAnnotations.Schema;

namespace next_world_api.Model
{
    [Table("capitulos")]
    public class Capitulos
    {
        public int id { get; set; }

        public int hq_id { get; set; }

        public int numero_cap {  get; set; }

        public int views {  get; set; }

        public int nota {  get; set; }

        //public List<string>? paginas { get; set; }

        public DateTime created_at { get; set; }
    }
}
