using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIIT.Models
{
    public enum Statuscoin
    {
        Active = 1,
        Deactive = 0
    }
    public class Coin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BaseAsset { get; set; }
        public string QuoteAsset { get; set; }
        public double LastPrice { get; set; }
        public double Volumn24h { get; set; }
        public int MarketID { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public Statuscoin Status { get; set; }
    }
}