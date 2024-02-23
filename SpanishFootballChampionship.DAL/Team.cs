namespace SpanishFootballChampionship.Models
{
   

    public class Team
    {
        public int Id      { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int Wins    { get; set; }

        public int Losses  { get; set; }

        public int Draws   { get; set; }
        
        public int GoalsFor { get; set; }

        public int GoalsAgainst { get; set; }

        public List<Player> Players { get; set; }
        public List<Match> Matches1 { get; set; }
        public List<Match> Matches2 { get; set; }

        public void Print(Team team)
        {
            Console.WriteLine($"Team: {team.Name} | City: {team.City} | Wins: {team.Wins} | Losses: {team.Losses} | Draws: {team.Draws} | GoalsFor: {team.GoalsFor} | GoalsAgainst: {team.GoalsAgainst}");
        }

    }
}
