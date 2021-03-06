﻿using PregnancyData.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace PregnancyData.Dao
{
	public class MyBellyDao
	{
		PregnancyEntity connect = null;
		public MyBellyDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IQueryable<preg_my_belly> GetListItem()
		{
			return connect.preg_my_belly;
		}

		public IQueryable<preg_my_belly> GetItemsByParams(preg_my_belly data)
		{
			IQueryable<preg_my_belly> result = connect.preg_my_belly;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && (int)(propertyValue) != 0)
				{
					result = result.Where(c => c.id == (int)(propertyValue));
				}
				else if (propertyName == "image" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.image) > 0);
				}
				else if (propertyName == "month" && (int)propertyValue != 0)
				{
					result = result.Where(c => c.month == (int)(propertyValue));
				}
				else if (propertyName == "user_id" && propertyValue != null)
				{
					result = result.Where(c => c.user_id == (int)(propertyValue));
				}
			}
			return result;
		}
		public void InsertData(preg_my_belly item)
		{
			connect.preg_my_belly.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_my_belly item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(preg_my_belly item)
		{
			connect.preg_my_belly.Remove(item);
			connect.SaveChanges();
		}
	}
}