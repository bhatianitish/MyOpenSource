using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tweetinvi;
using System.Security.Cryptography;
using System.IO;
using System.Net;
using System.Xml;
using System.Configuration;
using Newtonsoft.Json;
using System.Runtime.Serialization.Json;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Web;
using System.Web.UI.WebControls;

namespace restFullData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {

        public List<TwitterModel> GetTweets(string twitterHashTag)
        {

            List<TwitterModel> lstTweets = new List<TwitterModel>();

            // New Code added for Twitter API 1.1
            if (!string.IsNullOrEmpty(twitterHashTag))
            {
                // Signing  in twitter with private keys. (Not to be used outside this program!!)
                var twitter = new TwitterHelper(ConfigurationManager.AppSettings["OauthConsumerKey"],
                                                                ConfigurationManager.AppSettings["OauthConsumerKeySecret"],
                                                                ConfigurationManager.AppSettings["OauthAccessToken"],
                                                                ConfigurationManager.AppSettings["OauthAccessTokenSecret"]);

                // response from twitter using the TwitterHelper class.
                var response = twitter.GetTweets(twitterHashTag);

                XmlDocument doc = JsonConvert.DeserializeXmlNode(response, "root");
                // Converting the JSON response into XML type document.
                XmlNodeList locationElements1 = doc.SelectNodes("root/statuses");
                foreach (XmlNode node in locationElements1)
                {
                    TwitterModel tmp = new TwitterModel();
                    tmp.Content = node.SelectSingleNode("text").InnerText;
                    tmp.AuthorName = node.SelectSingleNode("user/name").InnerText;
                    tmp.screen_name = node.SelectSingleNode("user/screen_name").InnerText;
                    lstTweets.Add(tmp);

                }
            }
            return lstTweets;
        }
    }
    
}
