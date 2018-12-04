using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyWeightInStDao
    {
         PregnancyEntity connect = null;
         public MyWeightInStDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_weight_in_st> GetListItem()
        {
            return connect.preg_my_weight_in_sts;
        }

        public preg_my_weight_in_st GetItemByID(int id)
        {
            return connect.preg_my_weight_in_sts.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_weight_in_st item)
        {
            connect.preg_my_weight_in_sts.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_weight_in_st item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_weight_in_st item = GetItemByID(id);
            connect.preg_my_weight_in_sts.Remove(item);
            connect.SaveChanges();
        }

    }
}