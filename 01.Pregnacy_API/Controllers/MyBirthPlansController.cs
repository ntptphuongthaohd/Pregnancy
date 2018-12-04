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

	public class MyBirthPlansController : ApiController
	{
		MyBirthPlanDao dao = new MyBirthPlanDao();
		// GET api/values
		public IEnumerable<preg_my_birth_plan> Get()
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
		public preg_my_birth_plan Get(int id)
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
		public void Post([FromBody]preg_my_birth_plan appointment)
		{
			try
			{
				dao.InsertData(appointment);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_my_birth_plan myBirthPlanUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_my_birth_plan my_birth_plan = new preg_my_birth_plan();
				my_birth_plan = dao.GetItemByID(id);
				my_birth_plan.my_birth_plan_type_id = myBirthPlanUpdate.my_birth_plan_type_id;
				my_birth_plan.user_id = myBirthPlanUpdate.user_id;
				my_birth_plan.icon = myBirthPlanUpdate.icon;
				my_birth_plan.title = myBirthPlanUpdate.title;
				dao.UpdateData(my_birth_plan);
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
