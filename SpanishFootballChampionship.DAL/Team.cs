﻿namespace SpanishFootballChampionship.Models
{
    public class Team
    {
        public int Id      { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public int Wins    { get; set; }

        public int Losses  { get; set; }

        public int Draws   { get; set; }
    }
}
