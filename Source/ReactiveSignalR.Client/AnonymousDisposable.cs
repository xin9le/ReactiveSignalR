using System;



namespace ReactiveSignalR.Client
{
	/// <summary>
	/// Provides the dispose function to specify a delegate from outside.
	/// </summary>
	internal class AnonymousDisposable : IDisposable
	{
		/// <summary>
		/// Hold dispose delegate.
		/// </summary>
		private readonly Action onDispose = null;


		/// <summary>
		/// Create instance by specifiying dispose delegate.
		/// </summary>
		/// <param name="onDispose">Dispose delegate</param>
		public AnonymousDisposable(Action onDispose)
		{
			this.onDispose = onDispose;
		}


		/// <summary>
		/// Dispose used resources.
		/// </summary>
		public void Dispose()
		{
			if (this.onDispose != null)
				this.onDispose();
		}
	}
}