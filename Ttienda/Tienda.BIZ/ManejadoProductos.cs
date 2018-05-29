using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.BIZ
{
	public class ManejadoProductos : IManejadorProducto
	{
		IRepositorio<Productoss> repositorio;
		public ManejadoProductos(IRepositorio<Productoss> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Productoss> Listar => repositorio.Read;

		public bool Agregar(Productoss entidad)
		{
			return repositorio.Create(entidad);
		}

		public Productoss BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Productoss entidad)
		{
			return repositorio.Update(entidad);
		}

		public List<Productoss> ProductosDeCategoria(string categoria)
		{
			return Listar.Where(e => e.Categoria == categoria).ToList();
		}
	}
}
