using System;
using System.Threading;

namespace Threads
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			// Create the thread object. This does not start the thread.
			Worker workerObject = new Worker();
			Thread workerThread = new Thread(workerObject.DoWork);

			// Start the worker thread.
			workerThread.Start();
			Console.WriteLine("main thread: Starting worker thread...");

			// Loop until worker thread activates. 
			while (!workerThread.IsAlive);

			// Put the main thread to sleep for 1 millisecond to 
			// allow the worker thread to do some work:
			Thread.Sleep(1);

			// Request that the worker thread stop itself:
			workerObject.RequestStop();

			// Use the Join method to block the current thread  
			// until the object's thread terminates.
			workerThread.Join();
			Console.WriteLine("main thread: Worker thread has terminated.");
		}
	}
}
