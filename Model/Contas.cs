using System.ComponentModel.DataAnnotations.Schema;

namespace next_world_api.Model
{
    [Table("contas")]
    public class Contas
    {
        public int id { get; set; }

        public string? nome { get; set; }

        public string? email { get; set; }

        public string? senha { get; set; }

        public string? acesso { get; set; }
        //niveis de acesso, master, produtora, autor, leitor
    }
}
