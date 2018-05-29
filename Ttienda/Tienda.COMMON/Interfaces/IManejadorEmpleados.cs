using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Tienda.COMMON.Entidades;

namespace Tienda.COMMON.Interfaces
{
    public interface IManejadorEmpleados : IManejadorGenerico<Empleado>
	{
		List<Empleado> EmpleadosPorMatricula(string matricula);
		
	}
}
