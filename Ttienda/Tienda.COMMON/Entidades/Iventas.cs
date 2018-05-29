using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.COMMON.Entidades
{
   public class Iventas:Base
    {
		public string Fecha { get; set; }
		public string Ncliente { get; set; }
		public string Nempleado { get; set; }
		//public List<Ventas> ProductoVentas { get; set; }
		public float StotalPago { get; set; }
		public float IvaPago { get; set; }
		public float TotalPago { get; set; }
	}
}
