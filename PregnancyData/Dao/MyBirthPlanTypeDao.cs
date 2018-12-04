using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class MyBirthPlanTypeDao
    {
         PregnancyEntity connect = null;
        public MyBirthPlanTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_my_birth_plan_type> GetListItem()
        {
            return connect.preg_my_birth_plan_types;
        }

        public preg_my_birth_plan_type GetItemByID(int id)
        {
            return connect.preg_my_birth_plan_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_my_birth_plan_type item)
        {
            connect.preg_my_birth_plan_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_my_birth_plan_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_my_birth_plan_type item = GetItemByID(id);
            connect.preg_my_birth_plan_types.Remove(item);
            connect.SaveChanges();
        }

    }
}