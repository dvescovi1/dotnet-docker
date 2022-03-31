using System.Device.Gpio;
using System.Device.Gpio.Drivers;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace URPIfan.Logic
{
    public class RaspiFanController : IFanController
    {
        static GpioController gpioController = new GpioController(PinNumberingScheme.Logical, new LibGpiodDriver(0));

        public RaspiFanController(ILogger<RaspiFanController> logger, IOptionsMonitor<AppSettings> settings)
        {
            Logger = logger;
            GpioPin = settings.CurrentValue.GpioPin;

            gpioController.OpenPin(GpioPin, PinMode.Input);
            var initialValue = gpioController.Read(GpioPin) == PinValue.High;
            gpioController.ClosePin(GpioPin);
            IsFanRunning = initialValue;
            gpioController.OpenPin(GpioPin, PinMode.Output);

            logger.LogInformation($"Initial value: {initialValue}");
        }

        /// <inheritdoc />
        public bool IsFanRunning { get; private set; }

        private ILogger<RaspiFanController> Logger { get; }

        private int GpioPin { get; }

        /// <inheritdoc />
        public void TurnFanOn()
        {
            gpioController.Write(GpioPin, PinValue.High);
            IsFanRunning = true;

            Logger.LogInformation("Fan turned on");
        }

        /// <inheritdoc />
        public void TurnFanOff()
        {
            gpioController.Write(GpioPin, PinValue.Low);
            IsFanRunning = false;

            Logger.LogInformation("Fan turned off");
        }
    }
}