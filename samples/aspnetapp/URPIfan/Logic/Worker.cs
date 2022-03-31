﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace URPIfan.Logic
{
    public class Worker : BackgroundService
    {
        /// <inheritdoc />
        public Worker(RaspiTemperatureController raspiTemperatureController, ITaskCancellationHelper taskCancellationHelper)
        {
            RaspiTemperatureController = raspiTemperatureController;
            TaskCancellationHelper = taskCancellationHelper;
        }

        private RaspiTemperatureController RaspiTemperatureController { get; }

        private ITaskCancellationHelper TaskCancellationHelper { get; }

        /// <inheritdoc />
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            TaskCancellationHelper.SetCancellationToken(stoppingToken);
            await RaspiTemperatureController.StartTemperatureMeasurementAsync();
        }
    }
}