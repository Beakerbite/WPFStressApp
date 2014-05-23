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
				var data = CsvToDataTable(file);
				output = ProcessDataTable(data);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}

			return output;
		}

		private static List<ColumnData> ProcessDataTable(DataTable dataTable)
		{
			var output = new List<ColumnData>();

			foreach (DataRow row in dataTable.Rows)
			{
				output.Add(ConvertDataRowToColumnData(row));
			}

			return output;
		}

		private static DataTable CsvToDataTable(FileInfo file)
		{
			DataTable dataTable = new DataTable();
			using (var conn = new System.Data.Odbc.OdbcConnection(@"Driver={Microsoft Access Text Driver (*.txt, *.csv)};Dbq=" + file.DirectoryName + ";Extensions=asc,csv,tab,txt;Persist Security Info=False"))
			{
				conn.Open();
				var adapter = new System.Data.Odbc.OdbcDataAdapter("select * from [" + file.Name + "]", conn);
				adapter.Fill(dataTable);
			}
			return dataTable;
		}

		private static ColumnData ConvertDataRowToColumnData(DataRow row)
		{
			var column = new ColumnData();

			column.Heights = new List<double>();

			column.Alpha = double.Parse(row["ColumnOpacity"] + "");
			column.Heights.Add(double.Parse(row["Box0"] + ""));
			column.Heights.Add(double.Parse(row["Box1"] + ""));
			column.Heights.Add(double.Parse(row["Box2"] + ""));
			column.Heights.Add(double.Parse(row["Box3"] + ""));
			column.Heights.Add(double.Parse(row["Box4"] + ""));
			column.Heights.Add(double.Parse(row["Box5"] + ""));
			column.Heights.Add(double.Parse(row["Box6"] + ""));
			column.Heights.Add(double.Parse(row["Box7"] + ""));
			column.Heights.Add(double.Parse(row["Box8"] + ""));
			column.Heights.Add(double.Parse(row["Box9"] + ""));
			column.Heights.Add(double.Parse(row["Box10"] + ""));
			column.Heights.Add(double.Parse(row["Box11"] + ""));

			return column;
		}
	}
}
