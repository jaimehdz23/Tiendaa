﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.COMMON.Entidades
{
    public class Empleado:Base
    {
		public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string Direccion { get; set; }
		public string Telefono { get; set; }
		public string Matricula { get; set; }
		public override string ToString()
		{
			return Nombre;
		}
	}
}
