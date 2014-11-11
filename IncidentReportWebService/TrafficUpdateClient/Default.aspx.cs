using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TrafficUpdateClient.ServiceReference1;

namespace TrafficUpdateClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (TextBox1.Text.Trim() != "")
                {
                    Label1.Text = "";
                    Service1Client sc = new Service1Client();
                    TrafficList[] trafficlist;
                    trafficlist = sc.GetTrafficUpdates(TextBox1.Text.Trim());
                    for (int i = 0; i < trafficlist.Count(); i++)
                    {
                        Label1.Text = Label1.Text + "<b>Severity:</b> " + trafficlist[i].severity + " <br /><b>startTime: </b>" + trafficlist[i].startTime + "<br />" + "<b>EndTime: </b>" + trafficlist[i].endTime + "<br />" + "<b>Description: </b>" + trafficlist[i].shortDesc + "<br />" + trafficlist[i].fullDesc + "<br /><br />";
                    }
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "No Data Found";
            }
        }
    }
}