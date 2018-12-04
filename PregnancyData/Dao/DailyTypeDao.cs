using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class DailyTypeDao
    {
         PregnancyEntity connect = null;
         public DailyTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_daily_type> GetListItem()
        {
            return connect.preg_daily_types;
        }

        public preg_daily_type GetItemByID(int id)
        {
            return connect.preg_daily_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_daily_type item)
        {
            connect.preg_daily_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_daily_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_daily_type item = GetItemByID(id);
            connect.preg_daily_types.Remove(item);
            connect.SaveChanges();
        }

    }
}