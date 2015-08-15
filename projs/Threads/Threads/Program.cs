using System;
using System.Threading;

namespace Threads
{
	class MainClass
	{
		private static void CorrerProceso() 
		{ 
			for (int i = 0; i < 100; i++) {
				Thread.Sleep(1000);
				Console.WriteLine ("Thread");	
			}
		}

		public static void Main (string[] args)
		{
			//Creamos el delegado 
			ThreadStart delegado = new ThreadStart(CorrerProceso); 
			//Creamos la instancia del hilo 
			Thread hilo = new Thread(delegado); 
			//Iniciamos el hilo 
			hilo.Start(); 
		}
	}
}
