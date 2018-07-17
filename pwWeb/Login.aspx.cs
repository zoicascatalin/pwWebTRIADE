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
    public partial class Login : System.Web.UI.Page
    {
        Users usr = new Users();

        protected void Page_Load(object sender, EventArgs e)
        {
            lblWrongData.Style.Add("color", "red");
            btnConfirm.Text = "Conferma";
            lblUsername.Text = "Username";
            lblPassword.Text = "Password";
            chkRemember.Text = "Resta Collegato";
            if (Cache != null && Cache["UserId"] != null)
            {
                usr = facUsers.UserExists(Guid.Parse(Cache["UserId"].ToString()));
                if (usr.ID != Guid.Empty)
                {
                    facUsers.Login(usr.ID);
                    if (usr.Role == 1)
                    {
                        Response.Redirect("WebFormHost.aspx");
                    }
                    else if (usr.Role == 2 && !usr.CheckedOut)
                    {
                        Response.Redirect("WebFormGuest.aspx");
                    }
                }
                else
                {
                    lblWrongData.Text = "Dati Errati o Utente non Esistente!";
                }
            }
        }

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != null && txtPassword.Text != null)
            {
                usr = facUsers.UserExists(txtUsername.Text, txtPassword.Text);
                if (usr.ID != Guid.Empty)
                {
                    facUsers.Login(usr.ID);
                    Cache["UserId"] = usr.ID;
                    if (usr.Role == 1)
                    {
                        Response.Redirect("WebFormHost.aspx");
                    }
                    else if (usr.Role == 2 && !usr.CheckedOut)
                    {
                        Response.Redirect("WebFormGuest.aspx");
                    }
                    else
                    {
                        lblWrongData.Text = "Utente Scaduto";
                    }
                }
                else
                {
                    lblWrongData.Text = "Dati Errati o Utente non Esistente!";
                }
            }
            else
            {
                lblWrongData.Text = "Dati Errati o Utente non Esistente!";
            }


        }
    }
}