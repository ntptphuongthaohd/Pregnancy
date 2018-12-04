using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class PhoneDao
    {
        PregnancyEntity connect = null;
        public PhoneDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_phone> GetListItem()
        {
            return connect.preg_phones;
        }

        public preg_phone GetItemByID(int id)
        {
            return connect.preg_phones.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_phone item)
        {
            connect.preg_phones.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_phone item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_phone Phone = GetItemByID(id);
            connect.preg_phones.Remove(Phone);
            connect.SaveChanges();
        }

    }
}