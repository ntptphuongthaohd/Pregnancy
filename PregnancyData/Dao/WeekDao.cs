﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class WeekDao
	{
		PregnancyEntity connect = null;
		public WeekDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IEnumerable<preg_week> GetListItem()
		{
			return connect.preg_weeks;
		}

		public preg_week GetItemByID(int id)
		{
			return connect.preg_weeks.Where(c => c.id == id).FirstOrDefault();
		}

		public IEnumerable<preg_week> GetItemsByParams(preg_week data)
		{
			IEnumerable<preg_week> result = connect.preg_weeks;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "length" && propertyValue != null)
				{
					result = result.Where(c => c.length == Convert.ToDouble(propertyValue));
				}
				else if (propertyName == "weight" && propertyValue != null)
				{
					result = result.Where(c => c.weight == Convert.ToDouble(propertyValue));
				}
				else if (propertyName == "title" && propertyValue != null)
				{
					result = result.Where(c => c.title == propertyValue.ToString());
				}
				else if (propertyName == "short_description" && propertyValue != null)
				{
					result = result.Where(c => c.short_description == propertyValue.ToString());
				}
				else if (propertyName == "description" && propertyValue != null)
				{
					result = result.Where(c => c.description == propertyValue.ToString());
				}
				else if (propertyName == "daily_relation" && propertyValue != null)
				{
					result = result.Where(c => c.daily_relation == propertyValue.ToString());
				}
			}
			return result;
		}

		public void InsertData(preg_week item)
		{
			connect.preg_weeks.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_week item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(int id)
		{
			preg_week item = GetItemByID(id);
			connect.preg_weeks.Remove(item);
			connect.SaveChanges();
		}

	}
}