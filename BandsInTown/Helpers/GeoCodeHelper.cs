using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;

namespace BandsInTown.Helpers
{
    public class GeoCodeHelper
    {
        public static string GetGeoIp()
        {
            var l = Windows.Networking.Connectivity.NetworkInformation.GetHostNames();
            foreach (var item in l)
            {
                if (item.Type == Windows.Networking.HostNameType.Ipv4 &&
                                (item.IPInformation.NetworkAdapter.IanaInterfaceType == 71 || 
                                 item.IPInformation.NetworkAdapter.IanaInterfaceType == 6))   
                {
                    return item.DisplayName;
                }
            }
            return string.Empty;
        }

        public static async Task<string> GetLocationFromLatLong()
        {
            var geolocator = new Geolocator();
            geolocator.DesiredAccuracyInMeters = 100;
            Geoposition position = await geolocator.GetGeopositionAsync();

            // reverse geocoding
            BasicGeoposition myLocation = new BasicGeoposition
            {
                Longitude = position.Coordinate.Longitude,
                Latitude = position.Coordinate.Latitude
            };

            Geopoint pointToReverseGeocode = new Geopoint(myLocation);

            MapLocationFinderResult result = await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

            foreach (var k in result.Locations)
            {
                return k.Address.Town + "," + GetStateAbbreviation.GetStateByName(k.Address.Region);
            }

            return null;
        }
    }
}
