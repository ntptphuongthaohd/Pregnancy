using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyWeightDao
    {
         PregnancyEntity connect = null;
         public MyWeightDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_weight> GetListItem()
        {
            return connect.preg_my_weights;
        }

        public preg_my_weight GetItemByID(int id)
        {
            return connect.preg_my_weights.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_weight item)
        {
            connect.preg_my_weights.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_weight item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_weight item = GetItemByID(id);
            connect.preg_my_weights.Remove(item);
            connect.SaveChanges();
        }

    }
}