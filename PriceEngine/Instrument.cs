using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Timers;

namespace PriceEngine
{
    public class Instrument : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private decimal? lastestPrice;
        private decimal? oldPrice;
        private string symbol;
        private decimal? priceChange;
        private readonly Timer timer = new Timer(5000);

        public string Symbol
        {
            get { return symbol; }
            set
            {
                symbol = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Symbol"));
            }
        }

        public decimal? PriceChange
        {
            get { return priceChange; }
            set
            {
                priceChange = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("PriceChange"));
            }
        }

        public decimal? LastestPrice
        {
            get { return lastestPrice; }
            set
            {
                if (lastestPrice != value)
                {
                    // set oldPrice and percentage in difference
                    oldPrice = lastestPrice;
                    lastestPrice = value;
                    if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("LastestPrice"));
                    SetChange();
                }
              
            }
        }

        public decimal? OldPrice
        {
            get { return oldPrice; }
            set
            {
                oldPrice = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("OldPrice"));
  

            }
        }

        public Instrument(string symbol)
        {
            Symbol = symbol;
            LastestPrice = (Decimal?)Math.Round(new Random().NextDouble() * (80 - 0), 2);
            //set price randomly simulating price change
            timer.Elapsed += new ElapsedEventHandler(OnStart);
            timer.Start();
        }

        private void OnStart(object sender, ElapsedEventArgs e)
        {
            Random random = new Random();
            LastestPrice = Math.Round((decimal)(Decimal?)(random.NextDouble() * (80 - 0)),2);
        }

        private void SetChange()
        {
            OldPrice = ((OldPrice==null)? 0 : OldPrice);
            PriceChange = Math.Round((decimal)(LastestPrice - OldPrice), 2);
            
        }

        public void StopWatch()
        {
            if(timer!= null) timer.Stop();
        }

        public void BeginWatch()
        {
            if (timer != null) timer.Start();
        }
    }
}
