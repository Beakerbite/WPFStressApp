using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
				DefineHeights(ColumnData.Heights, ColumnStack);
			};

		}

		private Brush PickBrush(int brush)
		{
			var brushes = new List<SolidColorBrush>{
				Brushes.Red,
				Brushes.Blue,
				Brushes.Green,
				Brushes.Yellow,
				Brushes.Purple,
				Brushes.Orange,
				Brushes.Violet,
				Brushes.Gray,
				Brushes.Chocolate,
			};

			return brushes[brush % brushes.Count];
		}

		private void DefineHeights(List<double> heights, Grid grid)
		{
			for (int i = 0; i < heights.Count; i++)
			{
				var rowDef = new RowDefinition();
				rowDef.Height = new GridLength(heights[i], GridUnitType.Star);
				grid.RowDefinitions.Add(rowDef);
			}

			for (int j = 0; j < heights.Count; j++)
			{
				var rect = new Rectangle();
				var brush = PickBrush(j);
				rect.Fill = brush;
				grid.Children.Add(rect);
				Grid.SetColumn(rect, 0);
				Grid.SetRow(rect, j);
			}
		}
	}
}
