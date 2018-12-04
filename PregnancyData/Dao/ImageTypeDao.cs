using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class ImageTypeDao
    {
         PregnancyEntity connect = null;
         public ImageTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_image_type> GetListItem()
        {
            return connect.preg_image_types;
        }

        public preg_image_type GetItemByID(int id)
        {
            return connect.preg_image_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_image_type item)
        {
            connect.preg_image_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_image_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_image_type item = GetItemByID(id);
            connect.preg_image_types.Remove(item);
            connect.SaveChanges();
        }

    }
}