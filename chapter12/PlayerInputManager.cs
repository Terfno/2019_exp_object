using Windows.System;
using Windows.UI.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public class PlayerInputManager
	{
		private CoreWindow cWindow;
		// 10.11改変
		private IShooter shooter;

		public PlayerInputManager(CoreWindow cWindow, IShooter shooter)
		{
			this.cWindow = cWindow;
			this.shooter = shooter; //　改変
		}

		public void Checkinputs()
		{
			var dx = 0;
			var dy = 0;

			if (this.cWindow.GetAsyncKeyState(VirtualKey.Right) == CoreVirtualKeyStates.Down)
			{
				dx += 10;
			}
			if (this.cWindow.GetAsyncKeyState(VirtualKey.Left) == CoreVirtualKeyStates.Down)
			{
				dx -= 10;
			}
			if (this.cWindow.GetAsyncKeyState(VirtualKey.Down) == CoreVirtualKeyStates.Down)
			{
				dy += 10;
			}
			if (this.cWindow.GetAsyncKeyState(VirtualKey.Up) == CoreVirtualKeyStates.Down)
			{
				dy -= 10;
			}
			if (this.cWindow.GetAsyncKeyState(VirtualKey.Space) == CoreVirtualKeyStates.Down)
			{
				this.shooter.Fire();
			}

			this.shooter.Move(dy, dx);
		}
	}
}
