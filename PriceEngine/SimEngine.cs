using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Threading;

namespace PriceEngine
{
    public class SimEngine : ISimEngine
    {
        public ObservableCollection<Instrument> Instruments { get; private set; }

        public void Subscribe(string symbol)
        {
            if (Instruments == null) Instruments = new ObservableCollection<Instrument>();
            var existingSymbol =  Instruments.Where(u => u.Symbol == symbol).FirstOrDefault();
            if (existingSymbol != null) return;
            // ok add new instrument.
            Instruments.Add(new Instrument(symbol));
        }

        public ObservableCollection<Instrument>  GetSubcribedInstruments()
        {
           // GetInstrument();
            return this.Instruments;
        }


        public void UnSubscribe(string symbol)
        {
            if (Instruments != null)
            {
                var existingSymbol = Instruments.Where(u => u.Symbol == symbol).FirstOrDefault();
                if (existingSymbol == null) return;
                // found, remove instrument.
                Instruments.Remove(existingSymbol);
            }
        }

        public void Start()
        {
            //start getting updates
            if (Instruments != null)
            {
                foreach (var inst in Instruments)
                {
                    inst.BeginWatch();
                }
            }
        }

        public void Stop()
        {
            //stop getting updates
            if (Instruments != null)
            {
                foreach (var inst in Instruments)
                {
                    inst.StopWatch();
                }
            }
        }

        public SimEngine()
        {
            //set defaults
            GenerateDefault();
        }

        private void GenerateDefault()
        {
            Instruments = (Instruments == null) ? new ObservableCollection<Instrument>() : Instruments;
            // load initial instruments, giving 50ms to random generator...
            Instruments.Add(new Instrument("MSFT"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("IBM"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("AAPL"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("DELL"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("AMZN"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("JCP"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("PBR"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("CSCO"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("BAC"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("GTAT"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("INTC"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("PFE"));
            Thread.Sleep(50);
            Instruments.Add(new Instrument("AKS"));
            Thread.Sleep(50);
           
        }
    }
}
