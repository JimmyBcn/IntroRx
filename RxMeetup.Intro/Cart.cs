using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RxMeetup.Intro
{
  public class Cart
  {
    public Cart()
    {
      Items = new ObservableCollection<Item>();

      // Passive Programming
      Invoice = new Invoice();

      // Event-driven Programming (still not reactive, memory leak prompt)
      // Items.CollectionChanged += Items_CollectionChanged;
    }

    // Event-driven Programming
    //private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    //{
    //  if (e.Action == NotifyCollectionChangedAction.Add)
    //  {
    //    var item = (Item)e.NewItems[0];
    //    Invoice.AddPriceToInvoice(item.Price);
    //  }
    //}

    public ObservableCollection<Item> Items { get; }

    public Invoice Invoice { get; }

    // Reactive programming (fire and forget)
    //public IObservable<double> GetItemsPriceSequence()
    //{
    //  return Observable.FromEventPattern<NotifyCollectionChangedEventArgs>(Items, "CollectionChanged")
    //    .Select(i => ((Item)(i.EventArgs.NewItems[0])).Price);
    //}

    public void AddItemToCart(Item item)
    {
      Items.Add(item);

      // Passive Programming (wrong responsabilities and bad separation of concerns)
      Invoice.AddPriceToInvoice(item.Price);
    }
  }
}
