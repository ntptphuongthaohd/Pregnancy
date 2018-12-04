using PregnancyData.Dao;
using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _01.Pregnacy_API.Controllers
{
	public class AppointmentBpSyssController : ApiController
	{
		AppointmentBpSysDao dao = new AppointmentBpSysDao();
		// GET api/values
		public IEnumerable<preg_appointment_bp_sys> Get()
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
		public preg_appointment_bp_sys Get(int id)
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
		public void Post([FromBody]preg_appointment_bp_sys appointment_bp_sys)
		{
			try
			{
				dao.InsertData(appointment_bp_sys);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_appointment_bp_sys appointment_bp_sysUpdate)
		{

			try
			{
				preg_appointment_bp_sys appointment_bp_sys = new preg_appointment_bp_sys();
				appointment_bp_sys = dao.GetItemByID(id);
				appointment_bp_sys.value = appointment_bp_sysUpdate.value;

				dao.UpdateData(appointment_bp_sys);
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