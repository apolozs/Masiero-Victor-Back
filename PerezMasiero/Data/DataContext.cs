using PerezMasiero.Models;
using Microsoft.EntityFrameworkCore;

namespace PerezMasiero.Data
{
    public class DataContext : DbContext
    {
        //Construtor
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        //Lista de propriedades das classes de modelo que vão virar tabelas no banco
        public DbSet<Produto> Produtos { get; set; }
    }
}