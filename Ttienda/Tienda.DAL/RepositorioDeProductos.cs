using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tienda.COMMON.Entidades;
using Tienda.COMMON.Interfaces;

namespace Tienda.DAL
{
	public class RepositorioDeProductos : IRepositorio<Productoss>
	{
		private string DBName = @"C:\Baseproyecto\Tienda.db";
		private string TableName = "Productos";
		public List<Productoss> Read
		{
			get
			{
				List<Productoss> datos = new List<Productoss>();
				using (var db = new LiteDatabase(DBName))
				{
					datos = db.GetCollection<Productoss>(TableName).FindAll().ToList();
				}
				return datos;
			}
		}
		public bool Create(Productoss entidad)
		{
			entidad.Id = Guid.NewGuid().ToString();
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Productoss>(TableName);
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
					var coleccion = db.GetCollection<Productoss>(TableName);
					r = coleccion.Delete(e => e.Id == id);
				}
				return r > 0;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool Update(Productoss entidadModificada)
		{
			try
			{
				using (var db = new LiteDatabase(DBName))
				{
					var coleccion = db.GetCollection<Productoss>(TableName);
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
