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

	public class WeeksController : ApiController
	{
		WeekDao dao = new WeekDao();
		// GET api/values
		public IEnumerable<preg_week> Get()
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
		public preg_week Get(int id)
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
		public void Post([FromBody]preg_week week)
		{
			try
			{
				dao.InsertData(week);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_week weekUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_week week = new preg_week();
				week = dao.GetItemByID(id);
				week.length = weekUpdate.length;
				week.weight = weekUpdate.weight;
				week.title = weekUpdate.title;
				week.short_description = weekUpdate.short_description;
				week.description = weekUpdate.description;
				week.daily_relation = weekUpdate.daily_relation;
				dao.UpdateData(week);
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
