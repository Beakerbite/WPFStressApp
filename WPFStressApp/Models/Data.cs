using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStressApp.Models
{
	public class Data : INotifyPropertyChanged
	{
		private ColumnData _column;
		public ColumnData Column
		{
			get { return _column; }
			set
			{
				_column = value;
				NotifyPropertyChanged("Column");
			}
		}

		private String _name;
		public String Name
		{
			get { return _name; }
			set
			{
				_name = value;
				NotifyPropertyChanged("Name");
			}
		}

		public Data()
		{
			Column = GetColumns().First();
			Name = "George";
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void NotifyPropertyChanged(string propertyName)
		{
			var handler = PropertyChanged;
			if (handler != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		private static List<ColumnData> _getColumns;
		public static List<ColumnData> GetColumns()
		{
			if (_getColumns == null)
			{
				var columns = new List<ColumnData>();
				columns.Add(GetData());
				_getColumns = columns;
			}
			return _getColumns;
		}

		private static ColumnData GetData()
		{
			var columnData = new ColumnData();
			columnData.Alpha = 0.977;
			columnData.Heights = new List<double>{
				0.002,
				0.003,
				0.133,
				0.186,
				0.197,
				0.075,
				0.057,
				0.008,
				0.037,
				0.043,
				0.145,
				0.115,
			};

			return columnData;
		}
	}
}
