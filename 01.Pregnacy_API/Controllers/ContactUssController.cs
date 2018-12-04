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
    public class ContactUssController : ApiController
    {
        ContactUsDao dao = new ContactUsDao();
        // GET api/values
        public IEnumerable<preg_cotact_us> Get()
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
        public preg_cotact_us Get(int id)
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
        public void Post([FromBody]preg_cotact_us cotact_us)
        {
            try
            {
                dao.InsertData(cotact_us);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_cotact_us cotact_usUpdate)
        {

            try
            {
                preg_cotact_us cotact_us = new preg_cotact_us();
                cotact_us = dao.GetItemByID(id);
                cotact_us.user_id = cotact_usUpdate.user_id;
                cotact_us.email = cotact_usUpdate.email;
                cotact_us.message = cotact_usUpdate.message;
                cotact_us.preg_user = cotact_usUpdate.preg_user;
                cotact_us.user_id = cotact_usUpdate.user_id;
               
              

                dao.UpdateData(cotact_us);
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