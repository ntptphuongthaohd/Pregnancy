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

    public class UsersController : ApiController
    {
        UserDao dao = new UserDao();
        // GET api/values
        public IEnumerable<preg_user> Get()
        {
            try
            {
                return dao.GetListUser();
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        // GET api/values/5
        public preg_user Get(int id)
        {
            try
            {
                return dao.GetUserByID(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // POST api/values
        public void Post([FromBody]preg_user user)
        {
           try{
               user.password = MD5Hash(user.password);
               dao.InsertData(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static string MD5Hash(string input)
        {
            StringBuilder hash = new StringBuilder();
            MD5CryptoServiceProvider md5provider = new MD5CryptoServiceProvider();
            byte[] bytes = md5provider.ComputeHash(new UTF8Encoding().GetBytes(input));

            for (int i = 0; i < bytes.Length; i++)
            {
                hash.Append(bytes[i].ToString("x2"));
            }
            return hash.ToString();
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]preg_user userUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_user user = new preg_user();
                user = dao.GetUserByID(id);
                user.avarta = userUpdate.avarta;
                user.password = MD5Hash(userUpdate.password);
                user.phone = userUpdate.phone;
                user.social_type = userUpdate.social_type;
                user.first_name = userUpdate.first_name;
                user.last_name = userUpdate.last_name;
                user.you_are_the = userUpdate.you_are_the;
                user.location = userUpdate.location;
                user.status = userUpdate.status;
                dao.UpdateData(user);
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
