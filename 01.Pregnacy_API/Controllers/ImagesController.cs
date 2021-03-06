﻿using PregnancyData.Dao;
using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace _01.Pregnacy_API.Controllers
{

	public class ImagesController : ApiController
	{
		ImageDao dao = new ImageDao();
		// GET api/values
		[Authorize]
		public HttpResponseMessage Get([FromUri]preg_image data)
		{
			try
			{
				IEnumerable<preg_image> result;
				if (!data.DeepEquals(new preg_image()))
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
		[Route("api/images/{week}/{image_type_id}")]
		public HttpResponseMessage Get(string week, string image_type_id)
		{
			try
			{
				preg_image data = dao.GetItemsByParams(new preg_image() { week_id = Convert.ToInt32(week), image_type_id = Convert.ToInt32(image_type_id) }).FirstOrDefault();
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
		public HttpResponseMessage Post([FromBody]preg_image data)
		{
			try
			{
				if (!data.DeepEquals(new preg_image()))
				{
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
		[Route("api/images/{week}/{image_type_id}")]
		public HttpResponseMessage Put(string week, string image_type_id, [FromBody]preg_image dataUpdate)
		{
			return UpdateData(week, image_type_id, dataUpdate);
		}

		// DELETE api/values/5
		[Authorize(Roles = "dev, admin")]
		[Route("api/images/{id}")]
		public HttpResponseMessage Delete(string id)
		{
			try
			{
				preg_image image = dao.GetItemByID(Convert.ToInt32(id)).FirstOrDefault();
				if (image == null)
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
				}
				dao.DeleteData(image);
				return Request.CreateResponse(HttpStatusCode.Accepted, SysConst.DATA_DELETE_SUCCESS);
			}
			catch (Exception ex)
			{
				HttpError err = new HttpError(ex.Message);
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, err);
			}
		}

		public HttpResponseMessage UpdateData(string week_id, string image_type_id, preg_image dataUpdate)
		{
			try
			{
				if (!dataUpdate.DeepEquals(new preg_image()))
				{
					preg_image image = new preg_image();
					image = dao.GetItemsByParams(new preg_image() { week_id = Convert.ToInt32(week_id), image_type_id = Convert.ToInt32(image_type_id) }).FirstOrDefault();
					if (image == null)
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
					}
					if (dataUpdate.image_type_id != null)
					{
						image.image_type_id = dataUpdate.image_type_id;
					}
					if (dataUpdate.image != null)
					{
						image.image = dataUpdate.image;
					}
					if (dataUpdate.week_id != null)
					{
						image.week_id = dataUpdate.week_id;
					}

					dao.UpdateData(image);
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

		#region Upload files
		[Authorize]
		[Route("api/images/{week}/{image_type_id}/upload")]
		[HttpPost]
		public async Task<HttpResponseMessage> Upload(string week, string image_type_id)
		{
			// Check data exist
			preg_image checkItem = dao.GetItemsByParams(new preg_image() { week_id = Convert.ToInt32(week), image_type_id = Convert.ToInt32(image_type_id) }).FirstOrDefault();
			if (checkItem == null)
			{
				return Request.CreateErrorResponse(HttpStatusCode.NotFound, SysConst.DATA_NOT_FOUND);
			}
			string dir = "/Files/Images/" + week + "/" + image_type_id;
			string dirRoot = HttpContext.Current.Server.MapPath(dir);
			// Check if request contains multipart/form-data
			if (!Request.Content.IsMimeMultipartContent())
			{
				throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
			}
			// Check if directory folder created
			if (!Directory.Exists(dirRoot))
			{
				Directory.CreateDirectory(dirRoot);
			}
			// Check if image and html filetype
			for (int i = 0; i < HttpContext.Current.Request.Files.Count; i++)
			{
				HttpPostedFile file = HttpContext.Current.Request.Files[i];
				if (!SysConst.imgOnlyExtensions.Any(x => x.Equals(Path.GetExtension(file.FileName.ToLower()), StringComparison.OrdinalIgnoreCase)))
				{
					return Request.CreateErrorResponse(HttpStatusCode.BadRequest, SysConst.INVALID_FILE_TYPE);
				}
				else if (File.Exists(dirRoot + "/" + file.FileName))
				{
					File.Delete(dirRoot + "/" + file.FileName);
				}
			}

			CustomMultipartFormDataStreamProvider provider = new CustomMultipartFormDataStreamProvider(dirRoot);

			List<string> files = new List<string>();

			try
			{
				// Read all contents of multipart message into CustomMultipartFormDataStreamProvider.
				await Request.Content.ReadAsMultipartAsync(provider);

				// Update to database
				preg_image updateRow = new preg_image();
				foreach (MultipartFileData file in provider.FileData)
				{
					string path = dir + "/" + HttpUtility.UrlPathEncode(Path.GetFileName(file.LocalFileName));
					files.Add(path);
					updateRow.image = path;
				}

				UpdateData(week, image_type_id, updateRow);

				return Request.CreateResponse(HttpStatusCode.Created, files);
			}
			catch (System.Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		#endregion
	}
}
