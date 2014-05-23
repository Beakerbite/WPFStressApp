using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStressApp.Models
{
	public class Data : INotifyPropertyChanged
	{
		private ObservableCollection<ColumnData> _columns;
		public ObservableCollection<ColumnData> Columns
		{
			get { return _columns; }
			set
			{
				_columns = value;
				NotifyPropertyChanged("Columns");
			}
		}

		public Data()
		{
			Columns = new ObservableCollection<ColumnData>(DataReader.GetColumns());
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
