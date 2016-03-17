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
	public class MessageBroker<T>
	{
		public delegate void GenericMessageEventHandler(object sender, GenericEventArgs<T> e);
		public static event GenericMessageEventHandler GenericMessageFired;

		private static object _syncRootGen = new object(); // Synchronizationobject for generic Events

		/// <summary>
		/// Fire generic messages like errors, warnings, etc. in an asynchronous manner
		/// </summary>
		/// <remarks>
		/// Notifies all registered Listeners for Event <see cref="GenericMessageFired"/> in a seperate Thread.
		/// By this, program flow will not block.
		/// </remarks>
		/// <param name="e">Additiional Event Info</param>
		public static void OnGenericMessageFiredAsync(MessageEventArgs e)
		{
			GenericMessageEventHandler handler;
			lock (_syncRootGen)
			{
				handler = GenericMessageFired;
			}

			// Event will be null if there are no subscribers
			if (handler != null)
			{
				// Each listener is notified in seperate thread 
				Delegate[] invocationMethods = handler.GetInvocationList();
				foreach (GenericMessageEventHandler evHandler in invocationMethods)
				{
					try
					{
						//execute eventhandler in seperate thread
						GenericEventNotifier ien = new GenericEventNotifier(evHandler);
						ThreadPool.QueueUserWorkItem(ien.Start, e);
					}
					catch { } //Do nothing on error, just notify next handler
				}
			}
		}

		/// <summary>
		/// Embedded class to notify GenericMessageFired-Listener in seperate threads
		/// </summary>
		/// <remarks>
		/// Can only be instantiated from inside the class MessageBroker
		/// </remarks>
		private class GenericEventNotifier
		{
			private GenericMessageEventHandler evtHandler;

			/// <summary>
			/// Constructor
			/// </summary>
			/// <param name="handler">Refernce to a InternalMessageEventHandler</param>
			public GenericEventNotifier(GenericMessageEventHandler handler)
			{
				evtHandler = handler;
			}

			/// <summary>
			/// Invokes the mentioned handler
			/// </summary>
			public void Start(object args)
			{
				GenericEventArgs<T> e = args as GenericEventArgs<T>;
				try
				{
					evtHandler.Invoke(null, e);
				}
				catch { }
			}
		}
	}
}
