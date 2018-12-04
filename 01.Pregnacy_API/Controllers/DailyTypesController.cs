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
    public class DailyTypesController : ApiController
    {
        DailyTypeDao dao = new DailyTypeDao();
        // GET api/values
        public IEnumerable<preg_daily_type> Get()
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
        public preg_daily_type Get(int id)
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
        public void Post([FromBody]preg_daily_type daily_type)
        {
            try
            {
                dao.InsertData(daily_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_daily_type daily_typeUpdate)
        {

            try
            {
                preg_daily_type daily_type = new preg_daily_type();
                daily_type = dao.GetItemByID(id);
                daily_type.preg_daily = daily_typeUpdate.preg_daily;
                daily_type.type = daily_typeUpdate.type;

                dao.UpdateData(daily_type);
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