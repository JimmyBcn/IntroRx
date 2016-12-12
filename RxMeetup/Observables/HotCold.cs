using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace RxMeetup.Observables
{
  public class HotCold
  {
    public IObservable<int> GetObservable()
    {
      // Creates a [COLD OBSERVABLE SEQUENCE or Observable] which starts emitting items when an observer is subscribed to (creating a disposable subscription). 
      // A subscription is not terminated unless either it is disposed nor the sequence finishes (OnCompleted) or returns an error (OnError).
      // The observable object remains alive while any of the subscriptions is not disposed. --> Be careful with memory leaks.
      // The values sent by the observable are NOT SHARED among the subscribers, so every single subscription is listening to a different sequence.
      IObservable<int> serialNumberStream = Observable.Create<int>(
        async o =>
        {
          try
          {
            var serialNumber = await Task.FromResult(new Random().Next());
            o.OnNext(serialNumber);
            await Task.Delay(2500);
          }
          catch (Exception ex)
          {
            o.OnError(ex);
          }

          o.OnCompleted();
        })
        // Repeats the sequence.
        .Repeat()

        // Warms up the previous [COLD OBSERVABLE SEQUENCE or Observable] making it a [HOT OBSERVABLE SEQUENCE or ConnectableObservable]. 
        // Observers can subscribe now to the sequence (creating a disposable subscription) but the sequence does not start emiting items until one of them call the Connect() action. 
        // Subscriptors can dispose the subscription independently, but the ConnectableObservable will remain alive if any of the subscriptions is not disposed --> Be careful with memory leaks and dispose all subscriptions.
        // The [HOT OBSERVABLE SEQUENCE or ConnectableObservable] is SHARED among the subscribers, so all subscriptions are listening to the same sequence.
        //.Publish()

        // Cold down a [HOT OBSERVABLE SEQUENCE or ConnectableObservable] to a [COLD OBSERVABLE SEQUENCE or Observable] 
        // but now the sequence is shared among all the subscribers.
        // This observable uses the first observer subscription to perform the Connect() action (which starts emiting items).
        //.RefCount()
        ;

      return serialNumberStream;
    }
  }
}
