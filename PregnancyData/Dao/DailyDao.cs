using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class DailyDao
    {
         PregnancyEntity connect = null;
         public DailyDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_daily> GetListItem()
        {
            return connect.preg_dailys;
        }

        public preg_daily GetItemByID(int id)
        {
            return connect.preg_dailys.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_daily item)
        {
            connect.preg_dailys.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_daily item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_daily item = GetItemByID(id);
            connect.preg_dailys.Remove(item);
            connect.SaveChanges();
        }

    }
}