using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AppointmentBpSysDao
    {
         PregnancyEntity connect = null;
         public AppointmentBpSysDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_appointment_bp_sys> GetListItem()
        {
            return connect.preg_appointment_bp_syss;
        }

        public preg_appointment_bp_sys GetItemByID(int id)
        {
            return connect.preg_appointment_bp_syss.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_appointment_bp_sys item)
        {
            connect.preg_appointment_bp_syss.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_appointment_bp_sys item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_appointment_bp_sys item = GetItemByID(id);
            connect.preg_appointment_bp_syss.Remove(item);
            connect.SaveChanges();
        }

    }
}