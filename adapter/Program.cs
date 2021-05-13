using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


                /////////////////////////////////////////////////////////////////////////////////////
                // Не делал адаптацию под разные дни, может выдать исключение, просто для примера////
                /////////////////////////////////////////////////////////////////////////////////////
                


namespace adapter
{
    class Program
    {

        static async Task Main(string[] args)
        {
            //Driver d = new();
            //d.Travel(new AdapterToTransport(new Horse()));
            //d.Travel(new Auto());
            IWeather w = new Weather();
            Console.WriteLine($"Погода:{ await w.GetWeatherAsync()}");
            IWind ww = new Wind();
            Console.WriteLine( $"Ветер:{await ww.GetWindAsync()}");
            Console.WriteLine($"Погода:{await w.GetWeatherAsync()} Ветер:{await new adapterWindToWeather(ww).GetWeatherAsync()}");
        }

        class adapterWindToWeather:IWeather
        {
            private readonly IWind _wind;
            public adapterWindToWeather(IWind wind) => _wind = wind;

            public async Task<string> GetWeatherAsync() => await  _wind.GetWindAsync();
        }

    }
   
}
