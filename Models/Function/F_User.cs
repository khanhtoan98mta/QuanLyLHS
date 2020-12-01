using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QLDHS.Models.Entity;
namespace QLDHS.Models.Function
{
    public class F_User
    {
        LUUHS db = new LUUHS();
        public int CheckUser(string user, string pass)
        {
            UserName us = new UserName();
            List<UserName> list_us = new List<UserName>();
            List<UserName> list_username = db.UserNames.ToList();
            list_us = list_username.Where(x => x.UserName1 == user && x.PassWord == pass).ToList();
            if (list_us.Count == 0)
            {
                return -1;
            }
            us = list_us[0];
            return us.ID;
        }
    }
}