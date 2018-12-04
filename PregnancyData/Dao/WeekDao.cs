using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class WeekDao
    {
         PregnancyEntity connect = null;
         public WeekDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_week> GetListItem()
        {
            return connect.preg_weeks;
        }

        public preg_week GetItemByID(int id)
        {
            return connect.preg_weeks.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_week item)
        {
            connect.preg_weeks.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_week item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_week item = GetItemByID(id);
            connect.preg_weeks.Remove(item);
            connect.SaveChanges();
        }

    }
}