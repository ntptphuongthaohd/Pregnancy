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
		#region New Process
		[HttpGet]
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_week> weeks = dao.GetListItem();
				if (weeks.Count() > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, weeks);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
					return Request.CreateResponse(HttpStatusCode.NoContent, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
				return Request.CreateResponse(HttpStatusCode.NoContent, err);
			}
		}
		public HttpResponseMessage Get(int id)
		{
			try
			{
				preg_week weeks = dao.GetItemByID(id);
				if (weeks != null)
				{
					return Request.CreateResponse(HttpStatusCode.OK, weeks);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
					return Request.CreateResponse(HttpStatusCode.NoContent, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
				return Request.CreateResponse(HttpStatusCode.NoContent, err);
			}
		}
		#endregion


		// POST api/values
		public HttpResponseMessage Post([FromBody]preg_week week)
		{
			try
			{
				dao.InsertData(week);
				return Request.CreateResponse(HttpStatusCode.Created, SysConst.DATA_INSERT_SUCCESS);
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(SysConst.DATA_INSERT_FAIL);
				return Request.CreateResponse(HttpStatusCode.BadRequest, err);
			}
		}

		// PUT api/values/5
		public HttpResponseMessage Put(int id, [FromBody]preg_week weekUpdate)
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
				return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_UPDATE_SUCCESS);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, SysConst.DATA_UPDATE_FAIL);
			}
		}

		// DELETE api/values/5
		public HttpResponseMessage Delete(int id)
		{
			//lstStrings[id] = value;
			try
			{
				dao.DeleteData(id);
				return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_DELETE_SUCCESS);
			}
			catch (Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, SysConst.DATA_DELETE_FAIL);
			}
		}
	}
}
