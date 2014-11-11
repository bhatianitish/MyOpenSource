using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TrafficService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        List<TrafficList> GetTrafficUpdates(string cityName);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class LatLongList
    {
        [DataMember]
        public string lat1 { get; set; }
        [DataMember]
        public string lng1 { get; set; }
        [DataMember]
        public string lat2 { get; set; }
        [DataMember]
        public string lng2 { get; set; }
    }
    [DataContract]
    public class TrafficList
    {
        [DataMember]
        public string severity { get; set; }
        [DataMember]
        public string startTime { get; set; }
        [DataMember]
        public string endTime { get; set; }
        [DataMember]
        public string shortDesc { get; set; }
        [DataMember]
        public string fullDesc { get; set; }
    }
}
