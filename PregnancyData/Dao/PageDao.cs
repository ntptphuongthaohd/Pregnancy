﻿using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class PageDao
    {
         PregnancyEntity connect = null;
        public PageDao()
        {
            connect = new PregnancyEntity();
			connect.Configuration.ProxyCreationEnabled = false;
		}

        public IEnumerable<preg_page> GetListItem()
        {
            return connect.preg_pages;
        }

        public preg_page GetItemByID(int id)
        {
            return connect.preg_pages.Where(c => c.id == id).FirstOrDefault();
        }
		public IEnumerable<preg_page> GetItemsByParams(preg_page data)
		{
			IEnumerable<preg_page> result = connect.preg_pages;
			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "id" && Convert.ToInt32(propertyValue) != 0)
				{
					result = result.Where(c => c.id == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "title" && propertyValue != null)
				{
					result = result.Where(c => c.title == Convert.ToInt32(propertyValue));
				}
				else if (propertyName == "content" && propertyValue != null)
				{
					result = result.Where(c => c.content == propertyValue.ToString());
				}
			}
			return result;
		}
		public void InsertData(preg_page item)
        {
            connect.preg_pages.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_page item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_page item = GetItemByID(id);
            connect.preg_pages.Remove(item);
            connect.SaveChanges();
        }
		public string resultReturn(preg_page data)
		{
			string result = "{";

			for (int i = 0; i < data.GetType().GetProperties().ToList().Count(); i++)
			{
				string propertyName = data.GetType().GetProperties().ToList()[i].Name;
				var propertyValue = data.GetType().GetProperty(propertyName).GetValue(data, null);
				if (propertyName == "preg_guides")
				{
					result += @"""" + propertyName + @""":[";
					GuidesDao guidesdao = new GuidesDao();
					preg_guides item = new preg_guides();
					item.page_id = data.id;
					IEnumerable<preg_guides> return_preg_guides = guidesdao.GetItemsByParams(item);
					foreach (var item2 in return_preg_guides)
					{
						result+=guidesdao.resultReturn(item2);
					}
					result+="],";
				}
				else
				{
					result += @"""" + propertyName + @""":""" + propertyValue.ToString() + @""",";
				}
			}
			result += "}";
			return result;
		}
	}
}