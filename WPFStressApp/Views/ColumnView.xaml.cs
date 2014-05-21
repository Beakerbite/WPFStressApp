using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPFStressApp.Models;

namespace WPFStressApp.Views
{
	/// <summary>
	/// Interaction logic for ColumnView.xaml
	/// </summary>
	public partial class ColumnView : UserControl
	{
		public ColumnView()
		{
			InitializeComponent();
			var data = Data.GetColumns().First().Heights;
			ColumnStack.Opacity = Data.GetColumns().First().Alpha;
			var controls = GetControls();

			for (int i = 0; i < data.Count; i++ )
			{
				controls[i].Height = new GridLength(data[i], GridUnitType.Star);
			}
		}

		private List<RowDefinition> GetControls()
		{
			var controls = new List<RowDefinition>();

			controls.Add(Row1);
			controls.Add(Row2);
			controls.Add(Row3);
			controls.Add(Row4);
			controls.Add(Row5);
			controls.Add(Row6);
			controls.Add(Row7);
			controls.Add(Row8);
			controls.Add(Row9);
			controls.Add(Row10);
			controls.Add(Row11);
			controls.Add(Row12);

			return controls;
		}
	}
}
