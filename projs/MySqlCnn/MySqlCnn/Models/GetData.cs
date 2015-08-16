using System;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;
using NLog;

namespace MySqlCnn
{
	public class GetData
	{
		private MySqlConnection cnn;
		private MySqlCommand cmd;
		private MySqlDataReader dr;

		public GetData(string server, string database, string usr, string pwd){
			string cnnstr = String.Format ("Server={0};Database={1};Uid={2};Pwd={3}", server, database, usr, pwd);
			cnn = new MySqlConnection (cnnstr);
			cnn.Open();
		}

		~GetData()  // destructor
		{
			try {
				dr.Close ();
				cnn.Close();	
			} catch (Exception) {
			}
		}
				
		public MySqlDataReader get_CaTest(){
			try {
				string cmdstring = "call ca_test"; 
				cmd = new MySqlCommand (cmdstring, cnn);
				dr = cmd.ExecuteReader ();
				cmd.Dispose();
				return dr;
			} catch (Exception ex) {
				Logger logger = LogManager.GetCurrentClassLogger();
				logger.Error(ex,ex.Message);
				return null;
			}
		}

		public Boolean insert_CaTest(){			
			Boolean result = false;
			try
			{
				string rtn = "insert_CaTest";
				cmd = new MySqlCommand(rtn, cnn);
				cmd.CommandType = CommandType.StoredProcedure;

				cmd.Parameters.AddWithValue("@description", "Prueba inserción");

				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{
					Console.WriteLine(rdr[0] + " => " + rdr[1]);
				}
				rdr.Close();

				result =  rdr.FieldCount > 0 ? true : false;
			}
			catch (Exception ex)
			{
				Logger logger = LogManager.GetCurrentClassLogger();
				logger.Error(ex,ex.Message);
				Console.WriteLine(ex.ToString());
			}
			return result;
		}

	}
}

