using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Miniprojekt_v3.Data
{
    public partial class DataManager
    {
        SqlConnection conn;

        public void EloRaiting(int player)
        {
            SqlCommand command1 = new SqlCommand($"SELECT [Elo], FROM Players Where [Id] = {player}", conn);
            SqlCommand command2 = new SqlCommand($"SELECT [Elo], FROM Players Where [Id] = {player}", conn);
            int EloP1 = int.Parse(command1.ToString());
            int EloP2 = 0;

            double RatingP1 = Math.Pow(10, EloP1);

           
        }
        


        public DataManager()
        {
            string connString = ConfigurationManager.ConnectionStrings["myCon"].ConnectionString;
            conn = new SqlConnection(connString);
        }


        public List<Match> GetMatchTable()
        {
            List<Match> ret = new List<Match>();
            SqlCommand command = new SqlCommand("SELECT TOP(10) Matches.Id, p1.[Name] as Player1, Player1Sets, Player2Sets, p2.[Name] as Player2 from Matches join Players p1 on p1.Id = Player1 join Players p2 on p2.Id = Player2 ORDER BY Id DESC", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                foreach (var item in reader)
                {
                    Match match = new Match(reader["Player1"].ToString(), reader["Player2"].ToString(), Convert.ToInt32(reader["Player1Sets"].ToString()), Convert.ToInt32(reader["Player2Sets"].ToString()));
                    ret.Add(match);

                }

            }
            catch
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return ret;
        }

        public List<Player> GetLeagueTable()
        {
            List<Player> ret = new List<Player>();
            SqlCommand command = new SqlCommand("SELECT Id, Name, MatchesPlayed, MatchesWon, MatchesLost, SetsWon, SetsLost, SetDifference FROM Players ORDER BY MatchesWon DESC, SetDifference DESC", conn);
            try
            {
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
                foreach (var item in reader)
                {
                    Player player = new Player();
                    player.Name = reader["Name"].ToString();
                    player.MatchesPlayed = Convert.ToInt32(reader["MatchesPlayed"].ToString());
                    player.MatchesWon = Convert.ToInt32(reader["MatchesWon"].ToString());
                    player.MatchesLost = Convert.ToInt32(reader["MatchesLost"].ToString());
                    player.SetsWon = Convert.ToInt32(reader["SetsWon"].ToString());
                    player.SetsLost = Convert.ToInt32(reader["SetsLost"].ToString());
                    player.SetDifference = Convert.ToInt32(reader["SetDifference"].ToString());
                    player.Id = Convert.ToInt32(reader["Id"].ToString());
                    ret.Add(player);

                }

            }
            catch
            {

                throw;
            }
            finally
            {
                conn.Close();
            }


            return ret;
        }

        public void AddMatch(int Player1Id, int Player2Id, int Player1Sets, int Player2Sets)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Matches (Player1,Player2,Player1Sets,Player2Sets) VALUES (@Player1,@Player2,@Player1Sets,@Player2Sets)", conn);
            command.Parameters.Add(new SqlParameter("@Player1", Player1Id));
            command.Parameters.Add(new SqlParameter("@Player2", Player2Id));
            command.Parameters.Add(new SqlParameter("@Player1Sets", Player1Sets));
            command.Parameters.Add(new SqlParameter("@Player2Sets", Player2Sets));

            try
            {
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }


        public void UppdatePlayer(int Player1Id, int Player2Id, int Player1Sets, int Player2Sets)
        {
            int Player1Won = 0;
            int Player1Lost = 0;
            int Player2Won = 0;
            int Player2Lost = 0;

            if (Player1Sets > Player2Sets)
            {
                Player1Won = 1;
                Player2Lost = 1;

            }
            else
            {
                Player1Lost = 1;
                Player2Won = 1;
            }

            int SetDiff = Player1Sets - Player2Sets;

            SqlCommand commandP1 = new SqlCommand("UPDATE Players SET MatchesPlayed += 1, MatchesWon += @Player1Won, MatchesLost += @Player1Lost, SetsWon += @Player1Sets, SetsLost += @Player2Sets, SetDifference += @SetDiff where Id = @Player1", conn);
            commandP1.Parameters.Add(new SqlParameter("@Player1", Player1Id));
            commandP1.Parameters.Add(new SqlParameter("@Player2", Player2Id));
            commandP1.Parameters.Add(new SqlParameter("@Player1Sets", Player1Sets));
            commandP1.Parameters.Add(new SqlParameter("@Player2Sets", Player2Sets));
            commandP1.Parameters.Add(new SqlParameter("@Player1Won", Player1Won));
            commandP1.Parameters.Add(new SqlParameter("@Player1Lost", Player1Lost));
            commandP1.Parameters.Add(new SqlParameter("@SetDiff", SetDiff));
            SqlCommand commandP2 = new SqlCommand("UPDATE Players SET MatchesPlayed += 1, MatchesWon += @Player2Won, MatchesLost += @Player2Lost, SetsWon += @Player2Sets, SetsLost += @Player1Sets, SetDifference -= @SetDiff where Id = @Player2", conn);
            commandP2.Parameters.Add(new SqlParameter("@Player1", Player1Id));
            commandP2.Parameters.Add(new SqlParameter("@Player2", Player2Id));
            commandP2.Parameters.Add(new SqlParameter("@Player1Sets", Player1Sets));
            commandP2.Parameters.Add(new SqlParameter("@Player2Sets", Player2Sets));
            commandP2.Parameters.Add(new SqlParameter("@Player2Won", Player2Won));
            commandP2.Parameters.Add(new SqlParameter("@Player2Lost", Player2Lost));
            commandP2.Parameters.Add(new SqlParameter("@SetDiff", SetDiff));

            try
            {
                conn.Open();
                commandP1.ExecuteNonQuery();
                commandP2.ExecuteNonQuery();
            }
            catch
            {

                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
