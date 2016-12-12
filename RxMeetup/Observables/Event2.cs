using RxMeetup.Observers;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RxMeetup.Observables
{
  public class Event2
  {
    public void Run()
    {
      // We use System.Windows.Forms events for this sample
      var btn = new Button();
      btn.Text = "Click me!";
      var lbl = new Label();
      lbl.Location = new System.Drawing.Point(0, 50);
      var frm = new Form { Controls = { btn, lbl } };

      // Define the observable
      var sequence = Observable.FromEventPattern<EventArgs>(btn, "Click")
        .Buffer(TimeSpan.FromMilliseconds(2000))
        .Select(clicks => clicks.Count.ToString())
        .ObserveOn(SynchronizationContext.Current) 
        ;

      // Define the observer
      var observer = Observer.Create<string>(
        item =>
        {
          lbl.Text = "You've cliecked " + item + " times";
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
