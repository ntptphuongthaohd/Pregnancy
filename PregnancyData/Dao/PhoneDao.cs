﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class PhoneDao
	{
		PregnancyEntity connect = null;
		public PhoneDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IQueryable<preg_phone> GetListItem()
		{
			return connect.preg_phone;
		}

		public IQueryable<preg_phone> GetItemByID(int id)
		{
			return connect.preg_phone.Where(c => c.id == id);
		}

		public IQueryable<preg_phone> GetItemsByParams(preg_phone data)
		{
			IQueryable<preg_phone> result = connect.preg_phone;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && (int)propertyValue != 0)
				{
					result = result.Where(c => c.id == (int)(propertyValue));
				}
				else if (propertyName == "profession_id" && propertyValue != null)
				{
					result = result.Where(c => c.profession_id == (int)(propertyValue));
				}
				else if (propertyName == "phone_number" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.phone_number) > 0);
				}
				else if (propertyName == "user_id" && propertyValue != null)
				{
					result = result.Where(c => c.user_id == (int)(propertyValue));
				}
				else if (propertyName == "name" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.name) > 0);
				}
			}
			return result;
		}

		public void InsertData(preg_phone item)
		{
			connect.preg_phone.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_phone item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(preg_phone item)
		{
			connect.preg_phone.Remove(item);
			connect.SaveChanges();
		}
	}
}