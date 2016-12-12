using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxMeetup.Observables
{
  // Essentially this method allows you to specify a delegate 
  // that will be executed anytime a subscription is made.
  // The IObserver<T> that made the subscription will be passed to your delegate 
  // so that you can call the OnNext/OnError/OnCompleted methods as you need.

  // The Create factory method is the preferred way to implement custom observable sequences.

  // The Create method is also preferred over creating custom types that implement the IObservable interface.
  // There really is no need to implement the observer/observable interfaces yourself. Rx tackles the intricacies that you may not think of such as thread safety of notifications and subscriptions.

  // We can create both finite and infinite sequences.

  public class Create_Blocking
  {
    public IObservable<int> GetObservable()
    {
      var sequence = Observable.Create<int>(
        o =>
        {
          // This is what is going to be executed when an observer is subscribed to the observable
          // Remember that it has to return an IDisposable or an Action
          for (int i = 0; i < 100; i++)
          {
            try
            {
              Thread.Sleep(1000); // Your stuff
            }
            catch (Exception ex)
            {
              o.OnError(ex);
            }

            o.OnNext(i);
          }
          o.OnCompleted();

          return Disposable.Create(() => Console.WriteLine("Observer has unsubscribed"));
          //or can return an Action like 
          //return () => Console.WriteLine("Observer has unsubscribed");

        });

      return sequence;
    }
  }
}
