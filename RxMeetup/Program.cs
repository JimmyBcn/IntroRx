using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using RxMeetup.Observables;
using RxMeetup.Observers;
using System.Threading;

namespace RxMeetup
{
  class Program
  {
    // https://jsfiddle.net/JimmyBcn/5j5gy8vw/

    static void Main(string[] args)
    {
      
      // Get the observable sequence
      IObservable<int> observable = new Range().GetObservable();
      //IObservable<int> observable = new Interval().GetObservable();
      //Win Forms Samples
      //IObservable<int> observable = new Combined().GetObservable();
      //IObservable<int> observable = new Create_Blocking().GetObservable();
      //IObservable<int> observable = new Create_NonBlocking().GetObservable();
      //IObservable<int> observable = new Create_Nonblocking_Cancellable().GetObservable();
      
      // Get the observer
      //IObserver<int> observer = new SimpleObserver().GetObserver();
      IObserver<int> observer = new CompleteObserver().GetObserver();

      // Subscribe the observer to the observable
      // The subscription returns an IDisposable object so that we can use the Dispose() method to unsubscribe the observer from the observable.
      IDisposable subscription = observable.Subscribe(observer);

      // Finish
      Console.WriteLine("Press ENTER to unsubscribe...");
      Console.ReadLine();
      subscription.Dispose();
      Console.WriteLine("Press ENTER to finish...");
      Console.ReadLine();
      


      //// HOT AND COLD OBSERVABLES
      //var observable = new HotCold().GetObservable() 
      //// as IConnectableObservable<int>
      //;

      //IObserver<int> firstObserver = new SimpleObserver().GetObserver();
      //IObserver<int> secondObserver = new SimpleObserver().GetObserver();
      //IObserver<int> thirdObserver = new SimpleObserver().GetObserver();

      //IDisposable firstSubscription = observable.DelaySubscription(TimeSpan.FromMilliseconds(500)).Subscribe(firstObserver);
      //IDisposable secondSubscription = observable.DelaySubscription(TimeSpan.FromMilliseconds(1000)).Subscribe(secondObserver);
      //IDisposable thirdSubscription = observable.DelaySubscription(TimeSpan.FromMilliseconds(1500)).Subscribe(thirdObserver);

      ///* 
      //// Cold (not sharing subscription)
      //Console.WriteLine("Press ENTER to unsubscribe...");
      //Console.ReadLine();
      //firstSubscription.Dispose();
      //secondSubscription.Dispose();
      //thirdSubscription.Dispose();      
      // */

      ///* 
      //// Hot observable (sharing subscription)
      //Console.WriteLine("Press ENTER to connect...");
      //Console.ReadLine();
      //observable.Connect();

      //Console.WriteLine("Press ENTER to unsubscribe the first...");
      //Console.ReadLine();
      //firstSubscription.Dispose();

      //Console.WriteLine("Press ENTER to reconnect the first...");
      //Console.ReadLine();
      //IDisposable reFirstSubscription = observable.DelaySubscription(TimeSpan.FromMilliseconds(500)).Subscribe(firstObserver);

      //Console.WriteLine("Press ENTER to unsubscribe the rest...");
      //Console.ReadLine();
      //reFirstSubscription.Dispose();
      //secondSubscription.Dispose();
      //thirdSubscription.Dispose();
      // */


      //// Cold (sharing subscription)
      //Console.WriteLine("Press ENTER to unsubscribe...");
      //Console.ReadLine();
      //firstSubscription.Dispose();
      //secondSubscription.Dispose();
      //thirdSubscription.Dispose();     
      
      //Console.WriteLine("Press ENTER to finish...");
      //Console.ReadLine();


      // Win Forms Samples
      //new Event().Run();
      //new Event2().Run();
      //new Event3().Run();
      //new Event4().Run(); // Only to show scheduling
    }
  }
}

