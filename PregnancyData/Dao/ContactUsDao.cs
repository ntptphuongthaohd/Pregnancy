using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class ContactUsDao
    {
         PregnancyEntity connect = null;
         public ContactUsDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_cotact_us> GetListItem()
        {
            return connect.preg_cotact_uss;
        }

        public preg_cotact_us GetItemByID(int id)
        {
            return connect.preg_cotact_uss.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_cotact_us item)
        {
            connect.preg_cotact_uss.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_cotact_us item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_cotact_us item = GetItemByID(id);
            connect.preg_cotact_uss.Remove(item);
            connect.SaveChanges();
        }

    }
}