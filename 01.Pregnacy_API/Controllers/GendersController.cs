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

    public class GendersController : ApiController
    {
        GenderDao dao = new GenderDao();
        // GET api/values
        public IEnumerable<preg_gender> Get()
        {
            try
            {
                return dao.GetListGender();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        // GET api/values/5
        public preg_gender Get(int id)
        {
            try
            {
                return dao.GetGenderByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]preg_gender gender)
        {
           try{
				//gender.password = MD5Hash(user.password);
               dao.InsertData(gender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_gender genderUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_gender gender = new preg_gender();
                gender = dao.GetGenderByID(id);
                gender.gender = genderUpdate.gender;
                dao.UpdateData(gender);
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
