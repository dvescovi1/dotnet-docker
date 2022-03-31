using System.Threading;
using System.Threading.Tasks;

namespace URPIfan.Logic
{
    public interface ITaskHelper
    {
        Task Delay(int millisecondsDelay, CancellationToken cancellationToken);
    }
}