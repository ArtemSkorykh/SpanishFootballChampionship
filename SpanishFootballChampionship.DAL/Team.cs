
namespace SpanishFootballChampionship.DAL
{
    internal class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int NumberOfWins {  get; set; }

        public int NumberOfLoses { get; set; }

        public int NumberOfDraws { get; set; }
    }
}
