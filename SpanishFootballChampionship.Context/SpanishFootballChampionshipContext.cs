using Microsoft.EntityFrameworkCore;
using SpanishFootballChampionship.Models;

namespace SpanishFootballChampionship.DAL
{
    public class SpanishFootballChampionshipContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SpanishFootballChampionship;Integrated Security=True;Connect Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team1)
                .WithMany(t => t.Matches1)
                .HasForeignKey(m => m.Team1Id);

            modelBuilder.Entity<Match>()
                .HasOne(m => m.Team2)
                .WithMany(t => t.Matches2)
                .HasForeignKey(m => m.Team2Id);
        }

        /// Модуль 6. Частина 2

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


        /// Модуль 6. Частина 3

        public List<Match> GetMatchesByDate(DateTime date)
        {
            return Matches.Where(m => m.MatchDate.Date == date.Date).ToList();
        }

        public List<Match> GetTeamMatches(int teamId)
        {
            return Matches.Where(m => m.Team1Id == teamId || m.Team2Id == teamId).ToList();
        }

        public List<Player> GetScorersByDate(DateTime date)
        {
            var scorers = new List<Player>();

            var matches = Matches.Where(m => m.MatchDate.Date == date.Date).ToList();

            foreach (var match in matches)
            {
                if (!string.IsNullOrEmpty(match.Scorer))
                {
                    var player = Players.FirstOrDefault(p => p.TeamId == match.Team1Id || p.TeamId == match.Team2Id && p.FullName == match.Scorer);
                    if (player != null)
                        scorers.Add(player);
                }
            }

            return scorers;
        }

        public void AddMatch(Match match)
        {
            Matches.Add(match);
            SaveChanges();
        }

        public void UpdateMatch(Match updatedMatch)
        {
            var existingMatch = Matches.FirstOrDefault(m => m.Id == updatedMatch.hId);
            if (existingMatch != null)
            {
                existingMatch.Team1Id = updatedMatch.Team1Id;
                existingMatch.Team2Id = updatedMatch.Team2Id;
                
                SaveChanges();
            }
            else
            {
                Console.WriteLine("Match not found.");
            }
        }

        public void DeleteMatch(int team1Id, int team2Id, DateTime date)
        {
            var matchToDelete = Matches.FirstOrDefault(m => (m.Team1Id == team1Id && m.Team2Id == team2Id || m.Team1Id == team2Id && m.Team2Id == team1Id) && m.MatchDate.Date == date.Date);
            if (matchToDelete != null)
            {
                Matches.Remove(matchToDelete);
                SaveChanges();
            }
            else
            {
                Console.WriteLine("Match not found.");
            }
        }




    }
}

