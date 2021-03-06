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
	public class UserMedicalServicePackagesController : ApiController
	{
		UserMedicalServicePackageDao dao = new UserMedicalServicePackageDao();
		// GET api/values
		[Authorize(Roles = "dev, admin")]
		[HttpGet]
		public HttpResponseMessage Get([FromUri]preg_user_medical_service_package data)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				if (!data.DeepEquals(new preg_user_medical_service_package()))
				{
					data.user_id = user_id;
					IEnumerable<preg_user_medical_service_package> result = dao.GetItemByParams(data);
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
					IEnumerable<preg_user_medical_service_package> result = dao.GetListItem().Where(c => c.user_id == user_id);
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
		[Route("api/usermedicalservicepackages/{medical_service_package_id}")]
		public HttpResponseMessage Get(string medical_service_package_id)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				preg_user_medical_service_package data = dao.GetItemByID(user_id, Convert.ToInt32(medical_service_package_id)).FirstOrDefault();
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
		public HttpResponseMessage Post([FromBody]preg_user_medical_service_package data)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				if (data.medical_service_package_id != 0)
				{
					data.user_id = user_id;
					//Check exist
					preg_user_medical_service_package checkExist = dao.GetItemByID(user_id, data.medical_service_package_id).FirstOrDefault();
					if (checkExist != null)
					{
						return Request.CreateErrorResponse(HttpStatusCode.BadRequest, SysConst.DATA_EXIST);
					}
					//Check Medical Service Package
					using (PregnancyEntity connect = new PregnancyEntity())
					{
						preg_medical_service_package checkMedicalPackageExist = connect.preg_medical_service_package.Where(c => c.id == data.medical_service_package_id).FirstOrDefault();
						if (checkMedicalPackageExist == null)
						{
							return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
						}
					}
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

		// DELETE api/values/5
		[Authorize(Roles = "dev, admin")]
		[HttpDelete]
		[Route("api/usermedicalservicepackages/{medical_service_package_id}")]
		public HttpResponseMessage Delete(string medical_service_package_id)
		{
			try
			{
				int user_id = Convert.ToInt32(((ClaimsIdentity)(User.Identity)).FindFirst("id").Value);
				//Check exist
				preg_user_medical_service_package item = dao.GetItemByID(user_id, Convert.ToInt32(medical_service_package_id)).FirstOrDefault();
				if (item == null)
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
				}
				dao.DeleteData(user_id, Convert.ToInt32(medical_service_package_id));
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