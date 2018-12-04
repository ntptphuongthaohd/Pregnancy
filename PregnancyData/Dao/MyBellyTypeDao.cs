using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyBellyTypeDao
    {
         PregnancyEntity connect = null;
         public MyBellyTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_belly_type> GetListItem()
        {
            return connect.preg_my_belly_types;
        }

        public preg_my_belly_type GetItemByID(int id)
        {
            return connect.preg_my_belly_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_belly_type item)
        {
            connect.preg_my_belly_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_belly_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_belly_type item = GetItemByID(id);
            connect.preg_my_belly_types.Remove(item);
            connect.SaveChanges();
        }

    }
}