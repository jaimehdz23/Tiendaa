﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tienda.COMMON.Entidades
{
    public class Ticket
    {
		public string Archivo { get; set; }
		public Ticket(string archivo)
		{
			Archivo = archivo;
		}
		public bool Guardar(string elementos)
		{
			try
			{
				StreamWriter fila = new StreamWriter(Archivo);
				fila.Write(elementos);
				fila.Close();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
