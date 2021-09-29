using Microsoft.EntityFrameworkCore;
using AndreyPerez.Models;
using System.Linq;
using System;



namespace AndreyPerez.Data
{
    public class DataContext : DbContext
    {
         //Contrutor
         public DataContext(DbContextOptions<DataContext> options) : base(options) {SetData();}

         //Lista de propieadas das classes que vão virar tabelas no banco.
            public DbSet<Pessoa> Pessoas { get; set;}
            
             private void SetData(){

                if (!Pessoas.Any())
                {    
                Pessoas.Add(new Pessoa
                {
                    Nome= "Andrey Masiero",
                    Profissao= "Desenvolvedor iOS",
                    GostoMusical= "HeavyMetal",
                    Genero= "Masculino",
                   
                    });
                    Pessoas.Add(new Pessoa
                {
                    Nome= "Victor Perez",
                    Profissao= "Agilista",
                    GostoMusical= "Samba",
                    Genero= "Masculino",
                    });

                SaveChanges();
            } 
        }
     }      
}
         
