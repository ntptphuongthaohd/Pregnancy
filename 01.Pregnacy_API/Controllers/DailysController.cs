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
    public class DailysController : ApiController
    {
        DailyDao dao = new DailyDao();
        // GET api/values
        public IEnumerable<preg_daily> Get()
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
        public preg_daily Get(int id)
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
        public void Post([FromBody]preg_daily daily)
        {
            try
            {
                dao.InsertData(daily);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_daily dailyUpdate)
        {

            try
            {
                preg_daily daily = new preg_daily();
                daily = dao.GetItemByID(id);
                daily.daily_relation = dailyUpdate.daily_relation;
                daily.daily_type_id = dailyUpdate.daily_type_id;
                daily.description = dailyUpdate.description;
                daily.hingline_image = dailyUpdate.hingline_image;
                daily.preg_daily_like = dailyUpdate.preg_daily_like;
                daily.preg_daily_type = dailyUpdate.preg_daily_type;
                daily.short_description = dailyUpdate.short_description;
                daily.title = dailyUpdate.title;


                dao.UpdateData(daily);
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