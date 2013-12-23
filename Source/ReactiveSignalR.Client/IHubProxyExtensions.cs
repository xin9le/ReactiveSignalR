using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading;



namespace ReactiveSignalR.Client
{
	/// <summary>
	/// Provides the extension methods of IHubProxy interface.
	/// </summary>
    public static class IHubProxyExtensions
	{
		#region Added On methods
		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10]),
					proxy.JsonSerializer.Convert<T12>(args[11])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}


		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10]),
					proxy.JsonSerializer.Convert<T12>(args[11]),
					proxy.JsonSerializer.Convert<T13>(args[12])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}

	
		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10]),
					proxy.JsonSerializer.Convert<T12>(args[11]),
					proxy.JsonSerializer.Convert<T13>(args[12]),
					proxy.JsonSerializer.Convert<T14>(args[13])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}

	
		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10]),
					proxy.JsonSerializer.Convert<T12>(args[11]),
					proxy.JsonSerializer.Convert<T13>(args[12]),
					proxy.JsonSerializer.Convert<T14>(args[13]),
					proxy.JsonSerializer.Convert<T15>(args[14])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}

	
		/// <summary>
		/// Registers for an event with the specified name and callback
		/// </summary>
		/// <param name="proxy">The <see cref="IHubProxy"/>.</param>
		/// <param name="eventName">The name of the event.</param>
		/// <param name="onData">The callback</param>
		/// <returns>An <see cref="IDisposable"/> that represents this subscription.</returns>
		public static IDisposable On<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>(this IHubProxy proxy, string eventName, Action<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16> onData)
		{
			if (proxy == null)						throw new ArgumentNullException("proxy");
			if (string.IsNullOrEmpty(eventName))	throw new ArgumentNullException("eventName");
			if (onData == null)						throw new ArgumentNullException("onData");

			var subscription = proxy.Subscribe(eventName);
			Action<IList<JToken>> handler = args =>
			{
				onData
				(
					proxy.JsonSerializer.Convert<T1>(args[0]),
					proxy.JsonSerializer.Convert<T2>(args[1]),
					proxy.JsonSerializer.Convert<T3>(args[2]),
					proxy.JsonSerializer.Convert<T4>(args[3]),
					proxy.JsonSerializer.Convert<T5>(args[4]),
					proxy.JsonSerializer.Convert<T6>(args[5]),
					proxy.JsonSerializer.Convert<T7>(args[6]),
					proxy.JsonSerializer.Convert<T8>(args[7]),
					proxy.JsonSerializer.Convert<T9>(args[8]),
					proxy.JsonSerializer.Convert<T10>(args[9]),
					proxy.JsonSerializer.Convert<T11>(args[10]),
					proxy.JsonSerializer.Convert<T12>(args[11]),
					proxy.JsonSerializer.Convert<T13>(args[12]),
					proxy.JsonSerializer.Convert<T14>(args[13]),
					proxy.JsonSerializer.Convert<T15>(args[14]),
					proxy.JsonSerializer.Convert<T16>(args[15])
				);
			};
			subscription.Received += handler;
			return new AnonymousDisposable(() => subscription.Received -= handler);
		}
		#endregion


		#region Private Helpers
		/// <summary>
		/// Convert to specific .NET type
		/// </summary>
		/// <typeparam name="T">Target type</typeparam>
		/// <param name="serializer">Converter</param>
		/// <param name="obj">Target object</param>
		/// <returns>Converted object</returns>
		private static T Convert<T>(this JsonSerializer serializer, JToken obj)
		{
			return	obj == null
				?	default(T)
				:	obj.ToObject<T>(serializer);
		}
		#endregion


		#region SynchronizationContext capturable On methods
		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Unit> On(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T">The type of the state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<T> On<T>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2>> On<T1, T2>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3>> On<T1, T2, T3>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2, T3>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4>> On<T1, T2, T3, T4>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2, T3, T4>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5>> On<T1, T2, T3, T4, T5>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2, T3, T4, T5>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <typeparam name="T6">The type of the 6th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5, T6>> On<T1, T2, T3, T4, T5, T6>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2, T3, T4, T5, T6>(eventName, context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <typeparam name="T6">The type of the 6th state variable</typeparam>
		/// <typeparam name="T7">The type of the 7th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="capturesSynchronizationContext">Whether to capture synchronization context</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5, T6, T7>> On<T1, T2, T3, T4, T5, T6, T7>(this IHubProxy proxy, string eventName, bool capturesSynchronizationContext = false)
		{
			var context	= capturesSynchronizationContext
						? SynchronizationContext.Current
						: null;
			return proxy.On<T1, T2, T3, T4, T5, T6, T7>(eventName, context);
		}
		#endregion


		#region SynchronizationContext settable On methods
		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Unit> On(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Unit>(observer =>
			{
				Action onData = () => observer.OnNext(Unit.Default);
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T">The type of the state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<T> On<T>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<T>(observer =>
			{
				Action<T> onData = x => observer.OnNext(x);
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2>> On<T1, T2>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2>>(observer =>
			{
				Action<T1, T2> onData = (x1, x2) => observer.OnNext(new Tuple<T1, T2>(x1, x2));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3>> On<T1, T2, T3>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2, T3>>(observer =>
			{
				Action<T1, T2, T3> onData = (x1, x2, x3) => observer.OnNext(new Tuple<T1, T2, T3>(x1, x2, x3));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4>> On<T1, T2, T3, T4>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2, T3, T4>>(observer =>
			{
				Action<T1, T2, T3, T4> onData = (x1, x2, x3, x4) => observer.OnNext(new Tuple<T1, T2, T3, T4>(x1, x2, x3, x4));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5>> On<T1, T2, T3, T4, T5>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2, T3, T4, T5>>(observer =>
			{
				Action<T1, T2, T3, T4, T5> onData = (x1, x2, x3, x4, x5) => observer.OnNext(new Tuple<T1, T2, T3, T4, T5>(x1, x2, x3, x4, x5));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <typeparam name="T6">The type of the 6th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5, T6>> On<T1, T2, T3, T4, T5, T6>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2, T3, T4, T5, T6>>(observer =>
			{
				Action<T1, T2, T3, T4, T5, T6> onData = (x1, x2, x3, x4, x5, x6) => observer.OnNext(new Tuple<T1, T2, T3, T4, T5, T6>(x1, x2, x3, x4, x5, x6));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}


		/// <summary>
		/// Registers for an observable event with the specified proxy and name.
		/// </summary>
		/// <typeparam name="T1">The type of the 1st state variable</typeparam>
		/// <typeparam name="T2">The type of the 2nd state variable</typeparam>
		/// <typeparam name="T3">The type of the 3rd state variable</typeparam>
		/// <typeparam name="T4">The type of the 4th state variable</typeparam>
		/// <typeparam name="T5">The type of the 5th state variable</typeparam>
		/// <typeparam name="T6">The type of the 6th state variable</typeparam>
		/// <typeparam name="T7">The type of the 7th state variable</typeparam>
		/// <param name="proxy">The proxy of the target hub</param>
		/// <param name="eventName">The name of the event</param>
		/// <param name="context">Synchronization context to notify observers on</param>
		/// <returns>Event squence</returns>
		public static IObservable<Tuple<T1, T2, T3, T4, T5, T6, T7>> On<T1, T2, T3, T4, T5, T6, T7>(this IHubProxy proxy, string eventName, SynchronizationContext context)
		{
			var sequence = Observable.Create<Tuple<T1, T2, T3, T4, T5, T6, T7>>(observer =>
			{
				Action<T1, T2, T3, T4, T5, T6, T7> onData = (x1, x2, x3, x4, x5, x6, x7) => observer.OnNext(new Tuple<T1, T2, T3, T4, T5, T6, T7>(x1, x2, x3, x4, x5, x6, x7));
				return proxy.On(eventName, onData);
			});
			return context == null ? sequence : sequence.ObserveOn(context);
		}
		#endregion
	}
}