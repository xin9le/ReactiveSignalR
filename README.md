# ReactiveSignalR

ReactiveSignalR provides reactive programming for ASP.NET Core SignalR client application (*NOT* supports ASP.NET SignalR).



## Feature

- Provides `HubConnection.On` method as `IObservable`
- Provides `HubConnection` event as `IObservable`



## How to use

```cs
//--- Create connection
var url = "http://localhost:5000/chathub";
var connection = new HubConnectionBuilder().WithUrl(url).Build();

//--- Fluently coding using Rx
var subscription
    = connection
    .On<string>("Receive")  // ReactiveSignalR provides this line
    .Subscribe(message => /* do something */);

//--- Unsubscribe
subscription.Dispose();
```


## Installation
Getting started from downloading NuGet package.

```text
PM> Install-Package ReactiveSignalR
```


## License

This library is provided under [MIT License](http://opensource.org/licenses/MIT).


## Author

Takaaki Suzuki (a.k.a [@xin9le](https://twitter.com/xin9le)) is software developer in Japan who awarded Microsoft MVP for Developer Technologies (C#) since July 2012.