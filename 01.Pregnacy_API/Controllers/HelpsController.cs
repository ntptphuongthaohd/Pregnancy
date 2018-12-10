﻿using PregnancyData.Dao;
using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _01.Pregnacy_API.Controllers
{
    public class HelpsController : ApiController
    {
        HelpDao dao = new HelpDao();
        // GET api/values
        [Authorize]
        public HttpResponseMessage Get([FromBody]preg_help data)
        {
            try
            {
                IEnumerable<preg_help> result;
                if (data != null)
                {
                    result = dao.GetItemsByParams(data);

                }
                else
                {
                    result = dao.GetListItem();

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
        public HttpResponseMessage Get(string id)
        {
            try
            {
                preg_help data = dao.GetItemByID(Convert.ToInt32(id));
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
        public HttpResponseMessage Post([FromBody]preg_help data)
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
        [Authorize(Roles = "dev, admin")]
        public HttpResponseMessage Put(string id, [FromBody]preg_help dataUpdate)
        {
            try
            {
                if (dataUpdate != null)
                {
                    preg_help Help = new preg_help();
                    Help = dao.GetItemByID(Convert.ToInt32(id));
                    if (Help == null)
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
                    }
                    Help.help_category_id = dataUpdate.help_category_id;
                    Help.hingline_image = dataUpdate.hingline_image;
                    Help.description = dataUpdate.description;

                    dao.UpdateData(Help);
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
        [Authorize(Roles = "dev, admin")]
        public HttpResponseMessage Delete(string id)
        {
            //lstStrings[id] = value;
            try
            {
                preg_help item = dao.GetItemByID(Convert.ToInt32(id));
                if (item == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
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