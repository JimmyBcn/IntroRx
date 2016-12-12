using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxMeetup.Intro
{
  class Program
  {
    static void Main(string[] args)
    {
      // Passive and event-driven programming
      var myCart = new Cart();
      myCart.AddItemToCart(new Item { Name = "Popcorn", Price = 4 });
      Console.WriteLine("Te cost of your cart is: " + myCart.Invoice.TotalInvoice);

      // Reactive programming
      //var myCart = new Cart();
      //var invoice = new Invoice();
      //invoice.SubscribeToCartItemAdded(myCart);
      //myCart.AddItemToCart(new Item { Name = "Popcorn", Price = 4 });
      //Console.WriteLine("Te cost of your cart is: " + invoice.TotalInvoice);

      Console.ReadKey();
    }
  }
}
