using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class PregnancyDao
    {
         PregnancyEntity connect = null;
        public PregnancyDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_pregnancy> GetListItem()
        {
            return connect.preg_pregnancys;
        }

        public preg_pregnancy GetItemByID(int id)
        {
            return connect.preg_pregnancys.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_pregnancy item)
        {
            connect.preg_pregnancys.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_pregnancy item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_pregnancy item = GetItemByID(id);
            connect.preg_pregnancys.Remove(item);
            connect.SaveChanges();
        }

    }
}