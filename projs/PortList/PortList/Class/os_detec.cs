using System;

namespace PortList
{
	public class os_detec
	{
		// Constructor
		public os_detec ()
		{

		}
		public void os ()
		{
			//Declarar los mensajes y su contenido
			string msg1 = "Windows.";
			string msg2 = "Unix.";
			string msg3 = "ERROR: Plataforma no Identificada.";

			//Declarar los mensajes y su contenido
			OperatingSystem os = Environment.OSVersion;
			PlatformID pid = os.Platform;
			switch (pid) {
			case PlatformID.Win32NT:
			case PlatformID.Win32S:
			case PlatformID.Win32Windows:
			case PlatformID.WinCE:
				Console.WriteLine (msg1);
				break;
			case PlatformID.Unix:
				Console.WriteLine (msg2);
				break;
			default:
				Console.WriteLine (msg3);
				break;
			}
		}
	}
}

