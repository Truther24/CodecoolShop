using Codecool.CodecoolShop.Models;

namespace Codecool.CodecoolShop.Services
{
    public class ShoppingCartService
    {
        public void AddProductToCart(Product product)
        {
            if (DatabaseShoppingCart.shoppingCart.Produtcs.ContainsKey(product))
            {
                DatabaseShoppingCart.shoppingCart.Produtcs[product] += 1;
            }
            else
            {
            DatabaseShoppingCart.shoppingCart.Produtcs[product] = 1;

            }
        }
    }
}
