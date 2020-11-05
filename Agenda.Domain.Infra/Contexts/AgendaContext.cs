using Microsoft.EntityFrameworkCore;
using Agenda.Domain.Entities;

namespace Agenda.Domain.Infra.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        { }

        public DbSet<AgendaItem> Agendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendaItem>().ToTable("Agenda");
            modelBuilder.Entity<AgendaItem>().Property(x => x.Id);
            modelBuilder.Entity<AgendaItem>().Property(x => x.User).HasMaxLength(120).HasColumnType("varchar(120)");
            modelBuilder.Entity<AgendaItem>().Property(x => x.Title).HasMaxLength(160).HasColumnType("varchar(160)");
            modelBuilder.Entity<AgendaItem>().Property(x => x.Done).HasColumnType("bit");
            modelBuilder.Entity<AgendaItem>().Property(x => x.Date);
            modelBuilder.Entity<AgendaItem>().HasIndex(y => y.User);
            modelBuilder.Entity<AgendaItem>().Property(x => x.Hour);
        }
    }
}