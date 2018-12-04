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
	public class HelpController : ApiController
	{
		HelpDao dao = new HelpDao();
		// GET api/values
		public IEnumerable<preg_help> Get()
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
		public preg_help Get(int id)
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
		public void Post([FromBody]preg_help help)
		{
			try
			{
				dao.InsertData(help);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_help HelpUpdate)
		{

			try
			{
				preg_help Help = new preg_help();
				Help = dao.GetItemByID(id);
				Help.help_category_id = HelpUpdate.help_category_id;
				Help.hingline_image = HelpUpdate.hingline_image;
				Help.description = HelpUpdate.description;

				dao.UpdateData(Help);
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