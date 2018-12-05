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

	public class PhonesController : ApiController
	{
		PhoneDao dao = new PhoneDao();
		// GET api/values
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_phone> data = dao.GetListItem();
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
				preg_phone data = dao.GetItemByID(id);
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
		public HttpResponseMessage Post([FromBody]preg_phone data)
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
		public HttpResponseMessage Put(int id, [FromBody]preg_phone dataUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				if (dataUpdate != null)
				{
					preg_phone phone = new preg_phone();
					phone = dao.GetItemByID(id);
					phone.profession_id = dataUpdate.profession_id;
					phone.phone_number = dataUpdate.phone_number;
					phone.user_id = dataUpdate.user_id;
					dao.UpdateData(phone);
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
