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
    public class PregnancyControllers : ApiController
    {
         PregnancyDao dao = new PregnancyDao();
        // GET api/values
        public IEnumerable<preg_pregnancy> Get()
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
        public preg_pregnancy Get(int id)
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
        public void Post([FromBody]preg_pregnancy pregnancy)
        {
           try{
                             dao.InsertData(pregnancy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
      

        // PUT api/values/5
        public void Put(int id, [FromBody]preg_pregnancy pregnancyUpdate)
        {
            
            try
            {
                preg_pregnancy pregnancy = new preg_pregnancy();
                pregnancy = dao.GetItemByID(id);
                pregnancy.user_id = pregnancyUpdate.user_id;
                pregnancy.baby_already_bom = pregnancyUpdate.baby_already_bom;
                pregnancy.baby_gender = pregnancyUpdate.baby_gender;
                pregnancy.date_of_birth = pregnancyUpdate.date_of_birth;
                pregnancy.due_date = pregnancyUpdate.due_date;
                pregnancy.preg_user = pregnancyUpdate.preg_user;
                pregnancy.pregnancy_loss = pregnancyUpdate.pregnancy_loss;
                pregnancy.show_week = pregnancyUpdate.show_week;
                pregnancy.user_id = pregnancyUpdate.user_id;
                 pregnancy.weeks_pregnant = pregnancyUpdate.weeks_pregnant;
               
                dao.UpdateData(pregnancy);
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