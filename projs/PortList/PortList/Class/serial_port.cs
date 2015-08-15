using System;
using System.IO.Ports;
using System.IO;
using System.Collections.Generic;

namespace PortList
{
	public class serial_port
	{
		private SerialPort mySerial;

		// Constructor
		public serial_port ()
		{
		}

		public void Test ()
		{
			if (mySerial != null)
			if (mySerial.IsOpen)
				mySerial.Close ();

			try {
				mySerial = new SerialPort ("/dev/ttyS1", 9600, Parity.None, 8, StopBits.Two );
				mySerial.Open ();

				Console.WriteLine("Puerto /dev/ttyS1 abierto!!!");

				mySerial.ReadTimeout = 400;

				byte[] buf = new byte[1];
				buf [0] = 0x41;

				Console.WriteLine("Escribiendo 0x41 en puerto /dev/ttyS1");

				mySerial.Write (buf, 0, buf.Length);
				mySerial.Close();	
			} catch (Exception ex) {
				Console.WriteLine ("Error al intentar escribir en el puerto - {0}", ex.Message);
			}

			/*while (true) {
				Console.WriteLine (ReadData ());
				// Hook a write to the text file.
				//StreamWriter writer = new StreamWriter ("/home/luiswisp/archivo.txt", true);
				// Rewrite the entire value of s to the file
				//string a = ReadData ();
				writer.WriteLine (a);
				// Close the writer
				writer.Close ();
			}*/
		}

		public string ReadData ()
		{
			byte tmpByte;
			string rxString = "";

			try {

				tmpByte = (byte)mySerial.ReadByte ();

				while (true) {
					//Console.WriteLine("Data Received");
					try {
						rxString += ((char)tmpByte);
						tmpByte = (byte)mySerial.ReadByte ();
					} catch {
						rxString += "!2";
						break;
					}
				}

			} catch {
				rxString += "!1";
			}
			return rxString;
		}

		public bool SendData (string Data)
		{
			mySerial.Write (Data);
			return true;
		}
	}
}

