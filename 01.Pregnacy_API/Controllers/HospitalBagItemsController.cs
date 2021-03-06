﻿using PregnancyData.Dao;
using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace _01.Pregnacy_API.Controllers
{
	public class HospitalBagItemsController : ApiController
	{
		HospitalBagItemDao dao = new HospitalBagItemDao();
		// GET api/values
		[Authorize]
		public HttpResponseMessage Get([FromUri]preg_hospital_bag_item data)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				IEnumerable<preg_hospital_bag_item> result;
				if (!data.DeepEquals(new preg_hospital_bag_item()))
				{
					if (data.custom_item_by_user_id != null)
					{
						data.custom_item_by_user_id = user_id;
					}
					result = dao.GetItemsByParams(data).Where(c => c.custom_item_by_user_id == null || c.custom_item_by_user_id == user_id);
				}
				else
				{
					result = dao.GetListItem().Where(c => c.custom_item_by_user_id == null || c.custom_item_by_user_id == user_id);
				}
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
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, err);
			}
		}

		// GET api/values/5
		[Authorize]
		[Route("api/hospitalbagitems/{id}")]
		public HttpResponseMessage Get(string id)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				preg_hospital_bag_item data = dao.GetItemByID(Convert.ToInt32(id)).Where(c => c.custom_item_by_user_id == null || c.custom_item_by_user_id == user_id).FirstOrDefault();
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
		public HttpResponseMessage Post([FromBody]preg_hospital_bag_item data)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				if (!data.DeepEquals(new preg_hospital_bag_item()))
				{
					if (data.custom_item_by_user_id != null)
					{
						data.custom_item_by_user_id = user_id;
					}
					dao.InsertData(data);
					return Request.CreateResponse(HttpStatusCode.Created, SysConst.DATA_INSERT_SUCCESS);
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

		// PUT api/values/5
		[Authorize(Roles = "dev, admin")]
		[Route("api/hospitalbagitems/{id}")]
		public HttpResponseMessage Put(string id, [FromBody]preg_hospital_bag_item dataUpdate)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				if (!dataUpdate.DeepEquals(new preg_hospital_bag_item()))
				{
					preg_hospital_bag_item HospitalBagItem = new preg_hospital_bag_item();
					HospitalBagItem = dao.GetItemByID(Convert.ToInt32(id)).Where(c => c.custom_item_by_user_id == null || c.custom_item_by_user_id == user_id).FirstOrDefault();
					if (HospitalBagItem == null)
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
					}
					if (dataUpdate.name != null)
					{
						HospitalBagItem.name = dataUpdate.name;
					}
					if (dataUpdate.type != 0)
					{
						HospitalBagItem.type = dataUpdate.type;
					}
					if (dataUpdate.custom_item_by_user_id != null)
					{
						HospitalBagItem.custom_item_by_user_id = user_id;
					}

					dao.UpdateData(HospitalBagItem);
					return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_UPDATE_SUCCESS);
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

		// DELETE api/values/5
		[Authorize(Roles = "dev, admin")]
		[Route("api/hospitalbagitems/{id}")]
		public HttpResponseMessage Delete(string id)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				preg_hospital_bag_item item = dao.GetItemByID(Convert.ToInt32(id)).Where(c => c.custom_item_by_user_id == null || c.custom_item_by_user_id == user_id).FirstOrDefault();
				if (item == null)
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
				}
				dao.DeleteData(item);
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