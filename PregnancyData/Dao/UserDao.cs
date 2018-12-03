using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class UserDao
    {
        PregnancyEntity connect = null;
        public UserDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_user> GetListUser()
        {
            return connect.preg_users;
        }

        public preg_user GetUserByID(int id)
        {
            return connect.preg_users.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_user item)
        {
            connect.preg_users.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_user item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_user user = GetUserByID(id);
            connect.preg_users.Remove(user);
            connect.SaveChanges();
        }

    }
}