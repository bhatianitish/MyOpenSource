using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tweetinvi;


namespace restFullData
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<TwitterModel> GetTweets(string twitterHashTag);


    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class TwitterModel
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Content { get; set; }
        [DataMember]
        public string AuthorName { get; set; }
        [DataMember]
        public string AuthorUrl { get; set; }
        [DataMember]
        public string ProfileImage { get; set; }
        [DataMember]
        public DateTime? Published { get; set; }
        [DataMember]
        public string screen_name { get; set; }
    }

}
