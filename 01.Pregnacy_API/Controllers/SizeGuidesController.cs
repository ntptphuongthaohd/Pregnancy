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

	public class SizeGuidesController : ApiController
	{
		SizeGuideDao dao = new SizeGuideDao();
		// GET api/values
		public IEnumerable<preg_size_guide> Get()
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
		public preg_size_guide Get(int id)
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
		public void Post([FromBody]preg_size_guide size_guide)
		{
			try
			{
				dao.InsertData(size_guide);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_size_guide sizeGuideUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_size_guide size_guide = new preg_size_guide();
				size_guide = dao.GetItemByID(id);
				size_guide.image = sizeGuideUpdate.image;
				size_guide.title = sizeGuideUpdate.title;
				size_guide.description = sizeGuideUpdate.description;
				dao.UpdateData(size_guide);
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
