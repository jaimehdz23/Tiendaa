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
	/// Lógica de interacción para Empleados.xaml
	/// </summary>
	public partial class Empleados : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}

		IManejadorEmpleados manejadorEmpleados;

		accion accionEmpleados;

		public Empleados()
		{
			InitializeComponent();

			manejadorEmpleados = new ManejadorEmpleados(new RepositorioDeEmpleados());

			PonerBotonesDeEmpleadosEnEdicion(false);
			LimpiarCamposDeEmpleados();
			ActualizarTablaEmpleados();
		}

		private void ActualizarTablaEmpleados()
		{
			dtgEmpleado.ItemsSource = null;
			dtgEmpleado.ItemsSource = manejadorEmpleados.Listar;
		}

		private void LimpiarCamposDeEmpleados()
		{
			txbEmpleadoNombre.Clear();
			txbEmpleadoApellido.Clear();
			txbEmpleadoId.Text = "";
			txbEmpleadoDireccion.Clear();
			txbEmpleadoTelefono.Clear();
			txbEmpleadoMatricula.Clear();
		}

		private void PonerBotonesDeEmpleadosEnEdicion(bool value)
		{
			btnEmpleadoCancelar.IsEnabled = value;
			btnEmpleadoEditar.IsEnabled = !value;
			btnEmpleadoEliminar.IsEnabled = !value;
			btnEmpleadoGuardar.IsEnabled = value;
			btnEmpleadoNuevo.IsEnabled = !value;
		}

		private void btnEmpleadoNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeEmpleados();
			PonerBotonesDeEmpleadosEnEdicion(true);
			accionEmpleados = accion.Nuevo;
		}

		private void btnEmpleadoEditar_Click(object sender, RoutedEventArgs e)
		{
			Empleado emp = dtgEmpleado.SelectedItem as Empleado;
			if (emp != null)
			{
				txbEmpleadoId.Text = emp.Id;
				txbEmpleadoApellido.Text = emp.Apellido;
				txbEmpleadoDireccion.Text = emp.Direccion;
				txbEmpleadoNombre.Text = emp.Nombre;
				txbEmpleadoTelefono.Text = emp.Telefono;
				txbEmpleadoMatricula.Text = emp.Matricula;
				accionEmpleados = accion.Editar;
				PonerBotonesDeEmpleadosEnEdicion(true);
			}
		}

		private void btnEmpleadoGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionEmpleados == accion.Nuevo)
			{
				Empleado emp = new Empleado()
				{
					Nombre = txbEmpleadoNombre.Text,
					Apellido = txbEmpleadoApellido.Text,
					Direccion = txbEmpleadoDireccion.Text,
					Telefono = txbEmpleadoTelefono.Text,
					Matricula = txbEmpleadoMatricula.Text
				};
				if (manejadorEmpleados.Agregar(emp))
				{
					MessageBox.Show("Empleado agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeEmpleados();
					ActualizarTablaEmpleados();
					PonerBotonesDeEmpleadosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Empleado no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Empleado emp = dtgEmpleado.SelectedItem as Empleado;
				emp.Nombre = txbEmpleadoNombre.Text;
				emp.Apellido = txbEmpleadoApellido.Text;
				emp.Direccion = txbEmpleadoDireccion.Text;
				emp.Telefono = txbEmpleadoTelefono.Text;
				emp.Matricula = txbEmpleadoMatricula.Text;

				if (manejadorEmpleados.Modificar(emp))
				{
					MessageBox.Show("El Empleado modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeEmpleados();
					ActualizarTablaEmpleados();
					PonerBotonesDeEmpleadosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Empleado no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void btnEmpleadoCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeEmpleados();
			PonerBotonesDeEmpleadosEnEdicion(false);
		}

		private void btnEmpleadoEliminar_Click(object sender, RoutedEventArgs e)
		{
			Empleado emp = dtgEmpleado.SelectedItem as Empleado;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este Empleado?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorEmpleados.Eliminar(emp.Id))
					{
						MessageBox.Show("Empleado eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaEmpleados();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el Empleado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
