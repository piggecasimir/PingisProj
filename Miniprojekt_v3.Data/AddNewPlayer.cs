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

		public void AddNewPlayer(string name)
		{
			SqlCommand command = new SqlCommand("INSERT INTO Players (Name,MatchesPlayed,MatchesWon,MAtchesLost,SetsWon,SetsLost,SetDifference) VALUES (@Player,0,0,0,0,0,0)", conn);
			command.Parameters.Add(new SqlParameter("@Player", name));

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



	}
}
