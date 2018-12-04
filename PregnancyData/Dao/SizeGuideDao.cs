using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class SizeGuideDao
    {
         PregnancyEntity connect = null;
         public SizeGuideDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_size_guide> GetListItem()
        {
            return connect.preg_size_guides;
        }

        public preg_size_guide GetItemByID(int id)
        {
            return connect.preg_size_guides.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_size_guide item)
        {
            connect.preg_size_guides.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_size_guide item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_size_guide item = GetItemByID(id);
            connect.preg_size_guides.Remove(item);
            connect.SaveChanges();
        }

    }
}