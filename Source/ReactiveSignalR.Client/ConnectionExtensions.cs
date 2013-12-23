using Microsoft.AspNet.SignalR.Client;
using System;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;



namespace ReactiveSignalR.Client
{
	/// <summary>
	/// Provides the extension methods of Connection class.
	/// </summary>
	public static class ConnectionExtensions
	{
		#region Event to observable sequence converters
		/// <summary>
		/// Convert to an observable event sequence from closed event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ClosedAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.ClosedAsObservable(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from error event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Exception> ErrorAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.ErrorAsObservable(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from received event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<string> ReceivedAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.ReceivedAsObservable(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from reconnected event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ReconnectedAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.ReconnectedAsObservable(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from reconnecting event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ReconnectingAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.ReconnectingAsObservable(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from state changed event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event sequence</returns>
		public static IObservable<StateChange> StateChangedAsObservable(this Connection connection, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return connection.StateChangedAsObservable(context);
		}
		#endregion

	
		#region SynchronizationContext settable event to observable sequence converters
		/// <summary>
		/// Convert to an observable event sequence from closed event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ClosedAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent
			(
				h => connection.Closed += h,
				h => connection.Closed -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from error event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Exception> ErrorAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent<Exception>
			(
				h => connection.Error += h,
				h => connection.Error -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from received event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<string> ReceivedAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent<string>
			(
				h => connection.Received += h,
				h => connection.Received -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from reconnected event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ReconnectedAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent
			(
				h => connection.Reconnected += h,
				h => connection.Reconnected -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from reconnecting event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<Unit> ReconnectingAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent
			(
				h => connection.Reconnecting += h,
				h => connection.Reconnecting -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Convert to an observable event sequence from state changed event.
		/// </summary>
		/// <param name="connection">Target for SignalR service connection</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event sequence</returns>
		public static IObservable<StateChange> StateChangedAsObservable(this Connection connection, SynchronizationContext context)
		{
			var sequence = Observable.FromEvent<StateChange>
			(
				h => connection.StateChanged += h,
				h => connection.StateChanged -= h
			);
			return context == null ? sequence : sequence.ObserveOn(context);
		}
		#endregion
	}
}