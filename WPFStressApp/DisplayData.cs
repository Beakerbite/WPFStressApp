using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStressApp.Models;

namespace WPFStressApp
{
	class DisplayData
	{
		private static ObservableCollection<Column> _getColumns;
		public static ObservableCollection<Column> GetColumns()
		{
			if (_getColumns == null)
			{
				var columns = new ObservableCollection<Column>();
				columns.Add(GetData());
				_getColumns = columns;
			}
			return _getColumns;
		}

		private static Column GetData()
		{
			var alpha = new ColumnAlpha(0.977);
			var boxList = new List<BoxItem>{
				new BoxItem(0.002),
				new BoxItem(0.003),
				new BoxItem(0.133),
				new BoxItem(0.186),
				new BoxItem(0.197),
				new BoxItem(0.075),
				new BoxItem(0.057),
				new BoxItem(0.008),
				new BoxItem(0.037),
				new BoxItem(0.043),
				new BoxItem(0.145),
				new BoxItem(0.115),
			};

			var boxCollection = new BoxCollection(boxList);
			return new Column(alpha, boxCollection);
		}
	}
}
