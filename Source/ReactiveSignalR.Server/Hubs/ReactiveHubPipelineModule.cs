using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;



namespace ReactiveSignalR.Server.Hubs
{
	/// <summary>
	/// Provides the HubPipelineModule that provides as IObservable sequence events.
	/// </summary>
	public class ReactiveHubPipelineModule : HubPipelineModule
	{
		#region Fields
		private readonly Subject<Tuple<HubDescriptor, IRequest>>						beforeAuthorizeConnectSubject	= null;
		private readonly Subject<IHub>													beforeConnectSubject			= null;
		private readonly Subject<IHub>													afterConnectSubject				= null;
		private readonly Subject<IHub>													beforeReconnectSubject			= null;
		private readonly Subject<IHub>													afterReconnectSubject			= null;
		private readonly Subject<IHub>													beforeDisconnectSubject			= null;
		private readonly Subject<IHub>													afterDisconnectSubject			= null;
		private readonly Subject<IHubIncomingInvokerContext>							beforeIncomingSubject			= null;
		private readonly Subject<Tuple<object, IHubIncomingInvokerContext>>				afterIncomingSubject			= null;
		private readonly Subject<IHubOutgoingInvokerContext>							beforeOutgoingSubject			= null;
		private readonly Subject<IHubOutgoingInvokerContext>							afterOutgoingSubject			= null;
		private readonly Subject<Tuple<ExceptionContext, IHubIncomingInvokerContext>>	incomingErrorSubject			= null;
		#endregion


		#region Properties
		/// <summary>
		/// Gets the OnBeforeAuthorizeConnect event sequence. 
		/// </summary>
		public IObservable<Tuple<HubDescriptor, IRequest>> BeforeAuthorizeConnect{ get{ return this.beforeAuthorizeConnectSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnBeforeConnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeConnect{ get{ return this.beforeConnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterConnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterConnect{ get{ return this.afterConnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeReconnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeReconnect{ get{ return this.beforeReconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterReconnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterReconnect{ get{ return this.afterReconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeDisconnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeDisconnect{ get{ return this.beforeDisconnectSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnAfterDisconnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterDisconnect{ get{ return this.afterDisconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeIncoming event sequence. 
		/// </summary>
		public IObservable<IHubIncomingInvokerContext> BeforeIncoming{ get{ return this.beforeIncomingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnAfterIncoming event sequence. 
		/// </summary>
		public IObservable<Tuple<object, IHubIncomingInvokerContext>> AfterIncoming{ get{ return this.afterIncomingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnBeforeOutgoing event sequence. 
		/// </summary>
		public IObservable<IHubOutgoingInvokerContext> BeforeOutgoing{ get{ return this.beforeOutgoingSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterOutgoing event sequence. 
		/// </summary>
		public IObservable<IHubOutgoingInvokerContext> AfterOutgoing{ get{ return this.afterOutgoingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnIncomingError event sequence. 
		/// </summary>
		public IObservable<Tuple<ExceptionContext, IHubIncomingInvokerContext>>	IncomingError{ get{ return this.incomingErrorSubject.AsObservable(); } }
		#endregion


		#region Constructors
		/// <summary>
		/// Creates instance.
		/// </summary>
		public ReactiveHubPipelineModule()
		{
			this.beforeAuthorizeConnectSubject	= new Subject<Tuple<HubDescriptor,IRequest>>();
			this.beforeConnectSubject			= new Subject<IHub>();
			this.afterConnectSubject			= new Subject<IHub>();
			this.beforeReconnectSubject			= new Subject<IHub>();
			this.afterReconnectSubject			= new Subject<IHub>();
			this.beforeDisconnectSubject		= new Subject<IHub>();
			this.afterDisconnectSubject			= new Subject<IHub>();
			this.beforeIncomingSubject			= new Subject<IHubIncomingInvokerContext>();
			this.afterIncomingSubject			= new Subject<Tuple<object,IHubIncomingInvokerContext>>();
			this.beforeOutgoingSubject			= new Subject<IHubOutgoingInvokerContext>();
			this.afterOutgoingSubject			= new Subject<IHubOutgoingInvokerContext>();
			this.incomingErrorSubject			= new Subject<Tuple<ExceptionContext,IHubIncomingInvokerContext>>();
		}
		#endregion


		#region HubPipelineModule Overrides
		/// <summary>
		/// This method is called before the AuthorizeConnect components of any modules added later to the <see cref="IHubPipeline"/>
		/// are executed. If this returns false, then those later-added modules will not run and the client will not be allowed
		/// to subscribe to client-side invocations of methods belonging to the hub defined by the <see cref="HubDescriptor"/>.
		/// </summary>
		/// <param name="hubDescriptor">A description of the hub the client is trying to subscribe to.</param>
		/// <param name="request">The connect request of the client trying to subscribe to the hub.</param>
		/// <returns>true, if the client is authorized to connect to the hub, false otherwise.</returns>
		protected override bool OnBeforeAuthorizeConnect(HubDescriptor hubDescriptor, IRequest request)
		{
			this.beforeAuthorizeConnectSubject.OnNext(Tuple.Create(hubDescriptor, request));
			return base.OnBeforeAuthorizeConnect(hubDescriptor, request);
		}


		/// <summary>
		/// This method is called before the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnConnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		/// <returns>
		/// true, if the connect components of later added modules and the <see cref="IHub.OnConnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeConnect(IHub hub)
		{
			this.beforeConnectSubject.OnNext(hub);
			return base.OnBeforeConnect(hub);
		}


		/// <summary>
		/// This method is called after the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnConnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		protected override void OnAfterConnect(IHub hub)
		{
			this.afterConnectSubject.OnNext(hub);
			base.OnAfterConnect(hub);
		}


		/// <summary>
		/// This method is called before the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnReconnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		/// <returns>
		/// true, if the reconnect components of later added modules and the <see cref="IHub.OnReconnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeReconnect(IHub hub)
		{
			this.beforeReconnectSubject.OnNext(hub);
			return base.OnBeforeReconnect(hub);
		}


		/// <summary>
		/// This method is called after the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnReconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		protected override void OnAfterReconnect(IHub hub)
		{
			this.afterReconnectSubject.OnNext(hub);
			base.OnAfterReconnect(hub);
		}


		/// <summary>
		/// This method is called before the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnDisconnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		/// <returns>
		/// true, if the disconnect components of later added modules and the <see cref="IHub.OnDisconnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeDisconnect(IHub hub)
		{
			this.beforeDisconnectSubject.OnNext(hub);
			return base.OnBeforeDisconnect(hub);
		}


		/// <summary>
		/// This method is called after the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnDisconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		protected override void OnAfterDisconnect(IHub hub)
		{
			this.afterDisconnectSubject.OnNext(hub);
			base.OnAfterDisconnect(hub);
		}


		/// <summary>
		/// This method is called before the incoming components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the server-side hub method invocation will not
		/// be executed. Even if a client has not been authorized to connect to a hub, it will still be authorized to invoke
		/// server-side methods on that hub unless it is prevented in <see cref="IHubPipelineModule.BuildIncoming"/> by not
		/// executing the invoke parameter or prevented in <see cref="HubPipelineModule.OnBeforeIncoming"/> by returning false.
		/// </summary>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		/// <returns>
		/// true, if the incoming components of later added modules and the server-side hub method invocation should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
		{
			this.beforeIncomingSubject.OnNext(context);
			return base.OnBeforeIncoming(context);
		}


		/// <summary>
		/// This method is called after the incoming components of any modules added later to the <see cref="IHubPipeline"/>
		/// and the server-side hub method have completed execution.
		/// </summary>
		/// <param name="result">The return value of the server-side hub method</param>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		/// <returns>The possibly new or updated return value of the server-side hub method</returns>
		protected override object OnAfterIncoming(object result, IHubIncomingInvokerContext context)
		{
			this.afterIncomingSubject.OnNext(Tuple.Create(result, context));
			return base.OnAfterIncoming(result, context);
		}


		/// <summary>
		/// This method is called before the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the client-side hub method invocation(s) will not
		/// be executed.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		/// <returns>
		/// true, if the outgoing components of later added modules and the client-side hub method invocation(s) should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
		{
			this.beforeOutgoingSubject.OnNext(context);
			return base.OnBeforeOutgoing(context);
		}


		/// <summary>
		/// This method is called after the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. This does not mean that all the clients have received the hub method invocation, but it does indicate indicate
		/// a hub invocation message has successfully been published to a message bus.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
		{
			this.afterOutgoingSubject.OnNext(context);
			base.OnAfterOutgoing(context);
		}


		/// <summary>
		/// This is called when an uncaught exception is thrown by a server-side hub method or the incoming component of a
		/// module added later to the <see cref="IHubPipeline"/>. Observing the exception using this method will not prevent
		/// it from bubbling up to other modules.
		/// </summary>
		/// <param name="ex">The exception that was thrown during the server-side invocation.</param>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
		{
			this.incomingErrorSubject.OnNext(Tuple.Create(exceptionContext, invokerContext));
			base.OnIncomingError(exceptionContext, invokerContext);
		}
		#endregion
	}



	/// <summary>
	/// Provides the HubPipelineModule that provides as IObservable sequence events for specified Hub.
	/// </summary>
	/// <typeparam name="THub">Target hub type.</typeparam>
	public class ReactiveHubPipelineModule<THub> : HubPipelineModule
		where THub : Hub
	{
		#region Fields
		private readonly Subject<Tuple<HubDescriptor, IRequest>>						beforeAuthorizeConnectSubject	= null;
		private readonly Subject<IHub>													beforeConnectSubject			= null;
		private readonly Subject<IHub>													afterConnectSubject				= null;
		private readonly Subject<IHub>													beforeReconnectSubject			= null;
		private readonly Subject<IHub>													afterReconnectSubject			= null;
		private readonly Subject<IHub>													beforeDisconnectSubject			= null;
		private readonly Subject<IHub>													afterDisconnectSubject			= null;
		private readonly Subject<IHubIncomingInvokerContext>							beforeIncomingSubject			= null;
		private readonly Subject<Tuple<object, IHubIncomingInvokerContext>>				afterIncomingSubject			= null;
		private readonly Subject<IHubOutgoingInvokerContext>							beforeOutgoingSubject			= null;
		private readonly Subject<IHubOutgoingInvokerContext>							afterOutgoingSubject			= null;
		private readonly Subject<Tuple<ExceptionContext, IHubIncomingInvokerContext>>	incomingErrorSubject			= null;
		#endregion


		#region Properties
		/// <summary>
		/// Gets the OnBeforeAuthorizeConnect event sequence. 
		/// </summary>
		public IObservable<Tuple<HubDescriptor, IRequest>> BeforeAuthorizeConnect{ get{ return this.beforeAuthorizeConnectSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnBeforeConnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeConnect{ get{ return this.beforeConnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterConnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterConnect{ get{ return this.afterConnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeReconnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeReconnect{ get{ return this.beforeReconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterReconnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterReconnect{ get{ return this.afterReconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeDisconnect event sequence. 
		/// </summary>
		public IObservable<IHub> BeforeDisconnect{ get{ return this.beforeDisconnectSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnAfterDisconnect event sequence. 
		/// </summary>
		public IObservable<IHub> AfterDisconnect{ get{ return this.afterDisconnectSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnBeforeIncoming event sequence. 
		/// </summary>
		public IObservable<IHubIncomingInvokerContext> BeforeIncoming{ get{ return this.beforeIncomingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnAfterIncoming event sequence. 
		/// </summary>
		public IObservable<Tuple<object, IHubIncomingInvokerContext>> AfterIncoming{ get{ return this.afterIncomingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnBeforeOutgoing event sequence. 
		/// </summary>
		public IObservable<IHubOutgoingInvokerContext> BeforeOutgoing{ get{ return this.beforeOutgoingSubject.AsObservable(); } }


		/// <summary>
		/// Gets the OnAfterOutgoing event sequence. 
		/// </summary>
		public IObservable<IHubOutgoingInvokerContext> AfterOutgoing{ get{ return this.afterOutgoingSubject.AsObservable(); } }

	
		/// <summary>
		/// Gets the OnIncomingError event sequence. 
		/// </summary>
		public IObservable<Tuple<ExceptionContext, IHubIncomingInvokerContext>>	IncomingError{ get{ return this.incomingErrorSubject.AsObservable(); } }
		#endregion


		#region Constructors
		/// <summary>
		/// Creates instance.
		/// </summary>
		public ReactiveHubPipelineModule()
		{
			this.beforeAuthorizeConnectSubject	= new Subject<Tuple<HubDescriptor,IRequest>>();
			this.beforeConnectSubject			= new Subject<IHub>();
			this.afterConnectSubject			= new Subject<IHub>();
			this.beforeReconnectSubject			= new Subject<IHub>();
			this.afterReconnectSubject			= new Subject<IHub>();
			this.beforeDisconnectSubject		= new Subject<IHub>();
			this.afterDisconnectSubject			= new Subject<IHub>();
			this.beforeIncomingSubject			= new Subject<IHubIncomingInvokerContext>();
			this.afterIncomingSubject			= new Subject<Tuple<object,IHubIncomingInvokerContext>>();
			this.beforeOutgoingSubject			= new Subject<IHubOutgoingInvokerContext>();
			this.afterOutgoingSubject			= new Subject<IHubOutgoingInvokerContext>();
			this.incomingErrorSubject			= new Subject<Tuple<ExceptionContext,IHubIncomingInvokerContext>>();
		}
		#endregion


		#region HubPipelineModule Overrides
		/// <summary>
		/// This method is called before the AuthorizeConnect components of any modules added later to the <see cref="IHubPipeline"/>
		/// are executed. If this returns false, then those later-added modules will not run and the client will not be allowed
		/// to subscribe to client-side invocations of methods belonging to the hub defined by the <see cref="HubDescriptor"/>.
		/// </summary>
		/// <param name="hubDescriptor">A description of the hub the client is trying to subscribe to.</param>
		/// <param name="request">The connect request of the client trying to subscribe to the hub.</param>
		/// <returns>true, if the client is authorized to connect to the hub, false otherwise.</returns>
		protected override bool OnBeforeAuthorizeConnect(HubDescriptor hubDescriptor, IRequest request)
		{
			if (typeof(THub) == hubDescriptor.HubType)
				this.beforeAuthorizeConnectSubject.OnNext(Tuple.Create(hubDescriptor, request));
			return base.OnBeforeAuthorizeConnect(hubDescriptor, request);
		}


		/// <summary>
		/// This method is called before the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnConnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		/// <returns>
		/// true, if the connect components of later added modules and the <see cref="IHub.OnConnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeConnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.beforeConnectSubject.OnNext(hub);
			return base.OnBeforeConnect(hub);
		}


		/// <summary>
		/// This method is called after the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnConnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		protected override void OnAfterConnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.afterConnectSubject.OnNext(hub);
			base.OnAfterConnect(hub);
		}


		/// <summary>
		/// This method is called before the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnReconnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		/// <returns>
		/// true, if the reconnect components of later added modules and the <see cref="IHub.OnReconnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeReconnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.beforeReconnectSubject.OnNext(hub);
			return base.OnBeforeReconnect(hub);
		}


		/// <summary>
		/// This method is called after the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnReconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		protected override void OnAfterReconnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.afterReconnectSubject.OnNext(hub);
			base.OnAfterReconnect(hub);
		}


		/// <summary>
		/// This method is called before the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the <see cref="IHub.OnDisconnected"/> method will
		/// not be run.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		/// <returns>
		/// true, if the disconnect components of later added modules and the <see cref="IHub.OnDisconnected"/> method should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeDisconnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.beforeDisconnectSubject.OnNext(hub);
			return base.OnBeforeDisconnect(hub);
		}


		/// <summary>
		/// This method is called after the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnDisconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		protected override void OnAfterDisconnect(IHub hub)
		{
			if (typeof(THub) == hub.GetType())
				this.afterDisconnectSubject.OnNext(hub);
			base.OnAfterDisconnect(hub);
		}


		/// <summary>
		/// This method is called before the incoming components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the server-side hub method invocation will not
		/// be executed. Even if a client has not been authorized to connect to a hub, it will still be authorized to invoke
		/// server-side methods on that hub unless it is prevented in <see cref="IHubPipelineModule.BuildIncoming"/> by not
		/// executing the invoke parameter or prevented in <see cref="HubPipelineModule.OnBeforeIncoming"/> by returning false.
		/// </summary>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		/// <returns>
		/// true, if the incoming components of later added modules and the server-side hub method invocation should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeIncoming(IHubIncomingInvokerContext context)
		{
			if (typeof(THub) == context.MethodDescriptor.Hub.HubType)
				this.beforeIncomingSubject.OnNext(context);
			return base.OnBeforeIncoming(context);
		}


		/// <summary>
		/// This method is called after the incoming components of any modules added later to the <see cref="IHubPipeline"/>
		/// and the server-side hub method have completed execution.
		/// </summary>
		/// <param name="result">The return value of the server-side hub method</param>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		/// <returns>The possibly new or updated return value of the server-side hub method</returns>
		protected override object OnAfterIncoming(object result, IHubIncomingInvokerContext context)
		{
			if (typeof(THub) == context.MethodDescriptor.Hub.HubType)
				this.afterIncomingSubject.OnNext(Tuple.Create(result, context));
			return base.OnAfterIncoming(result, context);
		}


		/// <summary>
		/// This method is called before the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. If this returns false, then those later-added modules and the client-side hub method invocation(s) will not
		/// be executed.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		/// <returns>
		/// true, if the outgoing components of later added modules and the client-side hub method invocation(s) should be executed;
		/// false, otherwise.
		/// </returns>
		protected override bool OnBeforeOutgoing(IHubOutgoingInvokerContext context)
		{
			if (typeof(THub).Name == context.Invocation.Hub)
				this.beforeOutgoingSubject.OnNext(context);
			return base.OnBeforeOutgoing(context);
		}


		/// <summary>
		/// This method is called after the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. This does not mean that all the clients have received the hub method invocation, but it does indicate indicate
		/// a hub invocation message has successfully been published to a message bus.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
		{
			if (typeof(THub).Name == context.Invocation.Hub)
				this.afterOutgoingSubject.OnNext(context);
			base.OnAfterOutgoing(context);
		}


		/// <summary>
		/// This is called when an uncaught exception is thrown by a server-side hub method or the incoming component of a
		/// module added later to the <see cref="IHubPipeline"/>. Observing the exception using this method will not prevent
		/// it from bubbling up to other modules.
		/// </summary>
		/// <param name="ex">The exception that was thrown during the server-side invocation.</param>
		/// <param name="context">A description of the server-side hub method invocation.</param>
		protected override void OnIncomingError(ExceptionContext exceptionContext, IHubIncomingInvokerContext invokerContext)
		{
			if (typeof(THub) == invokerContext.MethodDescriptor.Hub.HubType)
				this.incomingErrorSubject.OnNext(Tuple.Create(exceptionContext, invokerContext));
			base.OnIncomingError(exceptionContext, invokerContext);
		}
		#endregion
	}
}