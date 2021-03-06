﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class TodoDao
	{
		PregnancyEntity connect = null;
		public TodoDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IQueryable<preg_todo> GetListItem()
		{
			return connect.preg_todo;
		}

		public IQueryable<preg_todo> GetItemByID(int id)
		{
			return connect.preg_todo.Where(c => c.id == id);
		}
		public IQueryable<preg_todo> GetItemsByParams(preg_todo data)
		{
			IQueryable<preg_todo> result = connect.preg_todo;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && (int)propertyValue != 0)
				{
					result = result.Where(c => c.id == (int)(propertyValue));
				}
				else if (propertyName == "day_id" && propertyValue != null)
				{
					result = result.Where(c => c.day_id == (int)(propertyValue));
				}
				else if (propertyName == "title" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.title) > 0);
				}
				else if (propertyName == "custom_task_by_user_id" && propertyValue != null)
				{
					result = result.Where(c => c.custom_task_by_user_id == (int)(propertyValue));
				}
			}
			return result;
		}

		public void InsertData(preg_todo item)
		{
			connect.preg_todo.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_todo item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(preg_todo item)
		{
			connect.preg_todo.Remove(item);
			connect.SaveChanges();
		}
	}
}