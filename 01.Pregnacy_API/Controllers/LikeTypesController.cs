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
    public class LikeTypesController : ApiController
    {
        LikeTypeDao dao = new LikeTypeDao();
        // GET api/values
        public IEnumerable<preg_like_type> Get()
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
        public preg_like_type Get(int id)
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
        public void Post([FromBody]preg_like_type like_type)
        {
            try
            {
                dao.InsertData(like_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_like_type like_typeUpdate)
        {

            try
            {
                preg_like_type like_type = new preg_like_type();
                like_type = dao.GetItemByID(id);
                like_type.type = like_typeUpdate.type;


                dao.UpdateData(like_type);
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