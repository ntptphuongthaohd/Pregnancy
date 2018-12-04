using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyWeightTypeDao
    {
         PregnancyEntity connect = null;
         public MyWeightTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_weight_type> GetListItem()
        {
            return connect.preg_my_weight_types;
        }

        public preg_my_weight_type GetItemByID(int id)
        {
            return connect.preg_my_weight_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_weight_type item)
        {
            connect.preg_my_weight_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_weight_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_weight_type item = GetItemByID(id);
            connect.preg_my_weight_types.Remove(item);
            connect.SaveChanges();
        }

    }
}