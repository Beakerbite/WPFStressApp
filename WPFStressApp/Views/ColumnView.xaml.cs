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
		public static readonly DependencyProperty ColumnDataProperty = DependencyProperty.Register("ColumnData", typeof(ColumnData), typeof(ColumnView));
		public ColumnData ColumnData
		{
			get { return this.GetValue(ColumnDataProperty) as ColumnData; }
			set { this.SetValue(ColumnDataProperty, value); }
		}

		public ColumnView()
		{
			InitializeComponent();

			Loaded += (o, i) =>
			{
				ColumnStack.Opacity = ColumnData.Alpha;
				DefineHeights(ColumnData.Heights, ColumnStack.RowDefinitions);
			};

		}

		private void DefineHeights(List<double> heights, RowDefinitionCollection rowDefinitions)
		{
			for (int i = 0; i < heights.Count && i < rowDefinitions.Count; i++)
			{
				rowDefinitions[i].Height = new GridLength(heights[i], GridUnitType.Star);
			}
		}
	}
}
