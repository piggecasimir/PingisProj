using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojekt_v3.Data
{
    //internal är motsvarigheten av Private på en variabel men anpassad för Klasser, ses då bara i sitt projekt Public öppnar det.
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MatchesPlayed { get; set; }
        public int MatchesWon { get; set; }
        public int MatchesLost { get; set; }
        public int SetsWon { get; set; }
        public int SetsLost { get; set; }
        public int SetDifference { get; set; }
		public int Elo { get; set; }
	}
}
