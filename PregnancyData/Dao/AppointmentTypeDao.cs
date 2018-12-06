﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
	public class AppointmentTypeDao
	{
		PregnancyEntity connect = null;
		public AppointmentTypeDao()
		{
			connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

		public IEnumerable<preg_appointment_type> GetListItem()
		{
			return connect.preg_appointment_types;
		}

		public preg_appointment_type GetItemByID(int id)
		{
			return connect.preg_appointment_types.Where(c => c.id == id).FirstOrDefault();
		}
		public IEnumerable<preg_appointment_type> GetItemsByParams(preg_appointment_type data)
		{
			IEnumerable<preg_appointment_type> result = connect.preg_appointment_types;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "type" && propertyValue != null)
				{
					result = result.Where(c => c.type == propertyValue.ToString());
				}
			}
			return result;
		}
		public void InsertData(preg_appointment_type item)
		{
			connect.preg_appointment_types.Add(item);
			connect.SaveChanges();
		}

		public void UpdateData(preg_appointment_type item)
		{
			connect.SaveChanges();
		}

		public void DeleteData(int id)
		{
			preg_appointment_type item = GetItemByID(id);
			connect.preg_appointment_types.Remove(item);
			connect.SaveChanges();
		}

	}
}