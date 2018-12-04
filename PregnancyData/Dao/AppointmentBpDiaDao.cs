using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AppointmentBpDiaDao
    {
         PregnancyEntity connect = null;
         public AppointmentBpDiaDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_appointment_bp_dia> GetListItem()
        {
            return connect.preg_appointment_bp_dias;
        }

        public preg_appointment_bp_dia GetItemByID(int id)
        {
            return connect.preg_appointment_bp_dias.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_appointment_bp_dia item)
        {
            connect.preg_appointment_bp_dias.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_appointment_bp_dia item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_appointment_bp_dia item = GetItemByID(id);
            connect.preg_appointment_bp_dias.Remove(item);
            connect.SaveChanges();
        }

    }
}