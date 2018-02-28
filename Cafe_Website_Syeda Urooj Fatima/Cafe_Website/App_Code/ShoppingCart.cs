using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ShoppingCart
/// </summary>
public class ShoppingCart
{
    private List<CartItem> cartItems { get; set; }
    public static ShoppingCart cart;
    
    static ShoppingCart()
    {
        //
        // TODO: Add constructor logic here
        //
        if (HttpContext.Current.Session["ShoppingCart"] == null)
        {
            cart = new ShoppingCart();
            cart.cartItems = new List<CartItem>();
            HttpContext.Current.Session["ShoppingCart"] = cart;
        }
        else
        {
            cart = (ShoppingCart)HttpContext.Current.Session["ShoppingCart"];
        }
    }

    public void addItem(string product, int quantity, int rate)
    {
        foreach (CartItem cartItem in cartItems)
            if (cartItem.Item1 == product)
            {
                cartItem.Item2 += quantity;
                return;
            }
        cartItems.Add(new CartItem(product, quantity, rate));
    }

    public void removeItem(string product, int quantity, int rate)
    {
        //cartItems.Remove(new CartItem(product, quantity, rate));
        cartItems.RemoveAll(item => item.Item1==product);
    }

    public void updateItem(string product, int quantity)
    {
        foreach (CartItem cartItem in cartItems)
            if (cartItem.Item1 == product)
            {
                cartItem.Item2 = quantity;
                return;
            }
    }

    public List<CartItem> getCart()
    {
        return cartItems;
    }

    public int getQuantity(string product_id)
    {
        foreach (CartItem cartItem in cartItems)
            if (cartItem.Item1 == product_id)
            {
                return cartItem.Item2;
            }
        return 0;
    }

    public int getRate(string product_id)
    {
        foreach (CartItem cartItem in cartItems)
            if (cartItem.Item1 == product_id)
            {
                return cartItem.Item3;
            }
        return 0;
    }
}