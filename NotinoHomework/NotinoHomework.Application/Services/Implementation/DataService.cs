using System.Net.Http;
using System.Threading.Tasks;
using NotinoHomework.Application.Services.Interfaces;

namespace NotinoHomework.Application.Services.Implementation
{
    internal class DataService : IDataService
    {
        public async Task<string> GetData(string url)
        {
            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
