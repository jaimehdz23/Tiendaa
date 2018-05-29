using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.BIZ
{
	public class ManejadorEmpleados : IManejadorEmpleados
	{
		IRepositorio<Empleado> repositorio;
		public ManejadorEmpleados(IRepositorio<Empleado> repositorio)
		{
			this.repositorio = repositorio;
		}
		public List<Empleado> Listar => repositorio.Read;

		public bool Agregar(Empleado entidad)
		{
			return repositorio.Create(entidad);
		}

		

		public Empleado BuscarPorId(string id)
		{
			return Listar.Where(e => e.Id == id).SingleOrDefault();
		}

		public bool Eliminar(string id)
		{
			return repositorio.Delete(id);
		}

		public List<Empleado> EmpleadosPorMatricula(string matricula)
		{
			return Listar.Where(e => e.Matricula == matricula).ToList();
		}

		public bool Modificar(Empleado entidad)
		{
			return repositorio.Update(entidad);
		}
	}
}
