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
		private static PlayAnimation playAnim;

		public struct AnimParam
		{
			public IntPtr ptr;
			public short animId;
			public short loopId;
			public IntPtr ptr2;
		}

		[DllExport]
		public static void Initialize()
		{
			playAnim = ReloadedHooks.Instance.CreateWrapper<PlayAnimation>(0x7FF79576E370, out var _);
			//playAnimationHook = ReloadedHooks.Instance.CreateHook<PlayAnimation>(Animation, 0x7FF7955134D0);
			//playAnimationHook.Activate();
		}

		[DllExport]
		public static void Play(AnimParam param)
		{
			playAnim.Invoke(param.ptr, param.animId, param.loopId, param.ptr2);
		}
	}
}
