using System;

namespace Cubus
{
	public struct AnimationParameters
	{
		/// <summary>
		/// A pointer to the actor you wish to play an animation on.
		/// </summary>
		public IntPtr actor;

		/// <summary>
		/// The start animation ID.
		/// </summary>
		public short startId;

		/// <summary>
		/// The main animation ID.
		/// </summary>
		public short animId;
	}
}