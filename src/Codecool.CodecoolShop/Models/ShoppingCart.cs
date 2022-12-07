using System.Collections.Generic;

namespace Codecool.CodecoolShop.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public Dictionary<Product,int> Produtcs { get; set; } = new Dictionary<Product,int>();
    }
}
