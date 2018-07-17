using Facs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pwWeb
{
    public partial class WebFormGuest : System.Web.UI.Page
    {
        Facs.Models.UtenteGuest x = new Facs.Models.UtenteGuest();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                x = facUsers.GetCamera(Guid.Parse(Cache["UserId"].ToString()));
                pianoNumber.InnerText = x.Piano.ToString();
                cameraNumber.InnerText = x.Stanza.ToString();

                if (x.Temperatura > 30)
                {
                    x.Temperatura = 30;
                    facUsers.SetTemperatura(x);
                }
                else if (x.Temperatura < 10)
                {
                    x.Temperatura = 10;
                    facUsers.SetTemperatura(x);
                }

                tempControl.Value = x.Temperatura.ToString();

                if (x.StatoPorta)
                {
                    btnOpen.Visible = false;
                    btnClose.Visible = true;
                }
                else
                {
                    btnOpen.Visible = true;
                    btnClose.Visible = false;
                }

            }
        }

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            x.StatoPorta = true;
            btnOpen.Visible = false;
            btnClose.Visible = true;
            facUsers.SetPortaCamera(x);

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            x.StatoPorta = false;
            btnOpen.Visible = true;
            btnClose.Visible = false;
            facUsers.SetPortaCamera(x);
        }

        protected void btnTemperatura_Click(object sender, EventArgs e)
        {

            x.Temperatura = decimal.Parse(tempControl.Value);

            if (x.Temperatura > 30)
            {
                x.Temperatura = 30;

            }
            else if (x.Temperatura < 10)
            {
                x.Temperatura = 10;

            }

            facUsers.SetTemperatura(x);
            tempControl.Value = x.Temperatura.ToString();


        }
    }
}