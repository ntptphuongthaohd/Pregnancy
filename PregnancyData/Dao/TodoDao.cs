using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class TodoDao
    {
         PregnancyEntity connect = null;
         public TodoDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_todo> GetListItem()
        {
            return connect.preg_todos;
        }

        public preg_todo GetItemByID(int id)
        {
            return connect.preg_todos.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_todo item)
        {
            connect.preg_todos.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_todo item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_todo item = GetItemByID(id);
            connect.preg_todos.Remove(item);
            connect.SaveChanges();
        }

    }
}