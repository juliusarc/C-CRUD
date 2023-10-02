using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Controllers;
using SistemaDeTarefas.Datas.Map;

namespace SistemaDeTarefas.Datas
{
    public class SistemadeTarefasDBcontex : DbContext

    {
        public SistemadeTarefasDBcontex(DbContextOptions<SistemadeTarefasDBcontex> options)
             : base(options) 
        { 
        }
            
        
            public DbSet<UsuarioModel> Usuarios { get; set; }
            public DbSet<TarefaModel> Tarefas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder); 

        }
    }
    }




















