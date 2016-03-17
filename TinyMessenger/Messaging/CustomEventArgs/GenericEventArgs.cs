using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vandango.Messaging.CustomEventArgs
{
	public class GenericEventArgs<T> : EventArgs
	{
		/// <summary>
		/// Creates new instance of this class
		/// </summary>
		public GenericEventArgs()
		{
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="messageObject">Message object</param>
		public GenericEventArgs(T messageObject)
		{
			this.MessageObject = messageObject;
		}

		/// <summary>
		/// Creates new instance of this class with the mentioned parameters
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="messageObject">Message object</param>
		public GenericEventArgs(object sender, T messageObject)
		{
			this.Sender = sender;
			this.MessageObject = messageObject;
		}

		/// <summary>
		/// Message object
		/// </summary>
		public T MessageObject { get; set; }

		public object Sender { get; set; }
	}
}
