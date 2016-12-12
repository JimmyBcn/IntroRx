using RxMeetup.Observers;
using System;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RxMeetup.Observables
{
  public class Event
  {
    // Buffer, Delay, Sample each require a separate thread/scheduler/timer to work their magic

    public void Run()
    {
      // We use System.Windows.Forms events for this sample
      var lbl = new Label();
      lbl.Width = 200;
      var frm = new Form { Controls = { lbl } };

      // Define the observable
      var sequence = Observable.FromEventPattern<MouseEventArgs>(frm, "MouseMove")
        .Select(e => e.EventArgs.X + ", " + e.EventArgs.Y)
      //.Sample(TimeSpan.FromMilliseconds(1000))
      //.ObserveOn(SynchronizationContext.Current) // this is different if we are in a WPF or ASP.NET app
      ;

      // Define the observer
      var observer = Observer.Create<string>(
        item =>
        {
          lbl.Text = "Coordinate: "+ item;
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
      IDisposable subscription = sequence
        .Subscribe(observer)
        ;

      //Do some stuff with the sequence
      ;

      Application.Run(frm);
    }
  }
}
