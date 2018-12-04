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

    public class PhonesController : ApiController
    {
        PhoneDao dao = new PhoneDao();
        // GET api/values
        public IEnumerable<preg_phone> Get()
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
        public preg_phone Get(int id)
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
        public void Post([FromBody]preg_phone phone)
        {
           try{
				//Phone.password = MD5Hash(user.password);
               dao.InsertData(phone);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_phone PhoneUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_phone phone = new preg_phone();
                phone = dao.GetItemByID(id);
                phone.profession_id = PhoneUpdate.profession_id;
                phone.phone_number = PhoneUpdate.phone_number;
                phone.user_id = PhoneUpdate.user_id;	
                dao.UpdateData(phone);
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
