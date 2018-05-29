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
	/// Lógica de interacción para Categoria.xaml
	/// </summary>
	public partial class Categoria : Window
	{
		enum accion
		{
			Nuevo,
			Editar
		}
		IManejadorCategorias manejadorCategorias;

		accion accionCategoria;

		public Categoria()
		{
			InitializeComponent();
			manejadorCategorias = new ManejadorCategorias(new RepositorioDeCategorias());

			PonerBotonesCategoriaEnEdicion(false);
			LimpiarCamposDeCategoria();
			ActualizarTablaCategoria();
		}

		private void ActualizarTablaCategoria()
		{
			dtgCategoria.ItemsSource = null;
			dtgCategoria.ItemsSource = manejadorCategorias.Listar;
		}

		private void LimpiarCamposDeCategoria()
		{
			txbCategoriaTipoDeCategoria.Clear();
			txbCategoriaId.Text = "";
		}

		private void PonerBotonesCategoriaEnEdicion(bool value)
		{
			btnCategoriaCancelar.IsEnabled = value;
			btnCategoriaEditar.IsEnabled = !value;
			btnCategoriaEliminar.IsEnabled = !value;
			btnCategoriaGuardar.IsEnabled = value;
			btnCategoriaNuevo.IsEnabled = !value;
		}

		private void btnCategoriaNuevo_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeCategoria();
			PonerBotonesCategoriaEnEdicion(true);
			accionCategoria = accion.Nuevo;
		}

		private void btnCategoriaEditar_Click(object sender, RoutedEventArgs e)
		{
			Categorias cat = dtgCategoria.SelectedItem as Categorias;
			if (cat != null)
			{
				txbCategoriaId.Text = cat.Id;
				txbCategoriaTipoDeCategoria.Text = cat.TipoDeCategoria;
				accionCategoria = accion.Editar;
				PonerBotonesCategoriaEnEdicion(true);
			}
		}

		private void btnCategoriaGuardar_Click(object sender, RoutedEventArgs e)
		{
			if (accionCategoria == accion.Nuevo)
			{
				Categorias cat = new Categorias()
				{
					TipoDeCategoria = txbCategoriaTipoDeCategoria.Text
				};
				if (manejadorCategorias.Agregar(cat))
				{
					MessageBox.Show("Categoria agregada correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeCategoria();
					ActualizarTablaCategoria();
					PonerBotonesCategoriaEnEdicion(false);
				}
				else
				{
					MessageBox.Show("La Categoria no se pudo agregar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}
			else
			{
				Categorias cat = dtgCategoria.SelectedItem as Categorias;
				cat.TipoDeCategoria = txbCategoriaTipoDeCategoria.Text;
				if (manejadorCategorias.Modificar(cat))
				{
					MessageBox.Show("categoria modificada correctamente", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					LimpiarCamposDeCategoria();
					ActualizarTablaCategoria();
					PonerBotonesCategoriaEnEdicion(false);
				}
				else
				{
					MessageBox.Show("La Categoria no se pudo actualizar", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Error);
				}
			}

		}

		private void btnCategoriaCancelar_Click(object sender, RoutedEventArgs e)
		{
			LimpiarCamposDeCategoria();
			PonerBotonesCategoriaEnEdicion(false);
		}

		private void btnCategoriaEliminar_Click(object sender, RoutedEventArgs e)
		{
			Categorias cat = dtgCategoria.SelectedItem as Categorias;
			if (cat != null)
			{
				if (MessageBox.Show("Realmente deseas eliminar esta Categoria?", "Farmacia", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
				{
					if (manejadorCategorias.Eliminar(cat.Id))
					{
						MessageBox.Show("Categoria eliminada", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
						ActualizarTablaCategoria();
					}
					else
					{
						MessageBox.Show("No se pudo eliminar la Categoria", "Farmacia", MessageBoxButton.OK, MessageBoxImage.Information);
					}
				}
			}
		}
	}
}
