using PregnancyData.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PregnancyData.Dao
{
    public class WeeklyNoteDao
    {
         PregnancyEntity connect = null;
         public WeeklyNoteDao()
        {
            connect = new PregnancyEntity();
        }

        public IEnumerable<preg_weekly_note> GetListItem()
        {
            return connect.preg_weekly_notes;
        }

        public preg_weekly_note GetItemByID(int id)
        {
            return connect.preg_weekly_notes.Where(c => c.id == id).FirstOrDefault();
        }

        public void InsertData(preg_weekly_note item)
        {
            connect.preg_weekly_notes.Add(item);
            connect.SaveChanges();
        }

        public void UpdateData(preg_weekly_note item)
        {
            connect.SaveChanges();
        }

        public void DeleteData(int id)
        {
			preg_weekly_note item = GetItemByID(id);
            connect.preg_weekly_notes.Remove(item);
            connect.SaveChanges();
        }

    }
}