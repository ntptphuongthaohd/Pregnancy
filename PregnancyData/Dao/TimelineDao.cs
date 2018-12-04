using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class TimeLineDao
    {
         PregnancyEntity connect = null;
         public TimeLineDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_time_line> GetListItem()
        {
            return connect.preg_time_lines;
        }

        public preg_time_line GetItemByID(int id)
        {
            return connect.preg_time_lines.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_time_line item)
        {
            connect.preg_time_lines.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_time_line item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_time_line item = GetItemByID(id);
            connect.preg_time_lines.Remove(item);
            connect.SaveChanges();
        }

    }
}