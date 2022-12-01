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


        public void RemoveProductFromCart(Product product)
        {
            if (DatabaseShoppingCart.shoppingCart.Produtcs[product] == 1)
            {
                DatabaseShoppingCart.shoppingCart.Produtcs.Remove(product);
            }
            else 
            {
                DatabaseShoppingCart.shoppingCart.Produtcs[product] -= 1;
            }
        }
    }
}
