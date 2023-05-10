namespace SunriseSunsetAPI.Core.Models
{
    public class SunriseSunsetDTO
    {
        public string Status { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
        public string SolarNoon { get; set; }
        public int DayLength { get; set; }
    }
}
