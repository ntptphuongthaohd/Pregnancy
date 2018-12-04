using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AppointmentDao
    {
         PregnancyEntity connect = null;
         public AppointmentDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_appointment> GetListItem()
        {
            return connect.preg_appointments;
        }

        public preg_appointment GetItemByID(int id)
        {
            return connect.preg_appointments.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_appointment item)
        {
            connect.preg_appointments.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_appointment item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_appointment item = GetItemByID(id);
            connect.preg_appointments.Remove(item);
            connect.SaveChanges();
        }

    }
}