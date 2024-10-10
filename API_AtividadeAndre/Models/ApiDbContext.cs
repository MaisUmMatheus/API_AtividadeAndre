using Microsoft.EntityFrameworkCore;
using API_AtividadeAndre.Models;

namespace API_LINGUILEARN.Models
{
    public class ApiDbContext : DbContext
{
    public DbSet<ListaCompras> ListaCompras { get; set; }
    public DbSet<Users> Users { get; set; }

    public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
    {
    }

    // Configure os relacionamentos aqui, se necessário
}

}
