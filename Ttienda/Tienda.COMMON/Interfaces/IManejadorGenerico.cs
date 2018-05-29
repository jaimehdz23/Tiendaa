using System;
using System.Collections.Generic;
using System.Text;
using Tienda.COMMON.Entidades;

namespace Tienda.COMMON.Interfaces
{
   public interface IManejadorGenerico<T> where T:Base
    {
		bool Agregar(T entidad);
		List<T> Listar { get; }
		bool Eliminar(string id);
		bool Modificar(T entidad);
		T BuscarPorId(string id);
	}
}
