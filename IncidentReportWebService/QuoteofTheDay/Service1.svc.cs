using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Xml;


namespace TrafficService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public static string PlacesURL1 = "https://maps.googleapis.com/maps/api/geocode/xml?address=";
        public static string PlaceURL2 = "&key=AIzaSyBRgRvd9YrO0gMo4_E3UojUlt95RGFrE_c";
        public static string TrafficURL1 = "http://www.mapquestapi.com/traffic/v2/incidents?key=<YOUR KEY HERE!>&callback=handleIncidentsResponse&boundingBox=";
        //2nd part will be the latitude and longitude
        public static string TrafficURL2 = "&filters=incidents&inFormat=kvp&outFormat=xml";

        public List<TrafficList> GetTrafficUpdates(string cityName)
        {
            string finalURL = PlacesURL1 + cityName + PlaceURL2;
            List<TrafficList> response = new List<TrafficList>();
            List<Object> tmp = GetLatLng(finalURL);

            for (int i = 0; i < tmp.Count; i++)
            {
                response.Add((TrafficList)tmp[i]);
            }

            return response;  
        }

        public static List<Object> GetLatLng(string url)
        {

            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = req.GetResponse() as HttpWebResponse;
            List<Object> list = new List<Object>();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(response.GetResponseStream());
            XmlNodeList locationElements = xmlDoc.SelectNodes("GeocodeResponse/result/geometry");
            LatLongList latlonglist = new LatLongList();
            try
            {
                foreach (XmlNode node in locationElements)
                {

                    latlonglist.lat1 = node.SelectSingleNode("location/lat").InnerText;
                    latlonglist.lng1 = node.SelectSingleNode("location/lng").InnerText;
                    latlonglist.lat2 = node.SelectSingleNode("bounds/southwest/lat").InnerText;
                    latlonglist.lng2 = node.SelectSingleNode("bounds/southwest/lng").InnerText;
                    //list.Add(latlonglist);
                }
            }catch(Exception ex)
            {

            }
            string finalTrafficURL = TrafficURL1 + latlonglist.lat1 + "," + latlonglist.lng1 + "," + latlonglist.lat2 + "," + latlonglist.lng2 + TrafficURL2;
            HttpWebRequest request2 = WebRequest.Create(finalTrafficURL) as HttpWebRequest;
            HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse;
            List<Object> list2 = new List<Object>();
            if (response.StatusCode != HttpStatusCode.OK)
                throw new Exception(String.Format(
                "Server error (HTTP {0}: {1}).",
                response.StatusCode,
                response.StatusDescription));
            XmlDocument TrafficxmlDoc = new XmlDocument();
            TrafficxmlDoc.Load(response2.GetResponseStream());
            XmlNodeList TrafficlocationElements = TrafficxmlDoc.SelectNodes("IncidentsResponse/Incidents/Incident");
            foreach (XmlNode node in TrafficlocationElements)
            {
                TrafficList trafficlist = new TrafficList();
                trafficlist.severity = node.SelectSingleNode("severity").InnerText;
                trafficlist.startTime = node.SelectSingleNode("startTime").InnerText;
                trafficlist.endTime = node.SelectSingleNode("endTime").InnerText;
                trafficlist.shortDesc = node.SelectSingleNode("shortDesc").InnerText;
                trafficlist.fullDesc = node.SelectSingleNode("fullDesc").InnerText;
                list.Add(trafficlist);
            }
            return list;
        }
    }
}
