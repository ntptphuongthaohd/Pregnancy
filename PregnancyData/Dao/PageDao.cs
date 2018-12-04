using PregnancyData.Entity;
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
        }

        public IEnumerable<preg_page> GetListItem()
        {
            return connect.preg_pages;
        }

        public preg_page GetItemByID(int id)
        {
            return connect.preg_pages.Where(c => c.id == id).FirstOrDefault();
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

    }
}