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
    public class PageController : ApiController
    { 
        PageDao dao = new PageDao();
        // GET api/values
        public IEnumerable<preg_page> Get()
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
        public preg_page Get(int id)
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
        public void Post([FromBody]preg_page page)
        {
           try{
                             dao.InsertData(page);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      

        // PUT api/values/5
        public void Put(int id, [FromBody]preg_page pageUpdate)
        {
            
            try
            {
                preg_page page = new preg_page();
                page = dao.GetItemByID(id);
                page.content = pageUpdate.content;
                page.preg_guides = pageUpdate.preg_guides;
                page.title = pageUpdate.title;
              
               
                dao.UpdateData(page);
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
