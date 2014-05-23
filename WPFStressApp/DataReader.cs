using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFStressApp.Models;

namespace WPFStressApp
{
	static class DataReader
	{
		private static List<ColumnData> _getColumns;
		public static List<ColumnData> GetColumns()
		{
			if (_getColumns == null)
			{
				var columns = new List<ColumnData>();
				columns = ReadFromCSV();
				_getColumns = columns;
			}
			return _getColumns;
		}

		private static List<ColumnData> ReadFromCSV()
		{
			var output = new List<ColumnData>();

			try
			{
				var file = new FileInfo("TestData.csv");
				output = GetDataFromCSV(file);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return output;
		}

		private static List<ColumnData> GetDataFromCSV(FileInfo file)
		{
			var output = new List<ColumnData>();

			List<string> lines = File.ReadAllLines(file.FullName).ToList();
			lines.RemoveAt(0);

			foreach (var line in lines)
			{
				List<string> entries = line.Split(',').ToList();
				var colData = new ColumnData();
				colData.Heights = new List<double>();

				for (var i = 1; i < entries.Count; i++)
				{
					if (i == 1)
						colData.Alpha = double.Parse(entries[i]);
					else
						colData.Heights.Add(double.Parse(entries[i]));
				}

				output.Add(colData);
			}

			return output;
		}
	}
}
