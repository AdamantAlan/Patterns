using Observer.Exempal;
using System;
using System.Threading;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Пример любезно взят с metanit
            //while (true)
            //{
            //    IStock stock = new Stock();
            //    IBank bank = new Bank("СБЕР", stock);
            //    IBroker broker = new Broker("Smart millioner", stock);
            //    stock.Market();
            //    Thread.Sleep(1700);
            //}

            // Пример любезно взят с MSDN
            ILocationTracker provider = new LocationTracker();
            ILocationReporter reporter1 = new LocationReporter("FixedGPS");
            reporter1.Subscribe(provider);
            ILocationReporter reporter2 = new LocationReporter("MobileGPS");
            reporter2.Subscribe(provider);
            provider.TrackLocation(new Location(47.6456, -122.1312));
            reporter1.Unsubscribe();
            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.TrackLocation(null);
            provider.TrackLocation(new Location(47.6677, -122.1199));
            provider.EndTransmission();
            
            //Доделать как будет время - придумать что-нибудь свое...
        }
    }
}
