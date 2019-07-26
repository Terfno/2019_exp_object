using SharpDX;
using SharpDX.Direct2D1;
using SharpDX.Direct3D;
using SharpDX.Direct3D11;
using SharpDX.DXGI;
using System;
using System.Diagnostics;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Core;
using Windows.Graphics.Display;
using Windows.UI.Core;
using Windows.System;
using System.Collections.Generic;

namespace Shooting
{
	class App
	{
		[MTAThread]
		private static void Main()
		{
			var viewFactory = new FrameworkViewSource();

			CoreApplication.Run(viewFactory);
		}

		class FrameworkViewSource : IFrameworkViewSource
		{
			public IFrameworkView CreateView()
			{
				return new FrameworkView();
			}
		}

		class FrameworkView : IFrameworkView
		{
			private SharpDX.Direct2D1.DeviceContext d2dDeviceContext;
			private Bitmap1 d2dTarget;
			private SwapChain1 swapChain;
			private CoreWindow mWindow;

			// 9.6追記
			private TransformedGeometry tFighterPath;
			private SolidColorBrush fighterBrush;

			//10.5追記 自機作成
			private Fighter fighterDisplay;
			private List<IDrawable> displayList;

			//10.13追記
			private PlayerShotManager playerShotManager;

			//11.11追記
			private SimpleEnemy enemyDisplay;

			//11.17追記
			private List<IUpdatable> updateList;
			private RectTargetManager targetManager;

			//12.10追記
			private EnemyShotManager enemyShotManager;

			public void Initialize(CoreApplicationView applicationView)
			{
				Debug.WriteLine("Initialize");

				applicationView.Activated += OnActivated;
			}

			void OnActivated(CoreApplicationView applicationView, IActivatedEventArgs args)
			{
				CoreWindow.GetForCurrentThread().Activate();
			}

			void CreateDeviceResources()
			{
				var defaultDevice = new SharpDX.Direct3D11.Device(DriverType.Hardware, DeviceCreationFlags.Debug | DeviceCreationFlags.BgraSupport);

				var device = defaultDevice.QueryInterface<SharpDX.Direct3D11.Device1>();

				var dxgiDevice2 = device.QueryInterface<SharpDX.DXGI.Device2>();

				var dxgiAdapter = dxgiDevice2.Adapter;
				SharpDX.DXGI.Factory2 dxgiFactory2 = dxgiAdapter.GetParent<SharpDX.DXGI.Factory2>();

				var desc = new SwapChainDescription1();
				desc.Width = 480;
				desc.Height = 640;
				desc.Format = Format.B8G8R8A8_UNorm;
				desc.Stereo = false;
				desc.SampleDescription = new SampleDescription(1, 0);
				desc.Usage = Usage.RenderTargetOutput;
				desc.BufferCount = 2;
				desc.Scaling = Scaling.AspectRatioStretch;
				desc.SwapEffect = SwapEffect.FlipSequential;
				desc.Flags = SwapChainFlags.AllowModeSwitch;

				this.swapChain = new SwapChain1(dxgiFactory2, device, new ComObject(mWindow), ref desc);

				var d2dDevice = new SharpDX.Direct2D1.Device(dxgiDevice2);

				this.d2dDeviceContext = new SharpDX.Direct2D1.DeviceContext(d2dDevice, DeviceContextOptions.None);

				var backBuffer = this.swapChain.GetBackBuffer<Surface>(0);

				var displayInfo = DisplayInformation.GetForCurrentView();

				this.d2dTarget = new Bitmap1(this.d2dDeviceContext, backBuffer, new BitmapProperties1(new PixelFormat(Format.B8G8R8A8_UNorm, SharpDX.Direct2D1.AlphaMode.Premultiplied), displayInfo.LogicalDpi, displayInfo.LogicalDpi, BitmapOptions.Target | BitmapOptions.CannotDraw));

				this.updateList = new List<IUpdatable>();

				// 10.5改変
				this.playerShotManager = new PlayerShotManager(this.d2dDeviceContext);

				this.updateList.Add(this.playerShotManager);

				this.fighterDisplay = new Fighter(this.d2dDeviceContext, playerShotManager);
				this.fighterDisplay.SetPosition(540, 240);

				this.displayList = new List<IDrawable>();
				this.displayList.Add(this.fighterDisplay);
				this.displayList.Add(this.playerShotManager);

				this.targetManager = new RectTargetManager(this.d2dDeviceContext, this.playerShotManager);
				this.displayList.Add(this.targetManager);
				this.updateList.Add(this.targetManager);

				this.enemyShotManager = new EnemyShotManager(this.d2dDeviceContext, this.targetManager, this.fighterDisplay);
				this.displayList.Add(this.enemyShotManager);
				this.updateList.Add(this.enemyShotManager);
			}

			public void SetWindow(CoreWindow window)
			{
				Debug.WriteLine("SetWndow: " + window);

				this.mWindow = window;
			}

			public void Load(string entryPoint)
			{
				Debug.WriteLine("Load: " + entryPoint);

				this.CreateDeviceResources();
			}

			public void Run()
			{
				Debug.WriteLine("Run");

				// 10.5追記
				var playerInputManager = new PlayerInputManager(this.mWindow, this.fighterDisplay);

				while (true)
				{
					this.mWindow.Dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessAllIfPresent);

					// 入力
					if(this.mWindow.GetAsyncKeyState(VirtualKey.Escape) == CoreVirtualKeyStates.Down)
					{
						return;
					}

					playerInputManager.Checkinputs();
					foreach(var u in this.updateList)
					{
						u.Update();
					}
					
					// 出力
					this.d2dDeviceContext.Target = d2dTarget;
					this.d2dDeviceContext.BeginDraw();
					this.d2dDeviceContext.Clear(Color.CornflowerBlue);

					// 描画
					// 10.5　追記
					foreach(var d in this.displayList)
					{
						d.Draw();
					}

					this.d2dDeviceContext.EndDraw();

					this.swapChain.Present(0, PresentFlags.None);
					//待機　未実装
				}
			}

			public void Uninitialize()
			{
				Debug.WriteLine("Uninitialize");

				this.swapChain.Dispose();
				this.d2dDeviceContext.Dispose();
				this.d2dTarget.Dispose();
			}
		}
	}
}
