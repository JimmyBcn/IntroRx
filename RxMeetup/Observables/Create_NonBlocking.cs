using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RxMeetup.Observables
{
  public class Create_NonBlocking
  {
    public IObservable<int> GetObservable()
    {
      var sequence = Observable.Create<int>(
        async o =>
        {
          for (int i = 0; i < 100; i++)
          {
            try
            {
              await Task.Delay(1000); // Your stuff
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
