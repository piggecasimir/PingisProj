using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miniprojekt_v3.Data
{
    public class Match
    {
        public int Id { get; set; }
        public string Player1 { get; set; }
        public string Player2 { get; set; }
        public int Player1Sets { get; set; }
        public int Player2Sets { get; set; }

        public Match(string player1, string player2, int player1set, int player2set)
        {
            Player1 = player1;
            Player2 = player2;
            Player1Sets = player1set;
            Player2Sets = player2set;
        }
    }
}
