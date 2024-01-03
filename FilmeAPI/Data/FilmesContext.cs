using FilmeAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FilmeAPI.Data;

public class FilmesContext : DbContext

{
    public FilmesContext(DbContextOptions<FilmesContext> opts) : base(opts)
    {
        
    }

    public DbSet<Filme> Filmes { get; set; }
}
