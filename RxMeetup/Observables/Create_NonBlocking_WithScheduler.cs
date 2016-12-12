using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;

namespace RxMeetup.Observables
{
  public class Create_NonBlocking_WithScheduler
  {
    // To effectively provide the level of asynchrony that developers require, some level of concurrency control is required. 
    // Rx provides excellent abstraction that enable concurrency to become declarative and also unit testable

    // Rx is single-threaded by default
    // We can choose to do our work (observe or subscribe) on any thread
    // If we do not introduce any scheduling, our callbacks will be invoked on the same thread that the OnNext/OnError/OnCompleted methods are invoked from.
    // Callbacks modifying the UI must be scheduled on the STA

    // The SubscribeOn operator specifies a different Scheduler on which the Observable should operate. 
    // The ObserveOn operator specifies a different Scheduler that the Observable will use to send notifications (OnNext/OnError/OnCompleted) onto its observers
    // We can use the different schedulers provided by Rx (at System.Reactive.Concurrency)

    // Some operators (like buffer) schedules their job in the ThreadPool by default.
    // https://msdn.microsoft.com/en-us/library/hh242963(v=vs.103).aspx


    public IObservable<int> GetObservable()
    {
      var sequence = Observable.Create<int>(
        o =>
        {
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
        })
        .ObserveOn(System.Reactive.Concurrency.NewThreadScheduler.Default)
        .SubscribeOn(System.Reactive.Concurrency.NewThreadScheduler.Default);

      //System.Reactive.Concurrency.CurrentThreadScheduler.Instance

      return sequence;
    }
  }
}
