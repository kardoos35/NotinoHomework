using System.Threading.Tasks;

namespace NotinoHomework.Application.Services.Interfaces
{
    public interface IDataService
    {
        Task<string> GetData(string url);
    }
}
