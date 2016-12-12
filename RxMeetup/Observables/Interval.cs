using System;
using System.Reactive.Linq;

namespace RxMeetup.Observables
{
  public class Interval
  {
    public IObservable<int> GetObservable()
    {
      var sequence = Observable
        .Interval(TimeSpan.FromMilliseconds(1000))
        .Select(i => (int)i)

        // TIME SHIFTING the sequence
        //.DelaySubscription(TimeSpan.FromSeconds(2))
        //.Sample(TimeSpan.FromMilliseconds(1500))

        // FINALIZING the sequence
        //.TakeWhile(i => i < 5)

        // REPEATING the sequence (use with TakeWhile)
        //.Repeat()
        ;
      return sequence;
    }
  }
}
