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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Tienda.GUI
{
	/// <summary>
	/// Lógica de interacción para Progressbar.xaml
	/// </summary>
	public partial class Progressbar : Window
	{
		public Progressbar()
		{
			InitializeComponent();
			Loadprogrssbar();
			pb1.ValueChanged += Pb1_ValueChanged;
		}

		private void Pb1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			if (pb1.Value == 100)

			{
				MainWindow Miventana = new MainWindow();
				Miventana.Show();
				this.Close();

			}
		}

		private void Loadprogrssbar()
		{
			Duration dur = new Duration(TimeSpan.FromSeconds(30));
			DoubleAnimation dblani = new DoubleAnimation(200.0, dur);
			pb1.BeginAnimation(System.Windows.Controls.Primitives.RangeBase.ValueProperty, dblani);
		}
	}
}
