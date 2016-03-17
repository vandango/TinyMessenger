using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using vandango.Messaging;
using vandango.Messaging.CustomEventArgs;
using vandango.Messaging.Enums;
using TinyMessenger.Core;
using TinyMessenger.Services.MessengerServiceImpl;

namespace TinyMessenger
{
	public class ServiceContext
	{
		private List<ServiceHost> _services;

		public ServiceContext()
		{
			// send message; will only be received in the console
			MessageBroker.InternalLogMessage("TinyMessenger");

			this._services = new List<ServiceHost>
				{
					new ServiceHost(typeof (MessengerService))
				};
		}

		public void Start()
		{
			try
			{
				// init workers
				MessageBroker.InternalLogMessage("Starting workers...");
				MessageBroker.InternalLogMessage("Starting services...");

				this._services.ForEach(service =>
				{
					try
					{
						MessageBroker.InternalLogMessage(string.Format(
							"  > {0} ({1}) ... ",
							service.Description.Name,
							service.Description.ServiceType.ToString()
							));

						try
						{
							MessageBroker.InternalLogMessage(string.Format(
								"    : URL: {0}",
								service.Description.Endpoints[0].Address.Uri.AbsoluteUri
								));
						}
						catch (Exception e)
						{
							MessageBroker.InternalLogMessage(string.Format("ERROR - URL: {0}", e.Message));
						}

						try
						{
							service.Open();
							MessageBroker.InternalLogMessage(string.Format(
								"    : {0} OK",
								service.Description.Name
								));
						}
						catch (Exception e)
						{
							MessageBroker.InternalLogMessage(string.Format("ERROR - OK: {0}", e.Message));
						}
					}
					catch (Exception e)
					{
						MessageBroker.InternalLogMessage(string.Format("ERROR - CREATE: {0}", e.Message));
					}
				});

				// finish worker init
				if (this._services.Count < 1)
				{
					MessageBroker.InternalLogMessage("  # No services found...");
				}
				else
				{
					MessageBroker.InternalLogMessage("  # Services started...");
				}

				// database initialize
				MessageBroker.InternalLogMessage("Initialize database...");
				UserDatabase.Init();
				MessageBroker.InternalLogMessage("  > User loaded...");
				MessageDatabase.Init();
				MessageBroker.InternalLogMessage("  > Messages loaded...");
				MessageBroker.InternalLogMessage("Databases are up and running.");

				// send serverstatus changed message
				Thread.Sleep(500);
				MessageBroker.ServerStatusChanged(ServerStatus.Started);
			}
			catch (Exception ex)
			{
				MessageBroker.OnInternalMessageFiredAsync(new MessageEventArgs(
					"Error on initializing the services and/or the workers!", ex, MessageType.Error
				));
			}
		}

		public void Stop()
		{
			// stop the services
			this._services.ForEach(service => service.Close());

			MessageBroker.InternalLogMessage("Services stopped.");
			MessageBroker.InternalLogMessage("");

			//// stop the workers
			//foreach (IWorker worker in this.workers)
			//{
			//	worker.Stop();
			//}

			MessageBroker.InternalLogMessage("Workers stopped.");
			MessageBroker.InternalLogMessage("");

			// finished
			MessageBroker.InternalLogMessage("All workers and services stopped, application terminated!");

			// send server status changed message
			MessageBroker.OnServerStatusChangedAsync(new ServerStatusEventArgs(ServerStatus.Stopped));
		}
	}
}
