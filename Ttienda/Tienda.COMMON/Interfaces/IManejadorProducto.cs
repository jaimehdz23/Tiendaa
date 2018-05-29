using System;
using System.Collections.Generic;
using System.Text;
using Tienda.COMMON.Entidades;

namespace Tienda.COMMON.Interfaces
{
   public interface IManejadorProducto : IManejadorGenerico<Productoss>
	{
		List<Productoss> ProductosDeCategoria(string categoria);
	}
}
