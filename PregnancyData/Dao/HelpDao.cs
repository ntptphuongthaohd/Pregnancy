using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class HelpDao
    {
         PregnancyEntity connect = null;
         public HelpDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_help> GetListItem()
        {
            return connect.preg_helps;
        }

        public preg_help GetItemByID(int id)
        {
            return connect.preg_helps.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_help item)
        {
            connect.preg_helps.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_help item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_help item = GetItemByID(id);
            connect.preg_helps.Remove(item);
            connect.SaveChanges();
        }

    }
}