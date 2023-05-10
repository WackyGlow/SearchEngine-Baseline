using SunriseSunsetAPI.Core.Models;

namespace SunriseSunsetAPI.Core.Interfaces
{
    public interface ISunriseSunsetAPI
    {
       
            // Property that specifies the base URL of the Sunrise Sunset API
            public string BASE_URL { get; }

            /*
             * Method that makes an HTTP GET request to the Sunrise Sunset API and returns sunrise and sunset
             * information for a given location and date.
             *
             * @param latitude: The latitude of the location for which to retrieve sunrise and sunset information.
             * @param longitude: The longitude of the location for which to retrieve sunrise and sunset information.
             * * @param date: The date for which to retrieve sunrise and sunset information. Must be in YYYY-MM-DD format.
             *
             * @return: A SunriseSunsetDTO object that contains the following information:
             *          -status: A string indicating the status of the API request ("OK" if successful).
             *          -sunrise: A string indicating the time of sunrise at
             *                     the specified location and date(in HH:MM: SS format).
             *          -sunset: A string indicating the time of sunset at the
             *                    specified location and date(in HH:MM: SS format).
             *          -solarNoon: A string indicating the time of solar noon at the
             *                      specified location and date(in HH:MM: SS format).
             *          -dayLength: An integer indicating the length of the day at the
             *                      specified location and date(in seconds).
             *                         *
             * @throws: A SunriseSunsetAPIException if there is an error with the API request.
             **/
            public SunriseSunsetDTO GetSunriseSunsetAsync(string latitude, string longitude, string date);
        

    }
}
