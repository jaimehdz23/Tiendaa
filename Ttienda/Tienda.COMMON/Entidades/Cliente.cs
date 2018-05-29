using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.COMMON.Entidades
{
    public class Cliente:Base
    {
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Estacionamiento { get; set; }
		public override string ToString()
		{
			return Nombre;
		}
	}
}
