#Observer Pattern
We need to be informed when certain things happen. 
Maybe object property changes, object might do something, some external events occur,... we want to listen to events and notified when they occur. This is built in
to C# by the event keyword. We also have IObservable<T> or IObserver<T>

An ###observer is an object that wishes to be informed about events happening in the system. The entity generating the events is an observable. 

##Weak Event Pattern
This pattern helps us to prevent memory leak as the result of += subscription operator. Unfortunately, this pattern requires WeakEventManager, which 
is not available in .Net Core. You need to import System.Base

##Observable pattern through special interfaces
#Rx extensions introduces interfaces that are now available through standard .Net
IObservable and IObserver are such interfaces

There is a downside to event and it is leaking of memory. Because the event subscrption becomes invisible. Through the IObservable and IObserver we
can control this. 

IObserver, observes, watches the observable. The observable can be watched. I am an observer of TV and the TV is the observable. 
Observer subscribes to the events that happen on the observable. This makes sense. The events have to originate from the observable, and the observer
is the one that subscribes to them to get the information from the events. 