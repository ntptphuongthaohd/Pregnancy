using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AppointmentTypeDao
    {
         PregnancyEntity connect = null;
         public AppointmentTypeDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_appointment_type> GetListItem()
        {
            return connect.preg_appointment_types;
        }

        public preg_appointment_type GetItemByID(int id)
        {
            return connect.preg_appointment_types.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_appointment_type item)
        {
            connect.preg_appointment_types.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_appointment_type item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_appointment_type item = GetItemByID(id);
            connect.preg_appointment_types.Remove(item);
            connect.SaveChanges();
        }

    }
}