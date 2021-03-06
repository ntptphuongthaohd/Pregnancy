﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class SizeGuideDao
	{
		PregnancyEntity connect = null;
		public SizeGuideDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IQueryable<preg_size_guide> GetListItem()
		{
			return connect.preg_size_guide;
		}

		public IQueryable<preg_size_guide> GetItemByWeekID(int week_id)
		{
			return connect.preg_size_guide.Where(c => c.week_id == week_id);
		}

		public IQueryable<preg_size_guide> GetItemsByParams(preg_size_guide data)
		{
			IQueryable<preg_size_guide> result = connect.preg_size_guide;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && (int)propertyValue != 0)
				{
					result = result.Where(c => c.id == (int)(propertyValue));
				}
				else if (propertyName == "image" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.image) > 0);
				}
				else if (propertyName == "title" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.title) > 0);
				}
				else if (propertyName == "description" && propertyValue != null)
				{
					result = result.Where(c => SqlFunctions.PatIndex("%" + propertyValue.ToString() + "%", c.description) > 0);
				}
				else if (propertyName == "week_id" && propertyValue != null)
				{
					result = result.Where(c => c.week_id == (int)(propertyValue));
				}
				else if (propertyName == "length" && propertyValue != null)
				{
					result = result.Where(c => c.length == (double)(propertyValue));
				}
				else if (propertyName == "weight" && propertyValue != null)
				{
					result = result.Where(c => c.weight == (double)(propertyValue));
				}
				else if (propertyName == "type" && propertyValue != null)
				{
					result = result.Where(c => c.type == (int)(propertyValue));
				}
			}
			return result;
		}
		public void InsertData(preg_size_guide item)
		{
			connect.preg_size_guide.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_size_guide item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(int id)
		{
			preg_size_guide item = GetItemByWeekID(id).FirstOrDefault();
			connect.preg_size_guide.Remove(item);
			connect.SaveChanges();
		}
	}
}