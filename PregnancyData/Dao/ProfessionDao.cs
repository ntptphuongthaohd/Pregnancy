using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class ProfessionDao
    {
         PregnancyEntity connect = null;
        public ProfessionDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_profession> GetListItem()
        {
            return connect.preg_professions;
        }

        public preg_profession GetItemByID(int id)
        {
            return connect.preg_professions.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_profession item)
        {
            connect.preg_professions.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_profession item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_profession item = GetItemByID(id);
            connect.preg_professions.Remove(item);
            connect.SaveChanges();
        }

    }
}