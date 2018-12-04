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

	public class TimeFramesController : ApiController
	{
		TimeFrameDao dao = new TimeFrameDao();
		// GET api/values
		public IEnumerable<preg_time_frame> Get()
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
		public preg_time_frame Get(int id)
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
		public void Post([FromBody]preg_time_frame time_frame)
		{
			try
			{
				dao.InsertData(time_frame);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_time_frame timeFrameUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_time_frame time_frame = new preg_time_frame();
				time_frame = dao.GetItemByID(id);
				time_frame.frame_title = timeFrameUpdate.frame_title;
				dao.UpdateData(time_frame);
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
