using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class TimeFrameDao
    {
         PregnancyEntity connect = null;
         public TimeFrameDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_time_frame> GetListItem()
        {
            return connect.preg_time_frames;
        }

        public preg_time_frame GetItemByID(int id)
        {
            return connect.preg_time_frames.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_time_frame item)
        {
            connect.preg_time_frames.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_time_frame item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_time_frame item = GetItemByID(id);
            connect.preg_time_frames.Remove(item);
            connect.SaveChanges();
        }

    }
}