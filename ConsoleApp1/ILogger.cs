using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ILogger
    {
        Task<bool> LogInfo(string text);
    }
}