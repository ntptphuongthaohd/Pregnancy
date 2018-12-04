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
	public class AppointmentBabyHeartController : ApiController
	{
		AppointmentBabyHeartDao dao = new AppointmentBabyHeartDao();
		// GET api/values
		public IEnumerable<preg_appointment_baby_heart> Get()
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
		public preg_appointment_baby_heart Get(int id)
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
		public void Post([FromBody]preg_appointment_baby_heart appointment_baby_heart)
		{
			try
			{
				dao.InsertData(appointment_baby_heart);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_appointment_baby_heart appointment_baby_heartUpdate)
		{

			try
			{
				preg_appointment_baby_heart appointment_baby_heart = new preg_appointment_baby_heart();
				appointment_baby_heart = dao.GetItemByID(id);
				appointment_baby_heart.value = appointment_baby_heartUpdate.value;

				dao.UpdateData(appointment_baby_heart);
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