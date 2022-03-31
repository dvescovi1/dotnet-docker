﻿using System.Threading;
using System.Threading.Tasks;

namespace URPIfan.Logic
{
    public class TaskHelper : ITaskHelper
    {
        /// <inheritdoc />
        public Task Delay(int millisecondsDelay, CancellationToken cancellationToken)
        {
            return Task.Delay(millisecondsDelay, cancellationToken);
        }
    }
}