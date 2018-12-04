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
	public class BabyNamesController : ApiController
	{
		BabyNameDao dao = new BabyNameDao();
		// GET api/values
		public IEnumerable<preg_baby_name> Get()
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
		public preg_baby_name Get(int id)
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
		public void Post([FromBody]preg_baby_name baby_name)
		{
			try
			{
				dao.InsertData(baby_name);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_baby_name baby_nameUpdate)
		{

			try
			{
				preg_baby_name baby_name = new preg_baby_name();
				baby_name = dao.GetItemByID(id);
				baby_name.user_id = baby_nameUpdate.user_id;
				baby_name.preg_country_id = baby_nameUpdate.preg_country_id;
				baby_name.preg_gender_id = baby_nameUpdate.preg_gender_id;
				baby_name.name = baby_nameUpdate.name;

				dao.UpdateData(baby_name);
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