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
    public class UpgradesController : ApiController
    {
        UpgradeDao dao = new UpgradeDao();
        // GET api/values
        public IEnumerable<preg_upgrade> Get()
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
        public preg_upgrade Get(int id)
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
        public void Post([FromBody]preg_upgrade upgrade)
        {
            try
            {
                dao.InsertData(upgrade);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]preg_upgrade upgradeUpdate)
        {

            try
            {
                preg_upgrade upgrade = new preg_upgrade();
                upgrade = dao.GetItemByID(id);
                upgrade.user_id = upgradeUpdate.user_id;
                upgrade.preg_user = upgradeUpdate.preg_user;
                upgrade.user_id = upgradeUpdate.user_id;
                upgrade.version = upgradeUpdate.version;

                dao.UpdateData(upgrade);
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