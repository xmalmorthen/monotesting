using System;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;

namespace PortList
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			dispositivo listport;
			listport=new dispositivo();
			listport.list_com ();

			serial_port serial = new serial_port ();
			serial.Test ();

			Console.ReadKey ();
		}
	}
}
