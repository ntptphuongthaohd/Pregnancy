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
    public class AnswersController : ApiController
    {
        AnswerDao dao = new AnswerDao();
        // GET api/values
        public IEnumerable<preg_answer> Get()
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
        public preg_answer Get(int id)
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
        public void Post([FromBody]preg_answer pregnancy)
        {
            try
            {
                dao.InsertData(pregnancy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_answer answerUpdate)
        {

            try
            {
                preg_answer answer = new preg_answer();
                answer = dao.GetItemByID(id);
                answer.answerdate = answerUpdate.answerdate;
                answer.content = answerUpdate.content;
                answer.preg_user = answerUpdate.preg_user;
                answer.preg_user1 = answerUpdate.preg_user1;
                answer.preg_user = answerUpdate.preg_user;
                answer.question_id = answerUpdate.question_id;
                answer.title = answerUpdate.title;
                answer.user_id = answerUpdate.user_id;


                dao.UpdateData(answer);
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