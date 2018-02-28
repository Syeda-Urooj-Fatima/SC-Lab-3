using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CartItem
/// </summary>
public class CartItem
{
    public CartItem(string product, int quantity, int rate)
    {
        //
        // TODO: Add constructor logic here
        //
        Item1 = product;
        Item2 = quantity;
        Item3 = rate;
    }

    public string Item1 { get; set; }
    public int Item2 { get; set; }
    public int Item3 { get; set; }

    public bool Equals(CartItem other)
    {
        if (other == null) return false;
        return (this.Item1.Equals(other.Item1));
    }
}