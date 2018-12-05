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
	public class PregnanciesControllers : ApiController
	{
		PregnancyDao dao = new PregnancyDao();
		// GET api/values
		public HttpResponseMessage Get()
		{
			try
			{
				IEnumerable<preg_pregnancy> data = dao.GetListItem();
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
				preg_pregnancy data = dao.GetItemByID(id);
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
		public HttpResponseMessage Post([FromBody]preg_pregnancy data)
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
		public HttpResponseMessage Put(int id, [FromBody]preg_pregnancy dataUpdate)
		{

			try
			{
				if (dataUpdate != null)
				{
					preg_pregnancy pregnancy = new preg_pregnancy();
					pregnancy = dao.GetItemByID(id);
					pregnancy.user_id = dataUpdate.user_id;
					pregnancy.baby_already_bom = dataUpdate.baby_already_bom;
					pregnancy.baby_gender = dataUpdate.baby_gender;
					pregnancy.date_of_birth = dataUpdate.date_of_birth;
					pregnancy.due_date = dataUpdate.due_date;
					pregnancy.preg_user = dataUpdate.preg_user;
					pregnancy.pregnancy_loss = dataUpdate.pregnancy_loss;
					pregnancy.show_week = dataUpdate.show_week;
					pregnancy.user_id = dataUpdate.user_id;
					pregnancy.weeks_pregnant = dataUpdate.weeks_pregnant;

					dao.UpdateData(pregnancy);
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