namespace PrayerTimeApp
{
    public class PrayerTimesService
    {
        private readonly ApiHelper _apiHelper;
        public PrayerTimesService(ApiHelper apiHelper)
        {
            _apiHelper = apiHelper;
        }

      

        public async Task<string> GetPrayerTimesAsync()
        {
            // Example API URL - replace with your real one
            string url = "https://api.aladhan.com/v1/timingsByAddress/01-01-2025?address=Trafalgar+Square%2C+London%2C+UK&method=3&shafaq=general&tune=5%2C3%2C5%2C7%2C9%2C-1%2C0%2C8%2C-6&timezonestring=UTC&calendarMethod=UAQ";

            return await _apiHelper.GetDataAsync(url);
        }


    }
}
