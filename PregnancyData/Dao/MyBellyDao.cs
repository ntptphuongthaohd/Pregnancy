using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyBellyDao
    {
         PregnancyEntity connect = null;
         public MyBellyDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_belly> GetListItem()
        {
            return connect.preg_my_bellys;
        }

        public preg_my_belly GetItemByID(int id)
        {
            return connect.preg_my_bellys.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_belly item)
        {
            connect.preg_my_bellys.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_belly item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_belly item = GetItemByID(id);
            connect.preg_my_bellys.Remove(item);
            connect.SaveChanges();
        }

    }
}