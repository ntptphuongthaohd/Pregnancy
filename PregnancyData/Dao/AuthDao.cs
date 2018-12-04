using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AuthDao
    {
        PregnancyEntity connect = null;
        public AuthDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_auth> GetListItem()
        {
            return connect.preg_auths;
        }

        public preg_auth GetItemByID(int id)
        {
            return connect.preg_auths.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_auth item)
        {
            connect.preg_auths.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_auth item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_auth auth = GetItemByID(id);
            connect.preg_auths.Remove(auth);
            connect.SaveChanges();
        }

    }
}