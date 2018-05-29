using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.BIZ
{
	public class ManejadorTickets : IManejadorTickets
	{
		IRepositorio<Iventas> repositorio;
		public ManejadorTickets(IRepositorio<Iventas> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Iventas> Listar => repositorio.Read;

		public bool Agregar(Iventas entidad)
		{
			return repositorio.Create(entidad);
		}

		

		public Iventas BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public bool Modificar(Iventas entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
