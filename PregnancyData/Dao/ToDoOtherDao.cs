using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class TodoOtherDao
    {
         PregnancyEntity connect = null;
         public TodoOtherDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_todo_other> GetListItem()
        {
            return connect.preg_todo_others;
        }

        public preg_todo_other GetItemByID(int id)
        {
            return connect.preg_todo_others.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_todo_other item)
        {
            connect.preg_todo_others.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_todo_other item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_todo_other item = GetItemByID(id);
            connect.preg_todo_others.Remove(item);
            connect.SaveChanges();
        }

    }
}