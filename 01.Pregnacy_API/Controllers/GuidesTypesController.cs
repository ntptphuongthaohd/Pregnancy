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

	public class GuidesTypesController : ApiController
	{
		GuidesTypeDao dao = new GuidesTypeDao();
		// GET api/values
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_guides_type> data = dao.GetListItem();
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
				preg_guides_type data = dao.GetItemByID(id);
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
		public HttpResponseMessage Post([FromBody]preg_guides_type data)
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
		public HttpResponseMessage Put(int id, [FromBody]preg_guides_type dataUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				if (dataUpdate != null)
				{
					preg_guides_type guides_type = new preg_guides_type();
					guides_type = dao.GetItemByID(id);
					guides_type.type = dataUpdate.type;
					dao.UpdateData(guides_type);
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
