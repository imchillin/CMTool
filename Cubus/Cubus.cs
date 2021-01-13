using Reloaded.Hooks;
using Reloaded.Hooks.Definitions;
using System;
using System.Runtime.InteropServices;

namespace Cubus
{
	public static class Cubus
	{
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void PlayAnimation(IntPtr ptr, short animId, short loopId, IntPtr ptr2);

		private static IHook<PlayAnimation> playAnimationHook;

		[DllExport]
		public static void Initialize()
		{
			playAnimationHook = ReloadedHooks.Instance.CreateHook<PlayAnimation>(Animation, 0x7FF7955134D0);
		}

		public static void Animation(IntPtr ptr, short animId, short loopId, IntPtr ptr2)
		{
			playAnimationHook.OriginalFunction(ptr, 0, 979, ptr2);
		}
	}
}
