using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.Exempal
{
    /// <summary>
    /// Будем его просматривать 
    /// </summary>
    interface ILocation
    {
        double Latitude { get; }
        double Longitude { get; }
    }
    public struct Location
    {
        double lat, lon;
        public Location(double latitude, double longitude)
        {
            this.lat = latitude;
            this.lon = longitude;
        }

        public double Latitude
        { get { return this.lat; } }

        public double Longitude
        { get { return this.lon; } }
    }

    /// <summary>
    /// Наблюдатель
    /// </summary>
    interface ILocationReporter : IObserver<Location>
    {
        string Name { get; }
        void Subscribe(IObservable<Location> provider);
        void Unsubscribe();
    }

    public class LocationReporter : ILocationReporter
    {
        private IDisposable unsubscriber;
        private string instName;

        public LocationReporter(string name)
        {
            this.instName = name;
        }
        public string Name
        { get { return this.instName; } }
        public void Subscribe(IObservable<Location> provider)
        {
            if (provider != null)
                unsubscriber = provider.Subscribe(this);
        }
        public void OnCompleted()
        {
            Console.WriteLine("The Location Tracker has completed transmitting data to {0}.", this.Name);
            this.Unsubscribe();
        }
        public void OnError(Exception e)
        {
            Console.WriteLine("{0}: The location cannot be determined.", this.Name);
        }

        public void OnNext(Location value)
        {
            Console.WriteLine("{2}: The current location is {0}, {1}", value.Latitude, value.Longitude, this.Name);
        }
        public void Unsubscribe() => unsubscriber.Dispose();
    }

    /// <summary>
    /// Поставщик уведомлений
    /// </summary>
    interface ILocationTracker : IObservable<Location>
    {
        void TrackLocation(Nullable<Location> loc);
        void EndTransmission();
    }

    public class LocationTracker : ILocationTracker
    {
        private List<IObserver<Location>> observers;
        public LocationTracker()
        {
            observers = new List<IObserver<Location>>();
        }
        public IDisposable Subscribe(IObserver<Location> observer)
        {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<Location>> _observers;
            private IObserver<Location> _observer;

            public Unsubscriber(List<IObserver<Location>> observers, IObserver<Location> observer)
            {
                this._observers = observers;
                this._observer = observer;
            }

            public void Dispose()
            {
                if (_observer != null && _observers.Contains(_observer))
                    _observers.Remove(_observer);
            }
        }
        public void TrackLocation(Location? loc)
        {
            foreach (var observer in observers)
            {
                if (!loc.HasValue)
                    observer.OnError(new Exception());
                else
                    observer.OnNext(loc.Value);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in observers.ToArray())
                if (observers.Contains(observer))
                    observer.OnCompleted();

            observers.Clear();
        }
    }
}
