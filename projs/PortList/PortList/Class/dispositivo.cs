using System;
using System.IO;
using System.IO.Ports;

namespace PortList
{
	public class dispositivo
	{
		public dispositivo ()
		{

		}
		public void list_com ()
		{
			/*
			try {
				SerialPort serial = new SerialPort ();

				if (serial.IsOpen) serial.Close ();

				serial.PortName = "COM1";
				serial.BaudRate = 9600;
				serial.Open ();

				byte[] buf = new byte[1];
				buf [0] = 0x41;
				serial.Write (buf, 0, buf.Length);
				serial.Close();	
			} catch (Exception ex) {
				Console.WriteLine ("Error al intentar abrir el COM1 -" + ex.Message);
			}*/

			// crear lista con los nombre de los puertos seriales.
			string[] ports = SerialPort.GetPortNames ();

			//Console.WriteLine ("The following serial ports were found:");

			// Display each port name to the console.
			foreach (string port in ports) {
				Console.WriteLine (port);
			}
			//Console.ReadLine ();
		}
	}
}

