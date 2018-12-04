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
    public class AuthsController : ApiController
    {
        AuthDao dao = new AuthDao();
        // GET api/values
        public IEnumerable<preg_auth> Get()
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
        public preg_auth Get(int id)
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
        public void Post([FromBody]preg_auth auth)
        {
            try
            {
                dao.InsertData(auth);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_auth authUpdate)
        {

            try
            {
				preg_auth auth = new preg_auth();
                auth = dao.GetItemByID(id);
                auth.user_id = authUpdate.user_id;
                auth.token = authUpdate.token;
                auth.valid_to = authUpdate.valid_to;


                dao.UpdateData(auth);
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