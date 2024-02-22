using Microsoft.EntityFrameworkCore;
using SpanishFootballChampionship.Models;

namespace SpanishFootballChampionship.DAL
{
    public class SpanishFootballChampionshipContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpanishFootballChampionship;Integrated Security=True;Connect Timeout=30;");
        }
    }
}

