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

    public class GuidesTypesController : ApiController
    {
        GuidesTypeDao dao = new GuidesTypeDao();
        // GET api/values
        public IEnumerable<preg_guides_type> Get()
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
        public preg_guides_type Get(int id)
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
        public void Post([FromBody]preg_guides_type guides_type)
        {
           try{
               dao.InsertData(guides_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      
        // PUT api/values/5
        public void Put(int id, [FromBody]preg_guides_type guidesTypeUpdate)
        {
            //lstStrings[id] = value;
            try
            {
                preg_guides_type guides_type = new preg_guides_type();
                guides_type = dao.GetItemByID(id);
                guides_type.type = guidesTypeUpdate.type;
                dao.UpdateData(guides_type);
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
