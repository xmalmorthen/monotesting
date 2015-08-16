using System;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.IO;
using System.Reflection;
using NLog;

namespace MySqlCnn
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			try {
				GetData data = new GetData(ConfigurationManager.AppSettings ["server"],
					ConfigurationManager.AppSettings ["database"],
					ConfigurationManager.AppSettings ["usr"],
					ConfigurationManager.AppSettings ["pwd"]);

				MySqlDataReader result = data.get_CaTest();
				while (result.Read()) {
					Console.WriteLine ("Id={0} | Description={1}", result [0], result [1]);
				}
				result.Close();

				data.insert_CaTest();

				result.Close ();

			} catch (Exception ex) {
				Logger logger = LogManager.GetCurrentClassLogger();
				logger.Error(ex,ex.Message);
			}
		}
	}
}
