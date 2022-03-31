using System.Threading;

namespace URPIfan.Logic
{
    public interface ITaskCancellationHelper
    {
        bool IsCancellationRequested { get; }

        CancellationToken CancellationToken { get; }

        void SetCancellationToken(CancellationToken cancellationToken);
    }
}