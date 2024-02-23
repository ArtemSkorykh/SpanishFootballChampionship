using SpanishFootballChampionship.DAL;

namespace FootballLeague.TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SpanishFootballChampionshipContext())
            {
                context.Database.EnsureCreated();


                //var team1 = new Team { Name = "Real Madrid", City = "Madrid", Wins = 20, Losses = 5, Draws = 3 };
                //var team2 = new Team { Name = "Barcelona", City = "Barcelona", Wins = 18, Losses = 7, Draws = 3 };

                //context.Teams.Add(team1);
                //context.Teams.Add(team2);
                //context.SaveChanges();

                var teams = context.Teams;
                foreach (var team in teams)
                {
                    team.Print(team);
                }
            }
        }
    }
}
