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

		public void RemovePlayer(int id)
		{
			SqlCommand command = new SqlCommand($"DELETE FROM Players WHERE Id = {id}", conn);
			SqlCommand command2 = new SqlCommand($"DELETE FROM Matches WHERE Player1 = {id} OR Player2 = {id}", conn);


			try
			{
				conn.Open();
				command.ExecuteNonQuery();
				command2.ExecuteNonQuery();
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
