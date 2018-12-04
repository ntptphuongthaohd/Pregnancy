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

	public class TimeLineController : ApiController
	{
		TimeLineDao dao = new TimeLineDao();
		// GET api/values
		public IEnumerable<preg_time_line> Get()
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
		public preg_time_line Get(int id)
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
		public void Post([FromBody]preg_time_line my_time_line)
		{
			try
			{
				dao.InsertData(my_time_line);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_time_line timeLineUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_time_line time_line = new preg_time_line();
				time_line = dao.GetItemByID(id);
				time_line.week_id = timeLineUpdate.week_id;
				time_line.title = timeLineUpdate.title;
				time_line.image = timeLineUpdate.image;
				time_line.position = timeLineUpdate.position;
				time_line.time_line_id = timeLineUpdate.time_line_id;
				dao.UpdateData(time_line);
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
