using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class GuidesTypeDao
    {
         PregnancyEntity connect = null;
         public GuidesTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_guides_type> GetListItem()
        {
            return connect.preg_guides_types;
        }

        public preg_guides_type GetItemByID(int id)
        {
            return connect.preg_guides_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_guides_type item)
        {
            connect.preg_guides_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_guides_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_guides_type item = GetItemByID(id);
            connect.preg_guides_types.Remove(item);
            connect.SaveChanges();
        }

    }
}