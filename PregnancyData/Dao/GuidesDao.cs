using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class GuidesDao
    {
         PregnancyEntity connect = null;
         public GuidesDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_guides> GetListItem()
        {
            return connect.preg_guidess;
        }

        public preg_guides GetItemByID(int id)
        {
            return connect.preg_guidess.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_guides item)
        {
            connect.preg_guidess.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_guides item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_guides item = GetItemByID(id);
            connect.preg_guidess.Remove(item);
            connect.SaveChanges();
        }

    }
}