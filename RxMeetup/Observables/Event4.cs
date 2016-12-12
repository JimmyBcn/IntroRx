using RxMeetup.Observers;
using System;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RxMeetup.Observables
{
  public class Event4
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

    public void Run()
    {
      // We use System.Windows.Forms events for this sample
      var txt = new TextBox();
      txt.Width = 250;
      var lbl = new Label();
      lbl.Width = 400;
      lbl.Location = new System.Drawing.Point(0, 50);
      var frm = new Form { Controls = { txt, lbl } };

      // Define the observable
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
              //.SubscribeOn(System.Reactive.Concurrency.NewThreadScheduler.Default)
              //.ObserveOn(SynchronizationContext.Current)
                            ;

      // Define the observer
      var observer = Observer.Create<int>(
        item =>
        {
          lbl.Text = item.ToString();
        },
        error =>
        {
          // Source sequence throws an error
          Console.WriteLine("ERROR: " + error);
        },
        () =>
        {
          // Source sequence completed
          Console.WriteLine("Completed!");
          Console.ReadLine();
        });

      // 
      IDisposable subscription = sequence.Subscribe(observer);

      //Do some stuff with the sequence
      ;

      Application.Run(frm);
    }
  }
}
