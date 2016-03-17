using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using vandango.Messaging;
using vandango.Messaging.CustomEventArgs;
using vandango.Messaging.Enums;
using TinyMessenger;
using TinyMessenger.Forms;

namespace TinyMessengerConsole
{
	class Program
	{
		private static ServiceContext context;

		public static string StandardInput()
		{
			Console.Write("\n>: ");
			return Console.ReadLine();
		}

		static void Main(string[] args)
		{
			Console.BufferWidth = 500;
			Console.BufferHeight = 3000;
			Console.WindowWidth = 120;
			Console.WindowHeight = 40;
			Console.CancelKeyPress += Console_CancelKeyPress;

			MessageBroker.InternalMessageFired += new MessageBroker.InternalMessageEventHandler(MessageBroker_InternalMessageFired);
			MessageBroker.ServerStateChanged += new MessageBroker.ServerStatusEventHandler(MessageBroker_ServerStateChanged);

			// create
			context = new ServiceContext();

			MessageBroker.InternalLogMessage("TinyMessenger Console Service and ServiceContext created!");

			// start
			MessageBroker.InternalLogMessage("TinyMessenger Console Service attempt to start...");

			var thread = new Thread(new ThreadStart(context.Start));
			thread.Start();

			MessageBroker.InternalLogMessage("TinyMessenger Console Service started...");

			// basic info
			Thread.Sleep(2000);
			Console.WriteLine("Enter 'exit' and press [Enter] to stop the console");

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			string command = StandardInput();
			while (command != "exit")
			{
				switch(command)
				{
					case "admin":
						var admin = new AdminForm();
						new System.Threading.Thread(() =>
						{
							Application.Run(admin);
						}).Start();
						break;

					case "info":
						var info = new AboutBox();
						new System.Threading.Thread(() =>
						{
							Application.Run(info);
						}).Start();
						break;
				}

				command = StandardInput();
			}

			context.Stop();

			MessageBroker.InternalLogMessage("TinyMessenger Windows Service stopped...");
		}

		static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			context.Stop();

			MessageBroker.InternalLogMessage("TinyMessenger Windows Service stopped...");
		}

		protected static void MessageBroker_InternalMessageFired(object sender, MessageEventArgs e)
		{
			ConsoleColor cc;

			switch (e.Type)
			{
				case MessageType.Error:
					// log this to db and show on console
					cc = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine(DateTime.Now.ToString() + ": " + e.Message, e.InternalException);

					Console.ForegroundColor = cc;
					break;

				case MessageType.Warning:
					// log this to db and show on console
					cc = Console.ForegroundColor;
					Console.ForegroundColor = ConsoleColor.Yellow;

					Console.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

					Console.ForegroundColor = cc;
					break;

				//case MessageType.LogInformation:
				//	// log this to db and show on console
				//	Console.WriteLine(e.Message);
				//	break;

				case MessageType.LogInformation:
				case MessageType.Unknown:
				case MessageType.Information:
				default:
					// only show on console
					if (string.IsNullOrWhiteSpace(e.Message))
					{
						Console.WriteLine();
					}
					else
					{
						Console.WriteLine(DateTime.Now.ToString() + ": " + e.Message, true);
					}
					break;
			}
		}

		protected static void MessageBroker_ServerStateChanged(object sender, ServerStatusEventArgs e)
		{
			ConsoleColor cc = Console.ForegroundColor;
			Console.ForegroundColor = ConsoleColor.Cyan;

			Console.WriteLine("{0}: {1}{2}",
				DateTime.Now,
				(e.Status == ServerStatus.Started ? "Server started" : "Server stopped"),
				Environment.NewLine
				);

			Console.ForegroundColor = cc;
		}
	}
}
