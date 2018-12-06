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
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_my_birth_plan_type> data = dao.GetListItem();
				if (data.Count() > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, data);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
			}
		}

		// GET api/values/5
		public HttpResponseMessage Get(string id)
		{
			try
			{
				preg_my_birth_plan_type data = dao.GetItemByID(Convert.ToInt32(id));
				if (data != null)
				{
					return Request.CreateResponse(HttpStatusCode.OK, data);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
			}
		}

		// POST api/values
		public HttpResponseMessage Post([FromBody]preg_my_birth_plan_type data)
		{
			try
			{
				if (data != null)
				{
					dao.InsertData(data);
					return Request.CreateResponse(HttpStatusCode.Created, SysConst.DATA_INSERT_SUCCESS);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_EMPTY);
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
			}
		}

		// PUT api/values/5
		public HttpResponseMessage Put(string id, [FromBody]preg_my_birth_plan_type dataUpdate)
		{
			try
			{
				if (dataUpdate != null)
				{
					preg_my_birth_plan_type MyBirthPlanType = new preg_my_birth_plan_type();
					MyBirthPlanType = dao.GetItemByID(Convert.ToInt32(id));
					MyBirthPlanType.type = dataUpdate.type;

					dao.UpdateData(MyBirthPlanType);
					return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_UPDATE_SUCCESS);
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_EMPTY);
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
			}
		}

		// DELETE api/values/5
		public HttpResponseMessage Delete(string id)
		{
			//lstStrings[id] = value;
			try
			{
				dao.DeleteData(Convert.ToInt32(id));
				return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_DELETE_SUCCESS);
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
			}
		}
	}
}