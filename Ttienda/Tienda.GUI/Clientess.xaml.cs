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
	/// Lógica de interacción para Clientess.xaml
	/// </summary>
	public partial class Clientess : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}

		IManejadorClientes manejadorClientes;

		accion accionClientes;

		public Clientess()
		{
			InitializeComponent();

			manejadorClientes = new ManejadorClientes(new RepoitorioDeClientes());

			PonerBotonesClientesEnEdicion(false);
			LimpiarCamposClientes();
			ActualizarTablaClientes();
		}

		private void ActualizarTablaClientes()
		{
			dtgCliente.ItemsSource = null;
			dtgCliente.ItemsSource = manejadorClientes.Listar;
			
		}

		private void LimpiarCamposClientes()
		{
			txbClienteNombre.Clear();
			txbClienteApellido.Clear();
			txbClienteId.Text = "";
			txbClienteTelefono.Clear();
			txbClienteDireccion.Clear();
			txbClienteEstacionamiento.Clear();
		}

		private void PonerBotonesClientesEnEdicion(bool value)
		{
			btnClienteCancelar.IsEnabled = value;
			btnClienteEditar.IsEnabled = !value;
			btnClienteEliminar.IsEnabled = !value;
			btnClienteGuardar.IsEnabled = value;
			btnClienteNuevo.IsEnabled = !value;
		}

		private void btnClienteNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposClientes();
			PonerBotonesClientesEnEdicion(true);
			accionClientes = accion.Nuevo;
		}

		private void btnClienteEditar_Click(object sender, RoutedEventArgs e)
		{
			Cliente emp = dtgCliente.SelectedItem as Cliente;
			if (emp != null)
			{
				txbClienteId.Text = emp.Id;
				txbClienteApellido.Text = emp.Apellido;
				txbClienteEstacionamiento.Text = emp.Estacionamiento;
				txbClienteNombre.Text = emp.Nombre;
				txbClienteDireccion.Text = emp.Direccion;
				txbClienteTelefono.Text = emp.Telefono;
				accionClientes = accion.Editar;
				PonerBotonesClientesEnEdicion(true);
			}
		}

		private void btnClienteGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionClientes == accion.Nuevo)
			{
				Cliente emp = new Cliente()
				{
					Nombre = txbClienteNombre.Text,
					Apellido = txbClienteApellido.Text,
					Direccion = txbClienteDireccion.Text,
					Telefono = txbClienteTelefono.Text,
					Estacionamiento = txbClienteEstacionamiento.Text
				};
				if (manejadorClientes.Agregar(emp))
				{
					MessageBox.Show("Cliente agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposClientes();
					ActualizarTablaClientes();
					PonerBotonesClientesEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Cliente no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Cliente emp = dtgCliente.SelectedItem as Cliente;
				emp.Nombre = txbClienteNombre.Text;
				emp.Apellido = txbClienteApellido.Text;
				emp.Direccion = txbClienteDireccion.Text;
				emp.Telefono = txbClienteTelefono.Text;
				emp.Estacionamiento = txbClienteEstacionamiento.Text;

				if (manejadorClientes.Modificar(emp))
				{
					MessageBox.Show("El Cliente modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposClientes();
					ActualizarTablaClientes();
					PonerBotonesClientesEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Cliente no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void btnClienteCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposClientes();
			PonerBotonesClientesEnEdicion(false);
		}

		private void btnClienteEliminar_Click(object sender, RoutedEventArgs e)
		{
			Cliente emp = dtgCliente.SelectedItem as Cliente;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este Cliente?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorClientes.Eliminar(emp.Id))
					{
						MessageBox.Show("Cliente eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaClientes();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el Cliente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
