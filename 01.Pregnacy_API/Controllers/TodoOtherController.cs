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
	public class TodoOtherController : ApiController
	{
		TodoOtherDao dao = new TodoOtherDao();
		// GET api/values
		public IEnumerable<preg_todo_other> Get()
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
		public preg_todo_other Get(int id)
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
		public void Post([FromBody]preg_todo_other todo_other)
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
		public void Put(int id, [FromBody]preg_todo_other TodoOtherUpdate)
		{

			try
			{
				preg_todo_other TodoOther = new preg_todo_other();
				TodoOther = dao.GetItemByID(id);
				TodoOther.title = TodoOtherUpdate.title;
				TodoOther.content = TodoOtherUpdate.content;
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