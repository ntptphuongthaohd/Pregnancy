using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class AnswerDao
    {  
        PregnancyEntity connect = null;
        public AnswerDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_answer> GetListItem()
        {
            return connect.preg_answers;
        }

        public preg_answer GetItemByID(int id)
        {
            return connect.preg_answers.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_answer item)
        {
            connect.preg_answers.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_answer item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
            preg_answer item = GetItemByID(id);
            connect.preg_answers.Remove(item);
            connect.SaveChanges();
        }

    }
}