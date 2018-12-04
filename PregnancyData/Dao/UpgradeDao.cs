using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class UpgradeDao
    { 
        PregnancyEntity connect = null;
        public UpgradeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_upgrade> GetListItem()
        {
            return connect.preg_upgrades;
        }

        public preg_upgrade GetItemByID(int id)
        {
            return connect.preg_upgrades.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_upgrade item)
        {
            connect.preg_upgrades.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_upgrade item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_upgrade item = GetItemByID(id);
            connect.preg_upgrades.Remove(item);
            connect.SaveChanges();
        }

    }
}