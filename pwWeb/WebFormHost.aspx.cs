using Facs;
using Facs.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pwWeb
{
    public partial class WebFormHost : System.Web.UI.Page
    {
        int x = 0;
        System.Timers.Timer aTimer = new System.Timers.Timer();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlFloors.DataSource = facUsers.getFloors();
                ddlFloors.DataBind();

            }
        }


        public void rooms(string ddl)
        {
            DataSet ds = facUsers.DSgetRooms(ddl);
            if (ds != null)
            {
                rpt.DataSource = ds;
                rpt.DataBind();
            }
            x = ddlFloors.SelectedIndex;
        }

        protected void ddlFloors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlFloors.SelectedIndex != 0)
            {
                rooms(ddlFloors.SelectedIndex.ToString());
            }
            else
            {
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                var x = ddlFloors.SelectedValue.Split(' ');
                List<UtenteGuest> list = facUsers.getRooms(x[1]);
                Button btnOpen = (Button)e.Item.FindControl("btnOpen");
                Label lblCamera = e.Item.FindControl("lblRoom") as Label;
                var z = btnOpen.ClientID.Split('_');
                if (list[int.Parse(z[3])].StatoPorta)
                {
                    btnOpen.BackColor = Color.Red;
                }
                else
                {
                    btnOpen.BackColor = Color.Green;
                }
                btnOpen.Click += new EventHandler(btnOpen_Click);
                if (list[int.Parse(z[3])].Occupato)
                {
                    lblCamera.ForeColor = Color.Red;
                }
                else
                {
                    lblCamera.ForeColor = Color.Green;
                }

            }
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            var z = btn.ClientID.Split('_');
            var x = ddlFloors.SelectedValue.Split(' ');
            List<UtenteGuest> list = facUsers.getRooms(x[1]);
            facUsers.setPortaCamera(list[int.Parse(z[3])].Stanza, !(list[int.Parse(z[3])].StatoPorta));
            DataSet ds = facUsers.DSgetRooms(x[1]);
            rpt.DataSource = ds;
            rpt.DataBind();
        }

        protected void btnSetTemp_Click(object sender, EventArgs e)
        {
            RepeaterItem item = (sender as Button).NamingContainer as RepeaterItem;
            TextBox txt = item.FindControl("txtTemp") as TextBox;
            Label lblSet = item.FindControl("lblSettato") as Label;
            var z = txt.ClientID.Split('_');
            var x = ddlFloors.SelectedValue.Split(' ');
            List<UtenteGuest> list = facUsers.getRooms(x[1]);
            facUsers.SetTemperatura(list[int.Parse(z[3])].Stanza, decimal.Parse(txt.Text));
            DataSet ds = facUsers.DSgetRooms(x[1]);
            rpt.DataSource = ds;
            rpt.DataBind();
        }
    }
}