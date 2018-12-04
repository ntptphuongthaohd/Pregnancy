using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class QuestionDao
    { 
        PregnancyEntity connect = null;
        public QuestionDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_question> GetListItem()
        {
            return connect.preg_questions;
        }

        public preg_question GetItemByID(int id)
        {
            return connect.preg_questions.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_question item)
        {
            connect.preg_questions.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_question item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_question item = GetItemByID(id);
            connect.preg_questions.Remove(item);
            connect.SaveChanges();
        }

    }
}