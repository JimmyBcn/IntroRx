using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxMeetup.Observables
{
  public class Create_Nonblocking_Cancellable
  {
    public IObservable<int> GetObservable()
    {
      var cts = new CancellationTokenSource();

      var sequence = Observable.Create<int>(
        async o =>
        {
          for (int i = 0; i < 100; i++)
          {
            if (!cts.Token.IsCancellationRequested)
            {
              await Task.Delay(1000); // Do all the stuff
              o.OnNext(i);
            }
            else
            {
              Console.WriteLine("Aborting because cancel event was signaled!");
              o.OnCompleted();
            }
          }

          return Disposable.Create(
            () =>
            {
              cts.Cancel();
            });
        });

      return sequence;
    }
  }
}
