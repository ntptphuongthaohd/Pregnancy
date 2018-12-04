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
	public class TodosController : ApiController
	{
		TodoDao dao = new TodoDao();
		// GET api/values
		public IEnumerable<preg_todo> Get()
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
		public preg_todo Get(int id)
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
		public void Post([FromBody]preg_todo todo_other)
		{
			try
			{
				dao.InsertData(todo_other);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_todo TodoOtherUpdate)
		{

			try
			{
				preg_todo TodoOther = new preg_todo();
				TodoOther = dao.GetItemByID(id);
				TodoOther.week_id = TodoOtherUpdate.week_id;
				TodoOther.title = TodoOtherUpdate.title;
				TodoOther.user_id = TodoOtherUpdate.user_id;

				dao.UpdateData(TodoOther);
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