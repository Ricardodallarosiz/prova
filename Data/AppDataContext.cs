using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDataContext : DbContext
{
    public AppDataContext(DbContextOptions<AppDataContext> options) :
     base(options)
    { }
    public DbSet<Tarefa> Task { get; set; }
    public DbSet<Categoria> Cate { get; set; }

    public DbSet<Status> Stts { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Status>().HasData(
            new Status { SttsId = 1,  SttsDescricao = "Não iniciada" },
            new Status { SttsId = 2,  SttsDescricao = "Em andamento" },
            new Status { SttsId = 3,  SttsDescricao = "Concluída" }
        );
        
        modelBuilder.Entity<Categoria>().HasData(
            new Categoria { CateId = 1, Name = "Trabalho", Create = DateTime.Now.AddDays(1) },
            new Categoria { CateId = 2, Name = "Estudos", Create = DateTime.Now.AddDays(2) },
            new Categoria { CateId = 3, Name = "Lazer", Create = DateTime.Now.AddDays(3) }
        );

        modelBuilder.Entity<Tarefa>().HasData(
            new Tarefa { TaskId = 1, Ttl = "Concluir relatório", Dc = "Terminar relatório para reunião", Create = DateTime.Now.AddDays(7), CateId = 1, SttsId = 1 },
            new Tarefa { TaskId = 2, Ttl = "Estudar Angular", Dc = "Preparar-se para a aula de Angular", Create = DateTime.Now.AddDays(3), CateId = 2, SttsId = 2},
            new Tarefa { TaskId = 3, Ttl = "Passeio no parque", Dc = "Dar um passeio relaxante no parque", Create = DateTime.Now.AddDays(14), CateId = 3,SttsId = 3 }
        );
    }
}
