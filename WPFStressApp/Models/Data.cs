using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFStressApp.Models
{
	public class Data
	{
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
