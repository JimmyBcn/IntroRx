using RxMeetup.Observers;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Forms;

namespace RxMeetup.Observables
{
  public class Event3
  {
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
      var sequence = Observable.FromEventPattern<EventArgs>(txt, "KeyDown")
        .Throttle(TimeSpan.FromMilliseconds(3000))
        .Select(x => txt.Text)
        .ObserveOn(SynchronizationContext.Current) 
        ;

      // Define the observer
      var observer = Observer.Create<string>(
        item =>
        {
          lbl.Text = "You stopped writting. Text: " + item;
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
