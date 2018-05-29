using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.DAL
{
	public class RepositorioDeUsuarios : IRepositorio<Usuarios>
	{
		private string DBName = "Tienda.db";
		private string TableName = "Usuarios";
		public List<Usuarios> Read
		{
			get
			{
				List<Usuarios> datos = new List<Usuarios>();
				using (var db = new LiteDatabase(DBName))
				{
					datos = db.GetCollection<Usuarios>(TableName).FindAll().ToList();
				}
				return datos;
			}
		}

		public bool Create(Usuarios entidad)
		{
			entidad.Id = Guid.NewGuid().ToString();
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Usuarios>(TableName);
					coleccion.Insert(entidad);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Delete(string id)
		{
			try
			{
				int r;
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Usuarios>(TableName);
					r = coleccion.Delete(e => e.Id == id);
				}
				return r > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Update(Usuarios entidadModificada)
		{
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Usuarios>(TableName);
					coleccion.Update(entidadModificada);
				}
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}
	}
}
