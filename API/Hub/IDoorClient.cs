using System.Threading.Tasks;

using API.Models;

namespace API.Hub
{
    public interface IDoorClient
    {
        Task Added(Door door);
        Task Deleted(Door door);
        Task Edited(Door door);
    }
}