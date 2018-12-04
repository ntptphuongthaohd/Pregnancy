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
	public class HelpCategoryController : ApiController
	{
		HelpCategoryDao dao = new HelpCategoryDao();
		// GET api/values
		public IEnumerable<preg_help_category> Get()
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
		public preg_help_category Get(int id)
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
		public void Post([FromBody]preg_help_category HelpCategory)
		{
			try
			{
				dao.InsertData(HelpCategory);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_help_category HelpCategoryUpdate)
		{

			try
			{
				preg_help_category HelpCategory = new preg_help_category();
				HelpCategory = dao.GetItemByID(id);
				HelpCategory.name = HelpCategoryUpdate.name;
				HelpCategory.image = HelpCategoryUpdate.image;
				HelpCategory.order = HelpCategoryUpdate.order;

				dao.UpdateData(HelpCategory);
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