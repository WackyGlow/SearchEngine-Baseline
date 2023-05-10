namespace SunriseSunsetAPI.Core.Models
{
    public class SunriseSunSetResult
    {
        public Results results { get; set; }

        public string status { get; set; }
    }

    public class Results
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }

        public string solar_noon { get; set; }

        public string day_length { get; set; }

    }
}
