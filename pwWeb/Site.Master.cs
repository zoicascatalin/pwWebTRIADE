using Facs;
using Facs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pwWeb
{
    public partial class SiteMaster : MasterPage
    {
        Users usr = new Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Cache != null && Cache["UserId"] != null)
            {
                if (facUsers.IsLogged(Guid.Parse(Cache["UserId"].ToString())))
                {
                    lnkLogin.Visible = false;
                    lnkLogout.Visible = true;
                    lnkAmministrazione.Visible = true;
                    usr = facUsers.UserExists(Guid.Parse(Cache["UserId"].ToString()));
                    if (usr.Role == 1)
                    {
                        admin.Visible = true;
                        guest.Visible = false;
                    }
                    else
                    {
                        admin.Visible = false;
                        guest.Visible = true;
                    }

                }
                else
                {
                    admin.Visible = false;
                    guest.Visible = false;
                    lnkLogout.Visible = false;
                    lnkLogin.Visible = true;
                }
            }
            else
            {
                lnkLogout.Visible = false;
                admin.Visible = false;
                guest.Visible = false;
                lnkLogin.Visible = true;
            }

        }

        protected void lnkLogout_Click(object sender, EventArgs e)
        {
            facUsers.Logout(Guid.Parse(Cache["UserId"].ToString()));
            Cache.Remove("UserId");
            lnkLogout.Visible = false;
            lnkAmministrazione.Visible = false;
            lnkLogin.Visible = true;
            Response.Redirect("Default.aspx");
        }

    }
}