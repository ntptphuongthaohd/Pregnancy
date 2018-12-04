using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class DailyLikeDao
    {  
        PregnancyEntity connect = null;
        public DailyLikeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_daily_like> GetListItem()
        {
            return connect.preg_daily_likes;
        }

        public preg_daily_like GetItemByID(int id)
        {
            return connect.preg_daily_likes.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_daily_like item)
        {
            connect.preg_daily_likes.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_daily_like item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_daily_like item = GetItemByID(id);
            connect.preg_daily_likes.Remove(item);
            connect.SaveChanges();
        }

    }
}