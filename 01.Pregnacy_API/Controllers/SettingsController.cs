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
    public class SettingsController : ApiController
    {
        SettingDao dao = new SettingDao();
        // GET api/values
        public IEnumerable<preg_setting> Get()
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
        public preg_setting Get(int id)
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
        public void Post([FromBody]preg_setting setting)
        {
            try
            {
                dao.InsertData(setting);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_setting settingUpdate)
        {

            try
            {
                preg_setting setting = new preg_setting();
                setting = dao.GetItemByID(id);
                setting.user_id = settingUpdate.user_id;
                setting.length_units = settingUpdate.length_units;
                setting.preg_user = settingUpdate.preg_user;
                setting.reminders = settingUpdate.reminders;
                setting.revoke_consent = settingUpdate.revoke_consent;
                setting.weight_unit = settingUpdate.weight_unit;
                

                dao.UpdateData(setting);
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