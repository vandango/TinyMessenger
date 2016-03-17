using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using vandango.Messaging.CustomEventArgs;
using vandango.Messaging.Enums;

namespace vandango.Messaging
{
	/// <summary>
	/// Message-Centre of complete MembershipEngine
	/// </summary>
	/// <remarks>
	/// Listeners register at this MessageBroker to receive certain events.
	/// (Event based Observer-Pattern)
	/// </remarks>
	public class MessageBroker
	{
		public delegate void ServerStatusEventHandler(object sender, ServerStatusEventArgs e);
		public static event ServerStatusEventHandler ServerStateChanged;

		public delegate void InternalMessageEventHandler(object sender, MessageEventArgs e);
		public static event InternalMessageEventHandler InternalMessageFired;

		private static object _syncRootSrv = new object(); // Synchronizationobject for ServerEvents
		private static object _syncRootInt = new object(); // Synchronizationobject for internal Events
		
		/// <summary>
		/// Fire Server Status Events in an asynchronous manner
		/// </summary>
		/// <remarks>
		/// Notifies all registered listeners for Event <see cref="ServerStateChanged"/> in a seperate thread.
		/// By doing so, program flow will not block.
		/// </remarks>
		/// <param name="e">Additiional Server-Event Info</param>
		public static void OnServerStatusChangedAsync(ServerStatusEventArgs e)
		{
			ServerStatusEventHandler handler;
			lock (_syncRootSrv)
			{
				handler = ServerStateChanged;
			}

			// Event will be null if there are no subscribers
			if (handler != null)
			{
				// Each listener is notified in seperate thread. Doing so doesn't block execution
				Delegate[] invocationMethods = handler.GetInvocationList();
				foreach (ServerStatusEventHandler evHandler in invocationMethods)
				{
					try
					{
						//execute eventhandler in seperate thread
						ServerEventNotifier sen = new ServerEventNotifier(evHandler);
						ThreadPool.QueueUserWorkItem(sen.Start, e);
					}
					catch { } //Do nothing on error, just notify next handler
				}
			}
		}

		/// <summary>
		/// Sends a server status changed event
		/// </summary>
		/// <param name="e"></param>
		public static void ServerStatusChanged(ServerStatus e)
		{
			MessageBroker.OnServerStatusChangedAsync(new ServerStatusEventArgs(e));
		}

		/// <summary>
		/// Fire internal messages like errors, warnings, etc. in an asynchronous manner
		/// </summary>
		/// <remarks>
		/// Notifies all registered Listeners for Event <see cref="InternalMessageFired"/> in a seperate Thread.
		/// By this, program flow will not block.
		/// </remarks>
		/// <param name="e">Additiional Event Info</param>
		public static void OnInternalMessageFiredAsync(MessageEventArgs e)
		{
			InternalMessageEventHandler handler;
			lock (_syncRootInt)
			{
				handler = InternalMessageFired;
			}

			// Event will be null if there are no subscribers
			if (handler != null)
			{
				// Each listener is notified in seperate thread 
				Delegate[] invocationMethods = handler.GetInvocationList();
				foreach (InternalMessageEventHandler evHandler in invocationMethods)
				{
					try
					{
						//execute eventhandler in seperate thread
						InternalEventNotifier ien = new InternalEventNotifier(evHandler);
						ThreadPool.QueueUserWorkItem(ien.Start, e);
					}
					catch { } //Do nothing on error, just notify next handler
				}
			}
		}

		/// <summary>
		/// Sends a internal message event
		/// </summary>
		/// <param name="e"></param>
		public static void InternalMessage(string message)
		{
			MessageBroker.OnInternalMessageFiredAsync(new MessageEventArgs(message, MessageType.Information));
		}

		/// <summary>
		/// Sends a internal message event to save in log
		/// </summary>
		/// <param name="e"></param>
		public static void InternalLogMessage(string message)
		{
			MessageBroker.OnInternalMessageFiredAsync(new MessageEventArgs(message, MessageType.LogInformation));
		}

		/// <summary>
		/// Sends a internal message event
		/// </summary>
		/// <param name="e"></param>
		public static void InternalWarningMessage(string message)
		{
			MessageBroker.OnInternalMessageFiredAsync(new MessageEventArgs(message, MessageType.Warning));
		}

		/// <summary>
		/// Sends a internal message event
		/// </summary>
		/// <param name="e"></param>
		public static void InternalErrorMessage(string message)
		{
			MessageBroker.OnInternalMessageFiredAsync(new MessageEventArgs(message, MessageType.Error));
		}

		/// <summary>
		/// Embedded class to notify ServerStateChanged-Listener in seperate threads
		/// </summary>
		/// <remarks>
		/// Can only be instantiated from inside the class MessageBroker
		/// </remarks>
		private class ServerEventNotifier
		{
			private ServerStatusEventHandler evtHandler;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="handler">Refernce to a ServerStatusEventHandler</param>
			public ServerEventNotifier(ServerStatusEventHandler handler)
			{
				evtHandler = handler;
			}

			/// <summary>
			/// Invokes the mentioned handler
			/// </summary>
			public void Start(object args)
			{
				ServerStatusEventArgs e = args as ServerStatusEventArgs;
				try
				{
					evtHandler.Invoke(null, e);
				}
				catch { }
			}
		}

		/// <summary>
		/// Embedded class to notify InternalMessageFired-Listener in seperate threads
		/// </summary>
		/// <remarks>
		/// Can only be instantiated from inside the class MessageBroker
		/// </remarks>
		private class InternalEventNotifier
		{
			private InternalMessageEventHandler evtHandler;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="handler">Refernce to a InternalMessageEventHandler</param>
			public InternalEventNotifier(InternalMessageEventHandler handler)
			{
				evtHandler = handler;
			}

			/// <summary>
			/// Invokes the mentioned handler
			/// </summary>
			public void Start(object args)
			{
				MessageEventArgs e = args as MessageEventArgs;
				try
				{
					evtHandler.Invoke(null, e);
				}
				catch { }
			}
		}
	}
}
