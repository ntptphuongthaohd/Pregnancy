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
	public class ContactUssController : ApiController
	{
		ContactUsDao dao = new ContactUsDao();
		// GET api/values
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_cotact_us> data = dao.GetListItem();
				if (data.Count() > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, data);
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

		// GET api/values/5
		public HttpResponseMessage Get(int id)
		{
			try
			{
				preg_cotact_us data = dao.GetItemByID(id);
				if (data != null)
				{
					return Request.CreateResponse(HttpStatusCode.OK, data);
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

		// POST api/values
		public HttpResponseMessage Post([FromBody]preg_cotact_us data)
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
					return Request.CreateResponse(HttpStatusCode.BadRequest, SysConst.DATA_EMPTY);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(SysConst.DATA_INSERT_FAIL);
				return Request.CreateResponse(HttpStatusCode.BadRequest, err);
			}
		}


		// PUT api/values/5
		public HttpResponseMessage Put(int id, [FromBody]preg_cotact_us dataUpdate)
		{
			try
			{
				if (dataUpdate != null)
				{
					preg_cotact_us cotact_us = new preg_cotact_us();
					cotact_us = dao.GetItemByID(id);
					cotact_us.user_id = dataUpdate.user_id;
					cotact_us.email = dataUpdate.email;
					cotact_us.message = dataUpdate.message;
					cotact_us.preg_user = dataUpdate.preg_user;
					cotact_us.user_id = dataUpdate.user_id;

					dao.UpdateData(cotact_us);
					return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_UPDATE_SUCCESS);
				}
				else
				{
					return Request.CreateResponse(HttpStatusCode.BadRequest, SysConst.DATA_EMPTY);
				}
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