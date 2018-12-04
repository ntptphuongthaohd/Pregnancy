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
	public class MyBirthPlanTypeController : ApiController
	{
		MyBirthPlanTypeDao dao = new MyBirthPlanTypeDao();
		// GET api/values
		public IEnumerable<preg_my_birth_plan_type> Get()
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
		public preg_my_birth_plan_type Get(int id)
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
		public void Post([FromBody]preg_my_birth_plan_type my_birth_plan_type)
		{
			try
			{
				dao.InsertData(my_birth_plan_type);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_my_birth_plan_type MyBirthPlanTypeUpdate)
		{

			try
			{
				preg_my_birth_plan_type MyBirthPlanType = new preg_my_birth_plan_type();
				MyBirthPlanType = dao.GetItemByID(id);
				MyBirthPlanType.type = MyBirthPlanTypeUpdate.type;

				dao.UpdateData(MyBirthPlanType);
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