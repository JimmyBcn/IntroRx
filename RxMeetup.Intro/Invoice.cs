using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxMeetup.Intro
{
  public class Invoice
  {
    public Invoice()
    {
      ItemPrices = new List<double>();
    }

    public List<double> ItemPrices { get; }

    public double TotalInvoice
    {
      get
      {
        return ItemPrices.Sum();
      }
    }

    // Passive and event-driven programming
    public void AddPriceToInvoice(double price)
    {
      ItemPrices.Add(price);
    }

    // Reactive programming
    //public IDisposable SubscribeToCartItemAdded(Cart cart)
    //{
    //  return cart.GetItemsPriceSequence().Subscribe(
    //    itemPrice =>
    //    {
    //      ItemPrices.Add(itemPrice);
    //    });
    //}
  }
}
