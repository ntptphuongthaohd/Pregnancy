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

    public class MyBellyController : ApiController
    {
        MyBellyDao dao = new MyBellyDao();
        // GET api/values
        public IEnumerable<preg_my_belly> Get()
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
        public preg_my_belly Get(int id)
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
        public void Post([FromBody]preg_my_belly my_belly)
        {
           try{
				//MyBelly.password = MD5Hash(user.password);
               dao.InsertData(my_belly);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_my_belly MyBellyUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_my_belly phone = new preg_my_belly();
                phone = dao.GetItemByID(id);
                phone.image = MyBellyUpdate.image;
                phone.my_belly_type_id = MyBellyUpdate.my_belly_type_id;
                phone.month = MyBellyUpdate.month;	
                phone.user_id = MyBellyUpdate.user_id;	
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
