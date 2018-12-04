using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class LikeTypeDao
    {
         PregnancyEntity connect = null;
         public LikeTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_like_type> GetListItem()
        {
            return connect.preg_like_types;
        }

        public preg_like_type GetItemByID(int id)
        {
            return connect.preg_like_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_like_type item)
        {
            connect.preg_like_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_like_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_like_type item = GetItemByID(id);
            connect.preg_like_types.Remove(item);
            connect.SaveChanges();
        }

    }
}