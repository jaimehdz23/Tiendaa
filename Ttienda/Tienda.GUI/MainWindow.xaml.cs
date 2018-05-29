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

namespace Tienda.GUI
{
	/// <summary>
	/// Lógica de interacción para MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonPopup_Click(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown();
		}

		private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Visible;
			ButtonCloseMenu.Visibility = Visibility.Collapsed;
		}

		private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
		{
			ButtonOpenMenu.Visibility = Visibility.Collapsed;
			ButtonCloseMenu.Visibility = Visibility.Visible;
		}

		private void btnHome_Click(object sender, RoutedEventArgs e)
		{
			Registros Miventana = new Registros();
			Miventana.Show();
		}

		private void btnCategoria_Click(object sender, RoutedEventArgs e)
		{
			Categoria Miventana = new Categoria();
			Miventana.Show();
		}

		private void btnProducto_Click(object sender, RoutedEventArgs e)
		{
			Productos Miventana = new Productos();
			Miventana.Show();
		}

		private void btnEmpleado_Click(object sender, RoutedEventArgs e)
		{
			Empleados Miventana = new Empleados();
			Miventana.Show();
		}

		private void btnCliente_Click(object sender, RoutedEventArgs e)
		{
			Clientess Miventana = new Clientess();
			Miventana.Show();
		}
	}
}
