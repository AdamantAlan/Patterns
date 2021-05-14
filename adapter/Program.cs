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
            IWeather weather = new Weather();
            Console.WriteLine($"Погода:{ await weather.GetWeatherAsync()}");
            IWind wind = new Wind();
            Console.WriteLine( $"Ветер:{await wind.GetWindAsync()}");
            Console.WriteLine($"Погода:{await weather.GetWeatherAsync()} Ветер:{await new adapterWindToWeather(wind).GetWeatherAsync()}");
        }

        class adapterWindToWeather:IWeather
        {
            private readonly IWind _wind;
            public adapterWindToWeather(IWind wind) => _wind = wind;

            public async Task<string> GetWeatherAsync() => await  _wind.GetWindAsync();
        }

    }
   
}
