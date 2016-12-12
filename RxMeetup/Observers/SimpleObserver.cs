using System;
using System.Reactive;

namespace RxMeetup.Observers
{
  public class SimpleObserver
  {
    public IObserver<int> GetObserver()
    {
      IObserver<int> observer = Observer.Create<int>(item => Console.WriteLine(item));
      return observer;
    }
  }
}
