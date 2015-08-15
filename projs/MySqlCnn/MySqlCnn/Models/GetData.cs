using System;
using MySql.Data.MySqlClient;
using System.Configuration;

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
		}
			
		public void Close (){
			if (!dr.IsClosed)
				dr.Close ();
			cnn.Close ();
		}
	
		public MySqlDataReader get_CaTest(){
			try {
				cnn.Open ();
				string cmdstring = "call ca_test"; 
				cmd = new MySqlCommand (cmdstring, cnn);
				dr = cmd.ExecuteReader ();
				return dr;
			} catch (Exception) {
				return null;
			}
		}
	}
}

