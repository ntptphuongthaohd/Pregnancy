﻿using System;
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
using PregnancyData.Dao;

namespace _01.Pregnacy_API.Controllers
{
	public class UserTodoController : ApiController
	{
		UserTodoDao dao = new UserTodoDao();
		// GET api/values
		[Authorize(Roles = "dev, admin")]
		[HttpGet]
		public HttpResponseMessage Get([FromBody]preg_user_todo data)
		{
			try
			{
				if (data != null)
				{
					IEnumerable<preg_user_todo> result = dao.GetItemByParams(data);
					if (result.Count() > 0)
					{
						return Request.CreateResponse(HttpStatusCode.OK, result);
					}
					else
					{
						HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
					}
				}
				else
				{
					IEnumerable<preg_user_todo> result = dao.GetListItem();
					if (result.Count() > 0)
					{
						return Request.CreateResponse(HttpStatusCode.OK, result);
					}
					else
					{
						HttpError err = new HttpError(SysConst.DATA_NOT_FOUND);
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
					}
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
			}
		}

		// GET api/values/5
		[Authorize(Roles = "dev, admin")]
		[HttpGet]
		[Route("api/usertodo/{user_id}")]
		public HttpResponseMessage Get(string user_id)
		{
			try
			{
				IEnumerable<preg_user_todo> data = dao.GetItemByUserID(Convert.ToInt32(user_id));
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
		[Authorize(Roles = "dev, admin")]
		[HttpGet]
		[Route("api/usertodo/{user_id}/{todo_id}")]
		public HttpResponseMessage Get(string user_id, string todo_id)
		{
			try
			{
				preg_user_todo data = dao.GetItemByID(Convert.ToInt32(user_id), Convert.ToInt32(todo_id));
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
		[Authorize(Roles = "dev, admin")]
		[HttpPost]
		public HttpResponseMessage Post([FromBody]preg_user_todo data)
		{
			try
			{
				if (data.user_id != 0 && data.todo_id != 0)
				{
					if (dao.InsertData(data))
					{
						return Request.CreateResponse(HttpStatusCode.Created, SysConst.DATA_INSERT_SUCCESS);
					}
					else
					{
						HttpError err = new HttpError(SysConst.DATA_EXIST);
						return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
					}
				}
				else
				{
					HttpError err = new HttpError(SysConst.DATA_NOT_EMPTY);
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
				}
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
			}
		}

		//// PUT api/values/5
		//[Authorize(Roles = "dev, admin")]
		//[HttpPut]
		//[Route("api/userbabynamecontrollers/{user_id}/{todo_id}")]
		//public HttpResponseMessage Put(string user_id, string todo_id, [FromBody]preg_user_todo dataUpdate)
		//{
		//	//lstStrings[id] = value;
		//	try
		//	{
		//		if (dataUpdate != null)
		//		{
		//			preg_user_todo user = new preg_user_todo();
		//			user = dao.GetItemByID(Convert.ToInt32(user_id), Convert.ToInt32(todo_id));
		//			user.user_id = dataUpdate.user_id;
		//			user.todo_id = dataUpdate.todo_id;

		//			dao.UpdateData(user);
		//			return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_UPDATE_SUCCESS);
		//		}
		//		else
		//		{
		//			HttpError err = new HttpError(SysConst.DATA_NOT_EMPTY);
		//			return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		HttpError err = new HttpError(ex.Message);
		//		return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
		//	}
		//}

		// DELETE api/values/5
		[Authorize(Roles = "dev, admin")]
		[HttpDelete]
		[Route("api/usertodo/{user_id}/{todo_id}")]
		public HttpResponseMessage Delete(string user_id, string todo_id)
		{
			try
			{
				dao.DeleteData(Convert.ToInt32(user_id), Convert.ToInt32(todo_id));
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