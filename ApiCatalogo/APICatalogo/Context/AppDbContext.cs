using APICatalogo.Model;
using Microsoft.EntityFrameworkCore;


namespace APICatalogo.Context;

public class AppDbcontext : DbContext
{
    public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
    {
    }

    public DbSet<Categoria>? Categorias { get; set; }
    public DbSet<Produto>? Produtos { get; set; }
}
