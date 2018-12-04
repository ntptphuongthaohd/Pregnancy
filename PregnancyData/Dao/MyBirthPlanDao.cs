using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyBirthPlanDao
    {
         PregnancyEntity connect = null;
        public MyBirthPlanDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_birth_plan> GetListItem()
        {
            return connect.preg_my_birth_plans;
        }

        public preg_my_birth_plan GetItemByID(int id)
        {
            return connect.preg_my_birth_plans.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_birth_plan item)
        {
            connect.preg_my_birth_plans.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_birth_plan item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_birth_plan item = GetItemByID(id);
            connect.preg_my_birth_plans.Remove(item);
            connect.SaveChanges();
        }

    }
}