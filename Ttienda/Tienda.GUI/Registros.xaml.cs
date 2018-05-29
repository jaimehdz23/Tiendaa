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
	/// Lógica de interacción para Registros.xaml
	/// </summary>
	public partial class Registros : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}
		IManejadorUsuarios manejadorUsuarios;

		accion accionUsuarios;

		public Registros()
		{
			InitializeComponent();

			manejadorUsuarios = new ManejadorUsuario(new RepositorioDeUsuarios());

			PonerBotonesUsuarioEnEdicion(false);
			LimpiarCamposDeUsuario();
			ActualizarTablaUsuario();
		}

		private void ActualizarTablaUsuario()
		{
			dtgUsuario.ItemsSource = null;
			dtgUsuario.ItemsSource = manejadorUsuarios.Listar;
		}

		private void LimpiarCamposDeUsuario()
		{
			txbUsuario.Clear();
			txbPasword.Clear();
			txbPasword2.Clear();
		}

		private void PonerBotonesUsuarioEnEdicion(bool value)
		{
			btnUsuarioCancelar.IsEnabled = value;
			btnUsuarioEditar.IsEnabled = !value;
			btnUsuarioEliminar.IsEnabled = !value;
			btnUsuarioGuardar.IsEnabled = value;
			btnUsuarioNuevo.IsEnabled = !value;
		}

		private void btnUsuarioNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeUsuario();
			PonerBotonesUsuarioEnEdicion(true);
			accionUsuarios = accion.Nuevo;
		}

		private void btnUsuarioEditar_Click(object sender, RoutedEventArgs e)
		{
			if (dtgUsuario.SelectedItem != null)
			{

				Usuarios cat = dtgUsuario.SelectedItem as Usuarios;


				txbUsuario.Text = cat.NuevoUsuario;
				txbPasword.Text = cat.Contraseña;
				txbPasword2.Text = cat.ConfirmarContraseña;
				accionUsuarios = accion.Editar;
				PonerBotonesUsuarioEnEdicion(true);
			}
			else
			{
				MessageBox.Show("No selecciono  ni un elemento de la tabla de los ususarios", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}

		private void btnUsuarioGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionUsuarios == accion.Nuevo)
			{
				Usuarios cat = new Usuarios()
				{
					NuevoUsuario = txbUsuario.Text,
					Contraseña = txbPasword.Text,
					ConfirmarContraseña = txbPasword2.Text

				};
				if (manejadorUsuarios.Agregar(cat))
				{
					MessageBox.Show("Usuario agregado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeUsuario();
					ActualizarTablaUsuario();
					PonerBotonesUsuarioEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Usuario no se pudo agregar", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Usuarios cat = dtgUsuario.SelectedItem as Usuarios;
				cat.Contraseña = txbPasword.Text;
				cat.NuevoUsuario = txbUsuario.Text;
				cat.ConfirmarContraseña = txbPasword2.Text;

				if (manejadorUsuarios.Modificar(cat))
				{
					MessageBox.Show("Usuario modificado correctamente", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeUsuario();
					ActualizarTablaUsuario();
					PonerBotonesUsuarioEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Usuario no se pudo actualizar", "Usuario", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void btnUsuarioCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeUsuario();
			PonerBotonesUsuarioEnEdicion(false);
		}

		private void btnUsuarioEliminar_Click(object sender, RoutedEventArgs e)
		{
			Usuarios cat = dtgUsuario.SelectedItem as Usuarios;
			if (cat != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este Usuario?", "Usuario", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorUsuarios.Eliminar(cat.Id))
					{
						MessageBox.Show("Usuario eliminado", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaUsuario();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el Usuario", "Usuario", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
