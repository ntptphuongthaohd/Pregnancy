using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class GenderDao
    {
        PregnancyEntity connect = null;
        public GenderDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_gender> GetListGender()
        {
            return connect.preg_genders;
        }

        public preg_gender GetGenderByID(int id)
        {
            return connect.preg_genders.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_gender item)
        {
            connect.preg_genders.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_gender item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_gender gender = GetGenderByID(id);
            connect.preg_genders.Remove(gender);
            connect.SaveChanges();
        }

    }
}