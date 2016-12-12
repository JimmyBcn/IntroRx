using System;
using System.Reactive;

namespace RxMeetup.Observers
{
  public class CompleteObserver
  {
    /// <summary>
    /// We can also specify routines when the source sequence is launching an error or it's finished
    /// </summary>
    /// <param name="observable"></param>
    /// <returns></returns>
    public IObserver<int> GetObserver()
    {
      IObserver<int> observer = Observer.Create<int>(
        item =>
        {
          // Source sequence sent a new item
          Console.WriteLine(item);
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

      return observer;
    }
  }
}
