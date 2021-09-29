using Microsoft.EntityFrameworkCore;
using AndreyPerez.Models;
using System.Linq;
using System;



namespace AndreyPerez.Data
{
    public class DataContext : DbContext
    {
         //Contrutor
         public DataContext(DbContextOptions<DataContext> options) : base(options) {}

         //Lista de propieadas das classes que vão virar tabelas no banco.
            public DbSet<Pessoa> Pessoas { get; set;}

     }      
}
         
