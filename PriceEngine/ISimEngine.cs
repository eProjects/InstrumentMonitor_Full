using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriceEngine
{
   public interface ISimEngine
    {
        void Subscribe(string symbol);
        void UnSubscribe(string symbol);
        void Start();
        void Stop();
       
    }
}
