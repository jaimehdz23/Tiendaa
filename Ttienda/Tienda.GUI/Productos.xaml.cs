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
	/// Lógica de interacción para Productos.xaml
	/// </summary>
	public partial class Productos : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}
		IManejadorProducto manejadorProducto;

		accion accionProductos;
		public Productos()
		{
			InitializeComponent();

			manejadorProducto = new ManejadoProductos(new RepositorioDeProductos());

			PonerBotonesProductosEnEdicion(false);
			LimpiarCamposDeProductos();
			ActualizarTablaProdutos();
		}

		private void ActualizarTablaProdutos()
		{
			dtgProductos.ItemsSource = null;
			dtgProductos.ItemsSource = manejadorProducto.Listar;
		}

		private void LimpiarCamposDeProductos()
		{
			txbProductosNombre.Clear();
			txbProductosCategoria.Clear();
			txbProductosId.Text = "";
			txbProductosDescripcion.Clear();
			txbProductosPrecioCompra.Clear();
			txbProductosPrecioVenta.Clear();
		}

		private void PonerBotonesProductosEnEdicion(bool value)
		{
			btnProductosCancelar.IsEnabled = value;
			btnProductosEditar.IsEnabled = !value;
			btnProductosEliminar.IsEnabled = !value;
			btnProductosGuardar.IsEnabled = value;
			btnProductosNuevo.IsEnabled = !value;
		}

		private void btnProductosNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeProductos();
			PonerBotonesProductosEnEdicion(true);
			accionProductos = accion.Nuevo;
		}

		private void btnProductosEditar_Click(object sender, RoutedEventArgs e)
		{
			Productoss emp = dtgProductos.SelectedItem as Productoss;
			if (emp != null)
			{
				txbProductosId.Text = emp.Id;
				txbProductosNombre.Text = emp.Nombre;
				txbProductosCategoria.Text = emp.Categoria;
				txbProductosDescripcion.Text = emp.Descripcion;
				txbProductosPrecioCompra.Text = emp.PrecioCompra;
				txbProductosPrecioVenta.Text = emp.PrecioVenta;
				accionProductos = accion.Editar;
				PonerBotonesProductosEnEdicion(true);
			}
		}

		private void btnProductosGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionProductos == accion.Nuevo)
			{
				Productoss emp = new Productoss()
				{
					Nombre = txbProductosNombre.Text,
					Categoria = txbProductosCategoria.Text,
					Descripcion = txbProductosDescripcion.Text,
					PrecioCompra = txbProductosPrecioCompra.Text,
					PrecioVenta = txbProductosPrecioVenta.Text
				};
				if (manejadorProducto.Agregar(emp))
				{
					MessageBox.Show("Producto agregado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeProductos();
					ActualizarTablaProdutos();
					PonerBotonesProductosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Producto no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Productoss emp = dtgProductos.SelectedItem as Productoss;
				emp.Nombre = txbProductosNombre.Text;
				emp.Categoria = txbProductosCategoria.Text;
				emp.Descripcion = txbProductosDescripcion.Text;
				emp.PrecioCompra = txbProductosPrecioCompra.Text;
				emp.PrecioVenta = txbProductosPrecioVenta.Text;

				if (manejadorProducto.Modificar(emp))
				{
					MessageBox.Show("El Producto modificado correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeProductos();
					ActualizarTablaProdutos();
					PonerBotonesProductosEnEdicion(false);
				}
				else
				{
					MessageBox.Show("El Peoducto no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
		}

		private void btnProductosCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeProductos();
			PonerBotonesProductosEnEdicion(false);
		}

		private void btnProductosEliminar_Click(object sender, RoutedEventArgs e)
		{
			Productoss emp = dtgProductos.SelectedItem as Productoss;
			if (emp != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar este productos?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorProducto.Eliminar(emp.Id))
					{
						MessageBox.Show("Producto eliminado", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaProdutos();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar el producto", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}

		private void txbProductosPrecioVenta_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void txbProductosPrecioCompra_TextChanged(object sender, TextChangedEventArgs e)
		{
			//if (!(char.IsNumber()))
			//{
			//	MessageBox.Show("error", "error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
			//	return;
			//}
		}

	}

}
	

