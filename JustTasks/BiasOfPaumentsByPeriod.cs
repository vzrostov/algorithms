using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class BiasOfPaumentsByPeriod
    {
        class Payment
        {
            public string NameOfWorker { get; set; }
            public DateTime Time { get; set; }
            public int Amount { get; set; }
        }

        class PaymentBias
        {
            public string NameOfWorker { get; set; }
            public int Year { get; set; }
            public int Month { get; set; }
            public int Bias { get; set; }
        }

        internal static void Run()
        {
            List<Payment> list = new List<Payment>()
            {
                new Payment() {NameOfWorker = "W1", Amount = 200, Time = new DateTime(2020, 11, 12) },
                new Payment() {NameOfWorker = "W1", Amount = 100, Time = new DateTime(2020, 11, 12) },
                new Payment() {NameOfWorker = "W1", Amount = 200, Time = new DateTime(2020, 12, 12) },
                new Payment() {NameOfWorker = "W1", Amount = 200, Time = new DateTime(2021, 01, 14) },
                new Payment() {NameOfWorker = "W1", Amount = 200, Time = new DateTime(2021, 01, 14) },
                new Payment() {NameOfWorker = "W1", Amount = 400, Time = new DateTime(2021, 02, 14) },
                new Payment() {NameOfWorker = "W2", Amount = 200, Time = new DateTime(2020, 12, 14) },
                new Payment() {NameOfWorker = "W2", Amount = 300, Time = new DateTime(2020, 12, 16) },
                new Payment() {NameOfWorker = "W2", Amount = 200, Time = new DateTime(2020, 12, 17) },
                new Payment() {NameOfWorker = "W2", Amount = 300, Time = new DateTime(2020, 12, 18) },
            };
            List<PaymentBias> paymentBiases = CalculatePaymentBiases(list);
        }

        private static List<PaymentBias> CalculatePaymentBiases(List<Payment> list)
        {
            var lookup = list.ToLookup(x => new { NameOfWorker = x.NameOfWorker, Year = x.Time.Year, Month = x.Time.Month }, 
                v => v.Amount );
            var sums = lookup.Select(x => new  
            { 
                NameOfWorker = x.Key.NameOfWorker,
                Year = x.Key.Year,
                Month = x.Key.Month,
                Sum = x.Aggregate((q1, q2) => q1 + q2)
            });
            List<PaymentBias> biases = new();
            string wn = string.Empty;
            int prev = 0;
            foreach(var s in sums)
            {
                biases.Add(new PaymentBias()
                {
                    NameOfWorker = s.NameOfWorker,
                    Year = s.Year,
                    Month = s.Month,
                    Bias = (wn == s.NameOfWorker)? s.Sum - prev : 0
                });
                wn = s.NameOfWorker;
                prev = s.Sum;
            }
            return biases.ToList();
        }
    }
}
