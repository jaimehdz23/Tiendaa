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
using System.Windows.Shapes;
using Tienda.BIZ;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;
using Tienda.DAL;

namespace Tienda.GUI
{
	/// <summary>
	/// Lógica de interacción para Inicio.xaml
	/// </summary>
	public partial class Inicio : Window
	{
		IManejadorUsuarios manejadorUsuarios;
		public Inicio()
		{
			InitializeComponent();
			manejadorUsuarios = new ManejadorUsuario(new RepositorioDeUsuarios());
			Actualizar();
		}

		private void Actualizar()
		{
			cmbUsuario.ItemsSource = null;
			cmbUsuario.ItemsSource = manejadorUsuarios.Listar;
		}

		private void btnEntrar_Click(object sender, RoutedEventArgs e)
		{
			if (cmbUsuario.Text == "")
			{
				MessageBox.Show("Error", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (string.IsNullOrEmpty(txbContraseña.Password))
			{
				MessageBox.Show("Ingresar la contraseña", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
				return;

			}
			if (string.IsNullOrEmpty(txbContraseña.Password))
			{
				MessageBox.Show("No ha ingresado la contraseña", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (cmbUsuario.SelectedItem != null)
			{
				Usuarios a = cmbUsuario.SelectedItem as Usuarios;
				if (txbContraseña.Password == a.Contraseña)
				{
					Progressbar b = new Progressbar();
					b.Show();
					this.Close();
				}
				else
				{
					MessageBox.Show("Contraseña Inconrrecta", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
					return;
				}

			}
			else
			{
				MessageBox.Show("Selecciona un  usuario", "Uusario", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnSalir_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}
	}
}
