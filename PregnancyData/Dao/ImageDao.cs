using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class ImageDao
    {
         PregnancyEntity connect = null;
         public ImageDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_image> GetListItem()
        {
            return connect.preg_images;
        }

        public preg_image GetItemByID(int id)
        {
            return connect.preg_images.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_image item)
        {
            connect.preg_images.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_image item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_image item = GetItemByID(id);
            connect.preg_images.Remove(item);
            connect.SaveChanges();
        }

    }
}