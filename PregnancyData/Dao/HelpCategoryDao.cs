using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class HelpCategoryDao
    {
         PregnancyEntity connect = null;
         public HelpCategoryDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_help_category> GetListItem()
        {
            return connect.preg_help_categorys;
        }

        public preg_help_category GetItemByID(int id)
        {
            return connect.preg_help_categorys.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_help_category item)
        {
            connect.preg_help_categorys.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_help_category item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_help_category item = GetItemByID(id);
            connect.preg_help_categorys.Remove(item);
            connect.SaveChanges();
        }

    }
}