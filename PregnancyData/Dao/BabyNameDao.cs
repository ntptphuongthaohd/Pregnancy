using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class BabyNameDao
    {  
        PregnancyEntity connect = null;
        public BabyNameDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_baby_name> GetListItem()
        {
            return connect.preg_baby_names;
        }

        public preg_baby_name GetItemByID(int id)
        {
            return connect.preg_baby_names.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_baby_name item)
        {
            connect.preg_baby_names.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_baby_name item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_baby_name item = GetItemByID(id);
            connect.preg_baby_names.Remove(item);
            connect.SaveChanges();
        }

    }
}