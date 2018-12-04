using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class SettingDao
    { 
        PregnancyEntity connect = null;
        public SettingDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_setting> GetListItem()
        {
            return connect.preg_settings;
        }

        public preg_setting GetItemByID(int id)
        {
            return connect.preg_settings.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_setting item)
        {
            connect.preg_settings.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_setting item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_setting item = GetItemByID(id);
            connect.preg_settings.Remove(item);
            connect.SaveChanges();
        }

    }
}