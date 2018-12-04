using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using PregnancyData.Entity;
using System.Text;
using System.Security.Cryptography;
using PregnancyData.Dao;

namespace _01.Pregnacy_API.Controllers
{

    public class AppointmentsController : ApiController
    {
        AppointmentDao dao = new AppointmentDao();
        // GET api/values
        public IEnumerable<preg_appointment> Get()
        {
            try
            {
                return dao.GetListItem();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        // GET api/values/5
        public preg_appointment Get(int id)
        {
            try
            {
                return dao.GetItemByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]preg_appointment appointment)
        {
           try{
				//Appointment.password = MD5Hash(user.password);
               dao.InsertData(appointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_appointment AppointmentUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_appointment appointment = new preg_appointment();
                appointment = dao.GetItemByID(id);
                appointment.name = AppointmentUpdate.name;
                appointment.profession_id = AppointmentUpdate.profession_id;
                appointment.appointment_type_id = AppointmentUpdate.appointment_type_id;	
                appointment.appointment_date = AppointmentUpdate.appointment_date;	
                appointment.appointment_time = AppointmentUpdate.appointment_time;	
                appointment.my_weight_type_id = AppointmentUpdate.my_weight_type_id;	
                appointment.weight_in_st = AppointmentUpdate.weight_in_st;	
                appointment.appointment_bp_dia_id = AppointmentUpdate.appointment_bp_dia_id;	
                appointment.appointment_bp_sys_id = AppointmentUpdate.appointment_bp_sys_id;	
                appointment.appointment_baby_heart_id = AppointmentUpdate.appointment_baby_heart_id;	
                appointment.sync_to_heart = AppointmentUpdate.sync_to_heart;	
                appointment.note = AppointmentUpdate.note;	
                appointment.user_id = AppointmentUpdate.user_id;	
                dao.UpdateData(appointment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            //lstStrings[id] = value;
            try
            {
                dao.DeleteData(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
