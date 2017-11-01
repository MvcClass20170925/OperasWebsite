using BingMapsRESTToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MyService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public string SayHello(string name)
        {
            return String.Format("Hello {0}", name);
        }

        public string GetLocation(string address)
        {
            string results = String.Empty;

            string key = "AjRSkj6c-Oa0lhoApMZyta1qOzss1RFEgXKFaCfwvXAaKoqzbKMWmiTE9z6-S-Xa";

            string uri = "http://dev.virtualearth.net/REST/v1/Locations?query="
                + address + "&key=" + key;

            var request = new GeocodeRequest
            {
                BingMapsKey = key,
                Query = address
            };

            Response response = Task.Run(() => ServiceManager.GetResponseAsync(request)).Result;

            Location location = response.ResourceSets[0].Resources.FirstOrDefault() as Location;

            if (location != null)
            {
                var coor = location.GeocodePoints.FirstOrDefault().GetCoordinate();

                results = String.Format("Success: {0}:{1}",
                    coor.Latitude,
                    coor.Longitude);
            }
            else
            {
                results = "No Results Found";
            }


            return results;
        }

    }
}
