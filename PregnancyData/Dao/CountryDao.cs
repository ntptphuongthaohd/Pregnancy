using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class CountryDao
    {
        PregnancyEntity connect = null;
        public CountryDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_country> GetListItem()
        {
            return connect.preg_countrys;
        }

        public preg_country GetItemByID(int id)
        {
            return connect.preg_countrys.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_country item)
        {
            connect.preg_countrys.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_country item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_country country = GetItemByID(id);
            connect.preg_countrys.Remove(country);
            connect.SaveChanges();
        }

    }
}