using System;
using System.Collections.Generic;
using System.Text;
using Tienda.COMMON.Entidades;

namespace Tienda.COMMON.Interfaces
{
   public interface IManejadorClientes : IManejadorGenerico<Cliente>
	{
		List<Cliente> ClientePorTelefono(string telefono);
	}
}
