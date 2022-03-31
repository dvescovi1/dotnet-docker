namespace URPIfan.Logic
{
    public interface ITemperatureProvider
    {
        (double,string) GetTemperature();

        bool IsPlatformSupported();
    }
}