using Reloaded.Hooks;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Cubus
{
	public static class Cubus
	{
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private delegate bool PlayAnimation(IntPtr actor, short startId, short animId, IntPtr funcPtr);
		private static PlayAnimation playAnimation = null;

		[DllExport]
		public static void Initialize(long funcAddr)
		{
			try
			{
				// TODO: Accept a struct param with the addresses we fetch from host!
				if (playAnimation == null)
					playAnimation = ReloadedHooks.Instance.CreateWrapper<PlayAnimation>(funcAddr, out var _);

				// playAnimHook = ReloadedHooks.Instance.CreateHook<PlayAnimation>(PlayAnimationDetour, 0x7FF786E83300);
				// playAnimHook.Activate();
			}
			catch
			{
				MessageBox.Show("Error at Cubus.Initialize()");
			}
		}

		[DllExport]
		public static void Play(AnimationParameters param)
		{
			//MessageBox.Show($"{param.actor.ToInt64():X}, {param.startId}, {param.animId}, {(param.actor + 0xC00).ToInt64():X}");
			playAnimation.Invoke(param.actor, 0, 3182, IntPtr.Zero);
			playAnimation.Invoke(param.actor, param.startId, param.animId, param.actor + 0xC00);
		}
	}
}
