using System;
using System.Reactive.Linq;

namespace RxMeetup.Observables
{
  public class Combined
  {
    public IObservable<int> GetObservable()
    {
      var observable1 = GetObservable1();
      var observable2 = GetObservable2();

      //var sequence = observable1.StartWith(-1)
      var sequence = observable1.Concat(observable2)
        //.Timeout(TimeSpan.FromMilliseconds(1200))
        //.Throttle(TimeSpan.FromMilliseconds(1200)) // While events are received within 1200 ms, they are discarded
      //var sequence = observable1.Merge(observable2)
      //.Distinct()
      //var sequence = observable1.Zip(observable2, (o1, o2) => o1 + o2)
      //var sequence = observable1.CombineLatest(observable2, (o1, o2) => o1 + o2)
      ;
      return sequence;
    }

    private IObservable<int> GetObservable1()
    {
      var sequence = Observable
        .Interval(TimeSpan.FromMilliseconds(1000))
        .Select(i => (int)i)
        .TakeWhile(i => i < 5)
        ;
      return sequence;
    }

    private IObservable<int> GetObservable2()
    {
      var sequence = Observable
        .Interval(TimeSpan.FromMilliseconds(1600))
        .Select(i => (int)i * 2)
        .TakeWhile(i => i < 10)
        ;
      return sequence;
    }
  }
}
