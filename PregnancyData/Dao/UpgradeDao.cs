﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class UpgradeDao
	{
		PregnancyEntity connect = null;
		public UpgradeDao()
		{
			connect = new PregnancyEntity();
		}

		public IEnumerable<preg_upgrade> GetListItem()
		{
			return connect.preg_upgrades;
		}

		public preg_upgrade GetItemByID(int id)
		{
			return connect.preg_upgrades.Where(c => c.id == id).FirstOrDefault();
		}

		public IEnumerable<preg_upgrade> GetItemsByParams(preg_upgrade data)
		{
			IEnumerable<preg_upgrade> result = connect.preg_upgrades;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "user_id" && propertyValue != null)
				{
					result = result.Where(c => c.user_id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "version" && propertyValue != null)
				{
					result = result.Where(c => c.version == propertyValue.ToString());
				}
			}
			return result;
		}

		public void InsertData(preg_upgrade item)
		{
			connect.preg_upgrades.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_upgrade item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(int id)
		{
			preg_upgrade item = GetItemByID(id);
			connect.preg_upgrades.Remove(item);
			connect.SaveChanges();
		}

	}
}