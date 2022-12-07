using System;
using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ShoppingCart
    {

        public string name { get; set; }
        public int defaultPrice{ get; set; }
        public int quantity { get; set; }
        public int subtotal{ get; set; }
        public Guid id{ get; set; }
        


    }
}
