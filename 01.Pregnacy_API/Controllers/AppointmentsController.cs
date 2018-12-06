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
using System.Security.Cryptography;
using PregnancyData.Dao;

namespace _01.Pregnacy_API.Controllers
{

	public class AppointmentsController : ApiController
	{
		AppointmentDao dao = new AppointmentDao();
		// GET api/values
		[HttpGet]
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_appointment> data = dao.GetListItem();
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
		[HttpGet]
		public HttpResponseMessage Get(string id)
		{
			try
			{
				preg_appointment data = dao.GetItemByID(Convert.ToInt32(id));
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
		[HttpPost]
		public HttpResponseMessage Post([FromBody]preg_appointment data)
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
		[HttpPut]
		public HttpResponseMessage Put(string id, [FromBody]preg_appointment dataUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				if (dataUpdate != null)
				{
					preg_appointment appointment = new preg_appointment();
					appointment = dao.GetItemByID(Convert.ToInt32(id));
					appointment.name = dataUpdate.name;
					appointment.profession_id = dataUpdate.profession_id;
					appointment.appointment_type_id = dataUpdate.appointment_type_id;
					appointment.appointment_date = dataUpdate.appointment_date;
					appointment.appointment_time = dataUpdate.appointment_time;
					appointment.my_weight_type_id = dataUpdate.my_weight_type_id;
					appointment.weight_in_st = dataUpdate.weight_in_st;
					appointment.appointment_bp_dia_id = dataUpdate.appointment_bp_dia_id;
					appointment.appointment_bp_sys_id = dataUpdate.appointment_bp_sys_id;
					appointment.appointment_baby_heart_id = dataUpdate.appointment_baby_heart_id;
					appointment.sync_to_heart = dataUpdate.sync_to_heart;
					appointment.note = dataUpdate.note;
					appointment.user_id = dataUpdate.user_id;
					dao.UpdateData(appointment);
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
		[HttpDelete]
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