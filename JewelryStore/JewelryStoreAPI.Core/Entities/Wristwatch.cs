using System;
using System.Collections.Generic;
using System.Text;

namespace JewelryStoreAPI.Core.Entities
{
    public class Wristwatch
    {
        public Wristwatch()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public string Country { get; set; }
        public decimal Cost { get; set; }
        public int Amount { get; set; }

        public int DiameterMM { get; set; }

        public Colors CaseColor { get; set; }
        public Colors DialColor { get; set; }
        public Colors StrapColor { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }

    public enum Colors
    {
        Black,
        White,
        Red,
        Blue,
        Yellow,
        Steel
    }
}
