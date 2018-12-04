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

    public class MyBellyTypeController : ApiController
    {
        MyBellyTypeDao dao = new MyBellyTypeDao();
        // GET api/values
        public IEnumerable<preg_my_belly_type> Get()
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
        public preg_my_belly_type Get(int id)
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
        public void Post([FromBody]preg_my_belly_type my_belly_type)
        {
           try{
				//MyBellyType.password = MD5Hash(user.password);
               dao.InsertData(my_belly_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_my_belly_type myBellyTypeUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_my_belly_type my_belly_type = new preg_my_belly_type();
                my_belly_type = dao.GetItemByID(id);
                my_belly_type.type = myBellyTypeUpdate.type;
                dao.UpdateData(my_belly_type);
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
