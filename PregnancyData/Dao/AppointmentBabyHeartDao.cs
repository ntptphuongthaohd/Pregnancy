using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AppointmentBabyHeartDao
    {
         PregnancyEntity connect = null;
         public AppointmentBabyHeartDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_appointment_baby_heart> GetListItem()
        {
            return connect.preg_appointment_baby_hearts;
        }

        public preg_appointment_baby_heart GetItemByID(int id)
        {
            return connect.preg_appointment_baby_hearts.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_appointment_baby_heart item)
        {
            connect.preg_appointment_baby_hearts.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_appointment_baby_heart item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_appointment_baby_heart item = GetItemByID(id);
            connect.preg_appointment_baby_hearts.Remove(item);
            connect.SaveChanges();
        }

    }
}