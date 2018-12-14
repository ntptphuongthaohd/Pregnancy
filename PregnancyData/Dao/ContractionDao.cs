﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class ContractionDao
	{
		PregnancyEntity connect = null;
		public ContractionDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IEnumerable<preg_contraction> GetListItem()
		{
			return connect.preg_contraction;
		}

		public preg_contraction GetItemByID(int id)
		{
			return connect.preg_contraction.Where(c => c.id == id).FirstOrDefault();
		}
		public IEnumerable<preg_contraction> GetItemsByParams(preg_contraction data)
		{
			IEnumerable<preg_contraction> result = connect.preg_contraction;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "user_id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.user_id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "date_time" && propertyValue != null)
				{
					result = result.Where(c => c.date_time == Convert.ToDateTime(propertyValue));
				}
				else if (propertyName == "duration" && propertyValue != null)
				{
					result = result.Where(c => c.duration == Convert.ToDateTime(propertyValue));
				}
				else if (propertyName == "interval" && propertyValue != null)
				{
					result = result.Where(c => c.interval == Convert.ToDateTime(propertyValue));
				}
			}
			return result;
		}
		public void InsertData(preg_contraction item)
		{
			connect.preg_contraction.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_contraction item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(preg_contraction item)
		{

			connect.preg_contraction.Remove(item);
			connect.SaveChanges();
		}

	}
}