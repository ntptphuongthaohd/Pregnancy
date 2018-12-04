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
	public class AppointmentTypeController : ApiController
	{
		AppointmentTypeDao dao = new AppointmentTypeDao();
		// GET api/values
		public IEnumerable<preg_appointment_type> Get()
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
		public preg_appointment_type Get(int id)
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
		public void Post([FromBody]preg_appointment_type appointment_type)
		{
			try
			{
				dao.InsertData(appointment_type);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_appointment_type appointment_typeUpdate)
		{

			try
			{
				preg_appointment_type appointment_type = new preg_appointment_type();
				appointment_type = dao.GetItemByID(id);
				appointment_type.type = appointment_typeUpdate.type;

				dao.UpdateData(appointment_type);
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