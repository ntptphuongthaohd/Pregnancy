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

	public class WeeklyNotesController : ApiController
	{
		WeeklyNoteDao dao = new WeeklyNoteDao();
		// GET api/values
		public IEnumerable<preg_weekly_note> Get()
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
		public preg_weekly_note Get(int id)
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
		public void Post([FromBody]preg_weekly_note weekly_note)
		{
			try
			{
				dao.InsertData(weekly_note);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		// PUT api/values/5
		public void Put(int id, [FromBody]preg_weekly_note weeklyNoteUpdate)
		{
			//lstStrings[id] = value;
			try
			{
				preg_weekly_note weekly_note = new preg_weekly_note();
				weekly_note = dao.GetItemByID(id);
				weekly_note.week_id = weeklyNoteUpdate.week_id;
				weekly_note.user_id = weeklyNoteUpdate.user_id;
				weekly_note.photo = weeklyNoteUpdate.photo;
				weekly_note.note = weeklyNoteUpdate.note;
				dao.UpdateData(weekly_note);
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
