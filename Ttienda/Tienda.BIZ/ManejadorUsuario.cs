using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.BIZ
{
	public class ManejadorUsuario : IManejadorUsuarios
	{
		IRepositorio<Usuarios> repositorio;
		public ManejadorUsuario(IRepositorio<Usuarios> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Usuarios> Listar => repositorio.Read;

		public bool Agregar(Usuarios entidad)
		{
			return repositorio.Create(entidad);
		}

		public Usuarios BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Usuarios entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
