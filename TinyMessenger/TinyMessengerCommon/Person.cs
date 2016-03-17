using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TinyMessengerCommon
{
	[DataContract]
	public class Person : INotifyPropertyChanged
	{
		private string _name;
		public event PropertyChangedEventHandler PropertyChanged;
		
		/// <summary>
		/// Blank constructor
		/// </summary>
		public Person()
		{
		}

		[DataMember]
		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;

				// Call OnPropertyChanged whenever the property is updated
				OnPropertyChanged("Name");
			}
		}
		
		/// <summary>
		/// Notifies the parent bindings (if any) that a property
		/// value changed and that the binding needs updating
		/// </summary>
		/// <param name="propValue">The property which changed</param>
		protected void OnPropertyChanged(string propValue)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propValue));
			}
		}
	}
}
