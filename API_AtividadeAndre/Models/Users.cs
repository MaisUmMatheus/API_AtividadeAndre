using API_AtividadeAndre.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_LINGUILEARN.Models
{
    public class Users
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string email { get; set; } = "";

        public string password { get; set; } = "";

       
    }
}
