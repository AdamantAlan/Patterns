using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    /// <summary>
    /// Поставщик уведомлений
    /// </summary>
    interface IStock: IObservable
    {
        void Market();
    }
    class Stock:IStock
    {
        StockInfo info;
        List<IObserver> observers;
        public Stock()
        {
            info = new StockInfo();
            observers = new List<IObserver>();
        }

        public void AddObserver(IObserver observer) => observers.Add(observer);
        public void RemoveObserver(IObserver observer) => observers.Remove(observer);

        public void Notify() 
        {
            foreach (var o in observers)
                o.Update(info);

        }
        public void Market()
        {
            Random rnd = new Random();
            info.USD = rnd.Next(20, 40);
            info.Euro = rnd.Next(30, 50);
            Notify();
        }
    }
    /// <summary>
    /// Будем за ним наблюдать
    /// </summary>
     class StockInfo
    {
        public int USD { get; set; }
        public int Euro { get; set; }
    }
    /// <summary>
    /// Наблюдатель - брокер
    /// </summary>
    interface IBroker:IObserver
    {
        string Name { get; set; }
        void StopTrade();
    }
    class Broker : IBroker
    {
        public string Name { get; set; }
        IObservable stock;
        public Broker(string name, IObservable stock)
        {
            this.Name = name;
            this.stock = stock;
            stock.AddObserver(this);
        }

        public void Update(object ob)
        {
            StockInfo info = ob as StockInfo;
            if (info.USD > 30)
                Console.WriteLine("Брокер {0} продает доллары;  Курс доллара: {1}", this.Name, info.USD);
            else
                Console.WriteLine("Брокер {0} покупает доллары;  Курс доллара: {1}", this.Name, info.USD);
        }
        
        public void StopTrade()
        {
            stock.RemoveObserver(this);
            stock = null;
        }
    }
    /// <summary>
    /// Наблюдатель - банк
    /// </summary>
    interface IBank :IObserver
    {
        string Name { get; set; }
    }
    class Bank : IBank
    {
        public string Name { get; set; }
        IObservable stock;
        public Bank(string name, IObservable obs)
        {
            this.Name = name;
            stock = obs;
            stock.AddObserver(this);
        }
        public void Update(object ob)
        {
            StockInfo sInfo = (StockInfo)ob;

            if (sInfo.Euro > 40)
                Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
            else
                Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        }
    }
}
