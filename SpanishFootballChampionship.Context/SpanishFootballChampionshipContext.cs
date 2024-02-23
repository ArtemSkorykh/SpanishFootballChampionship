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

        public Team GetTeamByName(string name)
        {
            return Teams.FirstOrDefault(t => t.Name == name);
        }

        public List<Team> GetTeamsByCity(string city)
        {
            return Teams.Where(t => t.City == city).ToList();
        }

        public Team GetTeamByNameAndCity(string name, string city)
        {
            return Teams.FirstOrDefault(t => t.Name == name && t.City == city);
        }

        public Team GetTeamWithMostWins()
        {
            return Teams.OrderByDescending(t => t.Wins).FirstOrDefault();
        }

        public Team GetTeamWithMostLosses()
        {
            return Teams.OrderByDescending(t => t.Losses).FirstOrDefault();
        }

        public Team GetTeamWithMostDraws()
        {
            return Teams.OrderByDescending(t => t.Draws).FirstOrDefault();
        }

        public Team GetTeamWithMostGoalsScored()
        {
            return Teams.OrderByDescending(t => t.GoalsAgainst).FirstOrDefault();
        }


        public Team GetTeamWithMostGoalsConceded()
        {
            return Teams.OrderByDescending(t => t.GoalsFor).FirstOrDefault();
        }

        public void AddTeam(Team team)
        {
            if (GetTeamByNameAndCity(team.Name, team.City) == null)
            {
                Teams.Add(team);
                SaveChanges();
            }
            else
            {
                Console.WriteLine("Team already exists.");
            }
        }

        public void UpdateTeam(Team updatedTeam)
        {
            var existingTeam = GetTeamByNameAndCity(updatedTeam.Name, updatedTeam.City);
            if (existingTeam != null)
            {
                existingTeam.Wins = updatedTeam.Wins;
                existingTeam.Losses = updatedTeam.Losses;
                existingTeam.Draws = updatedTeam.Draws;
                existingTeam.GoalsFor = updatedTeam.GoalsFor;
                existingTeam.GoalsAgainst = updatedTeam.GoalsAgainst;
                SaveChanges();
            }
            else
            {
                Console.WriteLine("Team does not exist.");
            }
        }

        public void DeleteTeam(string name, string city)
        {
            var teamToDelete = GetTeamByNameAndCity(name, city);
            if (teamToDelete != null)
            {
                Teams.Remove(teamToDelete);
                SaveChanges();
            }
            else
            {
                Console.WriteLine("Team not found.");
            }
        }
    }
}

