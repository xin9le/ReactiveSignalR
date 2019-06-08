using System;
using System.Reactive;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;



namespace ReactiveSignalR.Client
{
    /// <summary>
    /// Provides <see cref="HubConnection"/> extension methods.
    /// </summary>
    public static class HubConnectionExtensions
    {
        #region Inner classes
        /// <summary>
        /// Provides observable sequence for <see cref="HubConnection.On"/> method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        private sealed class OnObservable<T> : ObservableBase<T>
        {
            #region Properties
            private HubConnection Connection { get; }
            private string MethodName { get; }
            private Type[] ParameterTypes { get; }
            private Func<object[], object, Task> Handler { get; }
            #endregion


            #region Constructors
            public OnObservable(HubConnection connection, string methodName, Type[] parameterTypes, Func<object[], object, Task> handler)
            {
                this.Connection = connection;
                this.MethodName = methodName;
                this.ParameterTypes = parameterTypes;
                this.Handler = handler;
            }
            #endregion


            #region ObservableBase<T> implementations
            protected override IDisposable SubscribeCore(IObserver<T> observer)
                => this.Connection.On(this.MethodName, this.ParameterTypes, this.Handler, observer);
            #endregion
        }
        #endregion


        #region On as observable
        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<Unit> On(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<Unit>
            (
                connection,
                methodName,
                Type.EmptyTypes,
                (_, state) =>
                {
                    var observer = (IObserver<Unit>)state;
                    observer.OnNext(Unit.Default);
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T">1st argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<T> On<T>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<T>
            (
                connection,
                methodName,
                new[] { typeof(T) },
                (args, state) =>
                {
                    var observer = (IObserver<T>)state;
                    observer.OnNext((T)args[0]);
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2)> On<T1, T2>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    observer.OnNext((a1, a2));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3)> On<T1, T2, T3>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    observer.OnNext((a1, a2, a3));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <typeparam name="T4">4th argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3, T4)> On<T1, T2, T3, T4>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3, T4)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3, T4)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    var a4 = (T4)args[3];
                    observer.OnNext((a1, a2, a3, a4));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <typeparam name="T4">4th argument type.</typeparam>
        /// <typeparam name="T5">5th argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3, T4, T5)> On<T1, T2, T3, T4, T5>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3, T4, T5)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3, T4, T5)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    var a4 = (T4)args[3];
                    var a5 = (T5)args[4];
                    observer.OnNext((a1, a2, a3, a4, a5));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <typeparam name="T4">4th argument type.</typeparam>
        /// <typeparam name="T5">5th argument type.</typeparam>
        /// <typeparam name="T6">6th argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3, T4, T5, T6)> On<T1, T2, T3, T4, T5, T6>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3, T4, T5, T6)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3, T4, T5, T6)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    var a4 = (T4)args[3];
                    var a5 = (T5)args[4];
                    var a6 = (T6)args[5];
                    observer.OnNext((a1, a2, a3, a4, a5, a6));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <typeparam name="T4">4th argument type.</typeparam>
        /// <typeparam name="T5">5th argument type.</typeparam>
        /// <typeparam name="T6">6th argument type.</typeparam>
        /// <typeparam name="T7">7th argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3, T4, T5, T6, T7)> On<T1, T2, T3, T4, T5, T6, T7>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3, T4, T5, T6, T7)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3, T4, T5, T6, T7)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    var a4 = (T4)args[3];
                    var a5 = (T5)args[4];
                    var a6 = (T6)args[5];
                    var a7 = (T7)args[6];
                    observer.OnNext((a1, a2, a3, a4, a5, a6, a7));
                    return Task.CompletedTask;
                }
            );
        }


        /// <summary>
        /// Gets the observable sequence that will be invoked when the hub method with the specified method name is invoked.
        /// </summary>
        /// <typeparam name="T1">1st argument type.</typeparam>
        /// <typeparam name="T2">2nd argument type.</typeparam>
        /// <typeparam name="T3">3rd argument type.</typeparam>
        /// <typeparam name="T4">4th argument type.</typeparam>
        /// <typeparam name="T5">5th argument type.</typeparam>
        /// <typeparam name="T6">6th argument type.</typeparam>
        /// <typeparam name="T7">7th argument type.</typeparam>
        /// <typeparam name="T8">8th argument type.</typeparam>
        /// <param name="connection">Hub connection.</param>
        /// <param name="methodName">The name of the hub method to define.</param>
        /// <returns></returns>
        public static IObservable<(T1, T2, T3, T4, T5, T6, T7, T8)> On<T1, T2, T3, T4, T5, T6, T7, T8>(this HubConnection connection, string methodName)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));
            if (methodName == null) throw new ArgumentNullException(nameof(methodName));

            return new OnObservable<(T1, T2, T3, T4, T5, T6, T7, T8)>
            (
                connection,
                methodName,
                new[] { typeof(T1), typeof(T2), typeof(T3), typeof(T4), typeof(T5), typeof(T6), typeof(T7), typeof(T8) },
                (args, state) =>
                {
                    var observer = (IObserver<(T1, T2, T3, T4, T5, T6, T7, T8)>)state;
                    var a1 = (T1)args[0];
                    var a2 = (T2)args[1];
                    var a3 = (T3)args[2];
                    var a4 = (T4)args[3];
                    var a5 = (T5)args[4];
                    var a6 = (T6)args[5];
                    var a7 = (T7)args[6];
                    var a8 = (T8)args[7];
                    observer.OnNext((a1, a2, a3, a4, a5, a6, a7, a8));
                    return Task.CompletedTask;
                }
            );
        }
        #endregion
    }
}
