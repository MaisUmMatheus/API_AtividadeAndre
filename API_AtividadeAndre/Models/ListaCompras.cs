using API_LINGUILEARN.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_AtividadeAndre.Models
{
    public class ListaCompras
    {
        [Key]
        public int Id { get; set; }

        public string Itens { get; set; } = "";

        public bool Comprado { get; set; } = false;

        [ForeignKey("UserId")]
        public int UserId { get; set; }


       

    }
}
