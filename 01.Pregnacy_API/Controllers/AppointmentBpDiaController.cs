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
	public class AppointmentBpDiaController : ApiController
	{
		AppointmentBpDiaDao dao = new AppointmentBpDiaDao();
		// GET api/values
		public IEnumerable<preg_appointment_bp_dia> Get()
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
		public preg_appointment_bp_dia Get(int id)
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
		public void Post([FromBody]preg_appointment_bp_dia appointment_bp_dia)
		{
			try
			{
				dao.InsertData(appointment_bp_dia);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_appointment_bp_dia appointment_bp_diaUpdate)
		{

			try
			{
				preg_appointment_bp_dia appointment_bp_dia = new preg_appointment_bp_dia();
				appointment_bp_dia = dao.GetItemByID(id);
				appointment_bp_dia.value = appointment_bp_diaUpdate.value;

				dao.UpdateData(appointment_bp_dia);
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