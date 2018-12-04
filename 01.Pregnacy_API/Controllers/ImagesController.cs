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

	public class ImagesController : ApiController
	{
		ImageDao dao = new ImageDao();
		// GET api/values
		public IEnumerable<preg_image> Get()
		{
			try
			{
				return dao.GetListItem();
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		// GET api/values/5
		public preg_image Get(int id)
		{
			try
			{
				return dao.GetItemByID(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// POST api/values
		public void Post([FromBody]preg_image image)
		{
			try
			{
				//Image.password = MD5Hash(user.password);
				dao.InsertData(image);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_image imageUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_image image = new preg_image();
				image = dao.GetItemByID(id);
				image.image = imageUpdate.image;
				image.image_type_id = imageUpdate.image_type_id;
				image.week_id = imageUpdate.week_id;
				dao.UpdateData(image);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// DELETE api/values/5
		public void Delete(int id)
		{
			//lstStrings[id] = value;
			try
			{
				dao.DeleteData(id);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
