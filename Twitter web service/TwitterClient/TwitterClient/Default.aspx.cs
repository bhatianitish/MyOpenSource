using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TwitterClient.ServiceReference1;
//using TwitterClient.ServiceReference2;

namespace TwitterClient
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string hashtag = TextBox1.Text.ToString();
            Label1.Text = "";
            ServiceReference1.Service1Client sc=new ServiceReference1.Service1Client();
            TwitterModel[] list;
            list = sc.GetTweets(hashtag);
            
            for (int i = 0; i < list.Count(); i++)
            {
                Label1.Text = Label1.Text + "<b>Tweet: </b> " + list[i].Content + " <br /><b>Name: </b>" + list[i].AuthorName + "<br /><b>Screen Name: " + list[i].screen_name + "<br /><br />";
            }

        }
    }
}