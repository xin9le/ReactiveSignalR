using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Linq;



namespace ReactiveSignalR.Server.Hubs
{
	/// <summary>
	/// Provides the HubPipelineModule to specify a delegate from outside.
	/// </summary>
    public class AnonymousHubPipelineModule : HubPipelineModule
	{
		#region Fields
		private readonly Func<HubDescriptor, IRequest, bool>					onBeforeAuthorizeConnect	= null;
		private readonly Func<IHub, bool>										onBeforeConnect				= null;
		private readonly Action<IHub>											onAfterConnect				= null;
		private readonly Func<IHub, bool>										onBeforeReconnect			= null;
		private readonly Action<IHub>											onAfterReconnect			= null;
		private readonly Func<IHub, bool>										onBeforeDisconnect			= null;
		private readonly Action<IHub>											onAfterDisconnect			= null;
		private readonly Func<IHubIncomingInvokerContext, bool>					onBeforeIncoming			= null;
		private readonly Func<object, IHubIncomingInvokerContext, object>		onAfterIncoming				= null;
		private readonly Func<IHubOutgoingInvokerContext, bool>					onBeforeOutgoing			= null;
		private readonly Action<IHubOutgoingInvokerContext>						onAfterOutgoing				= null;
		private readonly Action<ExceptionContext, IHubIncomingInvokerContext>	onIncomingError				= null;
		#endregion


		#region Constructors
		/// <summary>
		/// Creates instance.
		/// </summary>
		/// <param name="onBeforeAuthorizeConnect">This delegate is called when OnBeforeAuthorizeConnect.</param>
		/// <param name="onBeforeConnect">This delegate is called when OnBeforeConnect.</param>
		/// <param name="onAfterConnect">This delegate is called when OnAfterConnect.</param>
		/// <param name="onBeforeReconnect">This delegate is called when OnBeforeReconnect.</param>
		/// <param name="onAfterReconnect">This delegate is called when OnAfterReconnect.</param>
		/// <param name="onBeforeDisconnect">This delegate is called when OnBeforeDisconnect.</param>
		/// <param name="onAfterDisconnect">This delegate is called when OnAfterDisconnect.</param>
		/// <param name="onBeforeIncoming">This delegate is called when OnBeforeIncoming.</param>
		/// <param name="onAfterIncoming">This delegate is called when OnAfterIncoming.</param>
		/// <param name="onBeforeOutgoing">This delegate is called when OnBeforeOutgoing.</param>
		/// <param name="onAfterOutgoing">This delegate is called when OnAfterOutgoing.</param>
		/// <param name="onIncomingError">This delegate is called when OnIncomingError.</param>
		public AnonymousHubPipelineModule
			(
				Func<HubDescriptor, IRequest, bool>						onBeforeAuthorizeConnect	= null,
				Func<IHub, bool>										onBeforeConnect				= null,
				Action<IHub>											onAfterConnect				= null,
				Func<IHub, bool>										onBeforeReconnect			= null,
				Action<IHub>											onAfterReconnect			= null,
				Func<IHub, bool>										onBeforeDisconnect			= null,
				Action<IHub>											onAfterDisconnect			= null,
				Func<IHubIncomingInvokerContext, bool>					onBeforeIncoming			= null,
				Func<object, IHubIncomingInvokerContext, object>		onAfterIncoming				= null,
				Func<IHubOutgoingInvokerContext, bool>					onBeforeOutgoing			= null,
				Action<IHubOutgoingInvokerContext>						onAfterOutgoing				= null,
				Action<ExceptionContext, IHubIncomingInvokerContext>	onIncomingError				= null
			)
		{
			this.onBeforeAuthorizeConnect	= onBeforeAuthorizeConnect;
			this.onBeforeConnect			= onBeforeConnect;
			this.onAfterConnect				= onAfterConnect;
			this.onBeforeReconnect			= onBeforeReconnect;
			this.onAfterReconnect			= onAfterReconnect;
			this.onBeforeDisconnect			= onBeforeDisconnect;
			this.onAfterDisconnect			= onAfterDisconnect;
			this.onBeforeIncoming			= onBeforeIncoming;
			this.onAfterIncoming			= onAfterIncoming;
			this.onBeforeOutgoing			= onBeforeOutgoing;
			this.onAfterOutgoing			= onAfterOutgoing;
			this.onIncomingError			= onIncomingError;
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
			return	this.onBeforeAuthorizeConnect == null
				?	base.OnBeforeAuthorizeConnect(hubDescriptor, request)
				:	this.onBeforeAuthorizeConnect(hubDescriptor, request);
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
			return	this.onBeforeConnect == null
				?	base.OnBeforeConnect(hub)
				:	this.onBeforeConnect(hub);
		}


		/// <summary>
		/// This method is called after the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnConnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		protected override void OnAfterConnect(IHub hub)
		{
			if (this.onAfterConnect == null)	base.OnAfterConnect(hub);
			else								this.onAfterConnect(hub);
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
			return	this.onBeforeReconnect == null
				?	base.OnBeforeReconnect(hub)
				:	this.onBeforeReconnect(hub);
		}


		/// <summary>
		/// This method is called after the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnReconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		protected override void OnAfterReconnect(IHub hub)
		{
			if (this.onAfterReconnect == null)	base.OnAfterReconnect(hub);
			else								this.onAfterReconnect(hub);
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
			return	this.onBeforeDisconnect == null
				?	base.OnBeforeDisconnect(hub)
				:	this.onBeforeDisconnect(hub);
		}


		/// <summary>
		/// This method is called after the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnDisconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		protected override void OnAfterDisconnect(IHub hub)
		{
			if (this.onAfterDisconnect == null)	base.OnAfterDisconnect(hub);
			else								this.onAfterDisconnect(hub);
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
			return	this.onBeforeIncoming == null
				?	base.OnBeforeIncoming(context)
				:	this.onBeforeIncoming(context);
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
			return	this.onAfterIncoming == null
				?	base.OnAfterIncoming(result, context)
				:	this.onAfterIncoming(result, context);
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
			return	this.onBeforeOutgoing == null
				?	base.OnBeforeOutgoing(context)
				:	this.onBeforeOutgoing(context);
		}


		/// <summary>
		/// This method is called after the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. This does not mean that all the clients have received the hub method invocation, but it does indicate indicate
		/// a hub invocation message has successfully been published to a message bus.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
		{
			if (this.onAfterOutgoing == null)	base.OnAfterOutgoing(context);
			else								this.onAfterOutgoing(context);
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
			if (this.onIncomingError == null)	base.OnIncomingError(exceptionContext, invokerContext);
			else								this.onIncomingError(exceptionContext, invokerContext);
		}
		#endregion
	}



	/// <summary>
	/// Provides the HubPipelineModule to specify a delegate from outside.
	/// </summary>
 	/// <typeparam name="THub">Target hub type.</typeparam>
   public class AnonymousHubPipelineModule<THub> : HubPipelineModule
		where THub : Hub
	{
		#region Fields
		private readonly Func<HubDescriptor, IRequest, bool>					onBeforeAuthorizeConnect	= null;
		private readonly Func<IHub, bool>										onBeforeConnect				= null;
		private readonly Action<IHub>											onAfterConnect				= null;
		private readonly Func<IHub, bool>										onBeforeReconnect			= null;
		private readonly Action<IHub>											onAfterReconnect			= null;
		private readonly Func<IHub, bool>										onBeforeDisconnect			= null;
		private readonly Action<IHub>											onAfterDisconnect			= null;
		private readonly Func<IHubIncomingInvokerContext, bool>					onBeforeIncoming			= null;
		private readonly Func<object, IHubIncomingInvokerContext, object>		onAfterIncoming				= null;
		private readonly Func<IHubOutgoingInvokerContext, bool>					onBeforeOutgoing			= null;
		private readonly Action<IHubOutgoingInvokerContext>						onAfterOutgoing				= null;
		private readonly Action<ExceptionContext, IHubIncomingInvokerContext>	onIncomingError				= null;
		#endregion


		#region Constructors
		/// <summary>
		/// Creates instance.
		/// </summary>
		/// <param name="onBeforeAuthorizeConnect">This delegate is called when OnBeforeAuthorizeConnect.</param>
		/// <param name="onBeforeConnect">This delegate is called when OnBeforeConnect.</param>
		/// <param name="onAfterConnect">This delegate is called when OnAfterConnect.</param>
		/// <param name="onBeforeReconnect">This delegate is called when OnBeforeReconnect.</param>
		/// <param name="onAfterReconnect">This delegate is called when OnAfterReconnect.</param>
		/// <param name="onBeforeDisconnect">This delegate is called when OnBeforeDisconnect.</param>
		/// <param name="onAfterDisconnect">This delegate is called when OnAfterDisconnect.</param>
		/// <param name="onBeforeIncoming">This delegate is called when OnBeforeIncoming.</param>
		/// <param name="onAfterIncoming">This delegate is called when OnAfterIncoming.</param>
		/// <param name="onBeforeOutgoing">This delegate is called when OnBeforeOutgoing.</param>
		/// <param name="onAfterOutgoing">This delegate is called when OnAfterOutgoing.</param>
		/// <param name="onIncomingError">This delegate is called when OnIncomingError.</param>
		public AnonymousHubPipelineModule
			(
				Func<HubDescriptor, IRequest, bool>						onBeforeAuthorizeConnect	= null,
				Func<IHub, bool>										onBeforeConnect				= null,
				Action<IHub>											onAfterConnect				= null,
				Func<IHub, bool>										onBeforeReconnect			= null,
				Action<IHub>											onAfterReconnect			= null,
				Func<IHub, bool>										onBeforeDisconnect			= null,
				Action<IHub>											onAfterDisconnect			= null,
				Func<IHubIncomingInvokerContext, bool>					onBeforeIncoming			= null,
				Func<object, IHubIncomingInvokerContext, object>		onAfterIncoming				= null,
				Func<IHubOutgoingInvokerContext, bool>					onBeforeOutgoing			= null,
				Action<IHubOutgoingInvokerContext>						onAfterOutgoing				= null,
				Action<ExceptionContext, IHubIncomingInvokerContext>	onIncomingError				= null
			)
		{
			this.onBeforeAuthorizeConnect	= onBeforeAuthorizeConnect;
			this.onBeforeConnect			= onBeforeConnect;
			this.onAfterConnect				= onAfterConnect;
			this.onBeforeReconnect			= onBeforeReconnect;
			this.onAfterReconnect			= onAfterReconnect;
			this.onBeforeDisconnect			= onBeforeDisconnect;
			this.onAfterDisconnect			= onAfterDisconnect;
			this.onBeforeIncoming			= onBeforeIncoming;
			this.onAfterIncoming			= onAfterIncoming;
			this.onBeforeOutgoing			= onBeforeOutgoing;
			this.onAfterOutgoing			= onAfterOutgoing;
			this.onIncomingError			= onIncomingError;
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
			return	this.onBeforeAuthorizeConnect == null || typeof(THub) != hubDescriptor.HubType
				?	base.OnBeforeAuthorizeConnect(hubDescriptor, request)
				:	this.onBeforeAuthorizeConnect(hubDescriptor, request);
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
			return	this.onBeforeConnect == null || typeof(THub) != hub.GetType()
				?	base.OnBeforeConnect(hub)
				:	this.onBeforeConnect(hub);
		}


		/// <summary>
		/// This method is called after the connect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnConnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has connected to.</param>
		protected override void OnAfterConnect(IHub hub)
		{
			if		(this.onAfterConnect == null)	base.OnAfterConnect(hub);
			else if (typeof(THub) != hub.GetType())	base.OnAfterConnect(hub);
			else									this.onAfterConnect(hub);
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
			return	this.onBeforeReconnect == null || typeof(THub) != hub.GetType()
				?	base.OnBeforeReconnect(hub)
				:	this.onBeforeReconnect(hub);
		}


		/// <summary>
		/// This method is called after the reconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnReconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has reconnected to.</param>
		protected override void OnAfterReconnect(IHub hub)
		{
			if		(this.onAfterReconnect == null)	base.OnAfterReconnect(hub);
			else if (typeof(THub) != hub.GetType())	base.OnAfterReconnect(hub);
			else									this.onAfterReconnect(hub);
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
			return	this.onBeforeDisconnect == null || typeof(THub) != hub.GetType()
				?	base.OnBeforeDisconnect(hub)
				:	this.onBeforeDisconnect(hub);
		}


		/// <summary>
		/// This method is called after the disconnect components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed and after <see cref="IHub.OnDisconnected"/> is executed, if at all.
		/// </summary>
		/// <param name="hub">The hub the client has disconnected from.</param>
		protected override void OnAfterDisconnect(IHub hub)
		{
			if		(this.onAfterDisconnect == null)	base.OnAfterDisconnect(hub);
			else if (typeof(THub) != hub.GetType())		base.OnAfterDisconnect(hub);
			else										this.onAfterDisconnect(hub);
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
			return	this.onBeforeIncoming == null || typeof(THub) != context.MethodDescriptor.Hub.HubType
				?	base.OnBeforeIncoming(context)
				:	this.onBeforeIncoming(context);
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
			return	this.onAfterIncoming == null || typeof(THub) != context.MethodDescriptor.Hub.HubType
				?	base.OnAfterIncoming(result, context)
				:	this.onAfterIncoming(result, context);
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
			var type	= typeof(THub);
			var data	= type.GetCustomAttributesData().FirstOrDefault(x => x.AttributeType == typeof(HubNameAttribute));
			var hubName	= data == null
						? type.Name
						: data.ConstructorArguments[0].Value as string;

			return	this.onBeforeOutgoing == null || hubName != context.Invocation.Hub
				?	base.OnBeforeOutgoing(context)
				:	this.onBeforeOutgoing(context);
		}


		/// <summary>
		/// This method is called after the outgoing components of any modules added later to the <see cref="IHubPipeline"/> are
		/// executed. This does not mean that all the clients have received the hub method invocation, but it does indicate indicate
		/// a hub invocation message has successfully been published to a message bus.
		/// </summary>
		/// <param name="context">A description of the client-side hub method invocation.</param>
		protected override void OnAfterOutgoing(IHubOutgoingInvokerContext context)
		{
			var type	= typeof(THub);
			var data	= type.GetCustomAttributesData().FirstOrDefault(x => x.AttributeType == typeof(HubNameAttribute));
			var hubName	= data == null
						? type.Name
						: data.ConstructorArguments[0].Value as string;

			if		(this.onAfterOutgoing == null)		base.OnAfterOutgoing(context);
			else if (hubName != context.Invocation.Hub)	base.OnAfterOutgoing(context);
			else										this.onAfterOutgoing(context);
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
			if		(this.onIncomingError == null)									base.OnIncomingError(exceptionContext, invokerContext);
			else if (typeof(THub) != invokerContext.MethodDescriptor.Hub.HubType)	base.OnIncomingError(exceptionContext, invokerContext);
			else																	this.onIncomingError(exceptionContext, invokerContext);
		}
		#endregion
	}
}