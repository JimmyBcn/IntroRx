using System;
using System.Reactive.Linq;

namespace RxMeetup.Observables
{
  public class Range
  {
    public IObservable<int> GetObservable()
    {
      var sequence = Observable
        .Range(0, 10)

        //FILTERING the sequence
        //.Skip(5)
        //.Take(3)
        //.Where(i => i % 2 == 0)

        //MAPPING (PROJECTING) the sequence
        //.Select(i => i*10) 

        //REDUCING the sequence
        //.Sum()
        //.Max()
        //.Average()

        //INSPECTING the sequence
        //.ElementAt(5)
        ;
      return sequence;
    }
  }
}
