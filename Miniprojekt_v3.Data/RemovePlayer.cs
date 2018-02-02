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
