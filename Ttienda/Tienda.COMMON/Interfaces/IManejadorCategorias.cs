using System;
using System.Collections.Generic;
using System.Text;
using Tienda.COMMON.Entidades;

namespace Tienda.COMMON.Interfaces
{
    public interface IManejadorCategorias: IManejadorGenerico<Categorias>
    {
		List<Categorias> Categorias(string tipodecategoria);
	}
}
