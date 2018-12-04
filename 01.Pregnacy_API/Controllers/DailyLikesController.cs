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
    public class DailyLikesController : ApiController
    {
        DailyLikeDao dao = new DailyLikeDao();
        // GET api/values
        public IEnumerable<preg_daily_like> Get()
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
        public preg_daily_like Get(int id)
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
        public void Post([FromBody]preg_daily_like daily_like)
        {
            try
            {
                dao.InsertData(daily_like);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_daily_like daily_likeUpdate)
        {

            try
            {
                preg_daily_like daily_like = new preg_daily_like();
                daily_like = dao.GetItemByID(id);
                daily_like.user_id = daily_likeUpdate.user_id;
                daily_like.daily_id = daily_likeUpdate.daily_id;
                daily_like.like_type_id = daily_likeUpdate.like_type_id;
                daily_like.preg_daily = daily_likeUpdate.preg_daily;
                daily_like.preg_like_type = daily_likeUpdate.preg_like_type;
                daily_like.preg_user = daily_likeUpdate.preg_user;
                daily_like.user_id = daily_likeUpdate.user_id;
              

                dao.UpdateData(daily_like);
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