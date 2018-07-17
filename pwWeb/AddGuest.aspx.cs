using Facs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pwWeb
{
    public partial class AddGuest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                downCaemra.DataSource = facUsers.GetRoom();
                downCaemra.DataValueField = "Camera";
                downCaemra.DataTextField = "Camera";
                downCaemra.DataBind();


            }
        }

        protected void downCamera_SelectedIndexChanged(object sender, EventArgs e)
        {

            //var x = downCaemra.SelectedValue;
            //DataSet ds = facUsers.GetRoom(x[1]);

        }

        protected void btnSalva_Click(object sender, EventArgs e)
        {
            var username = setNome.Value + DateTime.Now.Day.ToString();
            var pwd = Membership.GeneratePassword(8, 0);

            DateTime dtarrivo = DateTime.Parse(setDataArrivo.Value);
            dtarrivo.AddHours(12);

            DateTime dtpartenza = DateTime.Parse(setDataPartenza.Value);
            dtpartenza.AddHours(12);

            facUsers.AddGuest(int.Parse(downCaemra.SelectedValue), setNome.Value, setCognome.Value, username, pwd, dtarrivo, dtpartenza);
        }
    }
}