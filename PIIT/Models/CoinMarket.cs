using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PIIT.Models
{
    public enum StatusMarket
    {
        Active =1,
        Deactive =0,
    }
    public class CoinMarket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public StatusMarket Status { get; set; }
    }
}