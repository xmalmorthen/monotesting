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
				//mySerial = new SerialPort ("/dev/ttyS0", 38400, Parity.None, 8, StopBits.Two );
				mySerial = new SerialPort("/dev/ttyS0", 38400);
				mySerial.Open();
				mySerial.ReadTimeout = 400;
				SendData("ATI3\r");


				mySerial.DataReceived += new SerialDataReceivedEventHandler(ReadData);

				Console.WriteLine(ReadData());
			} catch (Exception ex) {
				Console.WriteLine ("Error al intentar escribir en el puerto - {0}", ex.Message);
			}


		}

		public string ReadData(object sender, SerialDataReceivedEventArgs e)
		{
			SerialPort spL = (SerialPort) sender;
			byte[] buf = new byte[spL.BytesToRead];
			Console.WriteLine("DATA RECEIVED!");
			spL.Read(buf, 0, buf.Length);
			foreach (Byte b in buf)
			{
				Console.Write(b.ToString());
			}
			Console.WriteLine();
		}

		public bool SendData(string Data)
		{
			mySerial.Write(Data);
			return true;
		}
	}
}

