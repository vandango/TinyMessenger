using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyMessengerClient.MessengerService;

namespace TinyMessengerClient.Client.ClientEventArgs
{
	public class InfoEventArgs : EventArgs
	{
		public string Info { get; set; }

		public InfoEventArgs(string info)
		{
			this.Info = info;
		}
	}
}
