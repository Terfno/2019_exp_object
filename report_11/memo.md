# 2019/7/19 実験メモ
## 11.1
### 1
![](https://i.imgur.com/1sfNiXE.png)

### 2
![](https://i.imgur.com/ScLtO13.png)

### ソースコード
#### IHittable
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface IHittable
	{
		bool IsHitted(IRectBounds c);
	}
}
```

#### ICrashable
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface ICrashable
	{
		void Crash();
		bool IsFinished();
		bool IsCrashing();
	}
}
```

#### ITarget
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface ITarget: IHittable, ICrashable, IDrawable
	{

	}
}
```

#### IRectBounds
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface IRectBounds
	{
		int GetNorthEastX();
		int GetNorthEastY();
		int GetSouthWestX();
		int GetSouthWestY();
	}
}
```

#### IMovableRectTarget
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	interface IMovableRectTarget : ITarget, IRectBounds, IMovable
	{
		void MoveNext();
	}
}
```

#### ShootingUtils
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public class ShootingUtils
	{
		public static bool IsIntersected(IRectBounds a, IRectBounds b)
		{
			var uy = b.GetNorthEastY();
			var ux = b.GetNorthEastX();

			var dy = b.GetSouthWestY();
			var dx = b.GetSouthWestX();

			var northY = a.GetNorthEastY();
			var southY = a.GetSouthWestY();
			var westX = a.GetSouthWestX();
			var eastX = a.GetNorthEastX();

			if((ux >= westX && ux<=eastX && uy>=northY && uy<=southY) || (dx>=westX && dx<=eastX && uy>=northY && uy<=southY) || (ux>=westX && ux<=eastX && dy>=northY && dy<=southY) || (dx>=westX && dx<=eastX && dy>=northY && dy <= southY))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
```

#### SimpleEnemy
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;

namespace Shooting
{
	public class SimpleEnemy : IMovableRectTarget
	{
		private DeviceContext d2dDeviceContext;
		private Device d2dDevice;
		private int y;
		private int x;
		private TransformedGeometry enemyPath;
		private SolidColorBrush enemyBrush;
		private Vector2 firstPoint;
		private Vector2 secondPoint;
		private Vector2 thirdPoint;
		private bool isVisible;
		private const float MAX_X = 20f;
		private const float MAX_Y = 20f;
		private const int MOVE_SPEED = 2;

		public SimpleEnemy(DeviceContext ctx)
		{
			this.d2dDeviceContext = ctx;
			this.d2dDevice = ctx.Device;

			this.Initialize();
		}

		private void Initialize()
		{
			this.isVisible = true;

			this.x = 0;
			this.y = 0;

			var path = new PathGeometry(this.d2dDevice.Factory);

			this.firstPoint = new Vector2(0f,0f);
			this.secondPoint = new Vector2(20f, 0f);
			this.thirdPoint = new Vector2(10f, 20f);

			// 11.1
			var sink = path.Open();

			sink.BeginFigure(this.firstPoint, FigureBegin.Filled);

			sink.AddLines(new SharpDX.Mathematics.Interop.RawVector2[]
			{
				this.secondPoint,
				this.thirdPoint
			});
			// 11.1

			sink.EndFigure(FigureEnd.Closed);
			sink.Close();

			this.enemyPath = new TransformedGeometry(this.d2dDevice.Factory, path, Matrix3x2.Identity);
			this.enemyBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Black);
		}

		public void Crash()
		{
			this.isVisible = false;
		}

		public void Draw()
		{
			if (this.isVisible)
			{
				var eTransform = this.enemyPath.Transform;
				eTransform.M31 = this.x;
				eTransform.M32 = this.y;

				this.d2dDeviceContext.Transform = eTransform;
				this.d2dDeviceContext.DrawGeometry(this.enemyPath, this.enemyBrush);
				this.d2dDeviceContext.FillGeometry(this.enemyPath, this.enemyBrush);
			}
		}

		public bool IsHitted(IRectBounds c)
		{
			return ShootingUtils.IsIntersected(this, c);
		}

		public bool IsMovable()
		{
			if(this.y>=-MAX_Y && this.y<=640 && this.x >= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Move(int dy, int dx)
		{
			this.y = this.y + dy;
			this.x = this.x + dx;
		}

		public void SetPosition(int y, int x)
		{
			this.y = y - (int)MAX_Y / 2;
			this.x = x - (int)MAX_X / 2;

			this.isVisible = true;
		}

		public int GetNorthEastX()
		{
			return (int)(this.x + MAX_X / 2);
		}

		public int GetNorthEastY()
		{
			return (int)(this.y - MAX_Y / 2);
		}

		public int GetSouthWestX()
		{
			return (int)(this.x - MAX_X / 2);
		}

		public int GetSouthWestY()
		{
			return (int)(this.y + MAX_Y / 2);
		}

		public bool IsFinished()
		{
			return !this.isVisible;
		}

		public bool IsCrashing()
		{
			return !this.isVisible;
		}

		public void MoveNext()
		{
			if (this.IsMovable())
			{
				this.Move(MOVE_SPEED, 0);
			}
			else
			{
				this.isVisible = false;
			}
		}
	}
}
```

#### IUpdatable
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface IUpdatable
	{
		void Update();
	}
}
```

#### RectTargetManager
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;

namespace Shooting
{
	public class RectTargetManager : IUpdatable, IDrawable
	{
		private DeviceContext context;
		private List<IMovableRectTarget> targetList;
		private PlayerShotManager playerShotManager;
		public const int ENEMY_MAX_NUM = 10;
		public Random rng;

		public RectTargetManager(DeviceContext ctx, PlayerShotManager playerShotManager)
		{
			this.context = ctx;
			this.playerShotManager = playerShotManager;

			this.Initialize();
		}

		private void Initialize()
		{
			this.targetList = new List<IMovableRectTarget>();
			this.rng = new Random();

			for(int i = 0; i < ENEMY_MAX_NUM; i++)
			{
				var enemy = new SimpleEnemy(this.context);
				this.InitializePosition(enemy);
				this.targetList.Add(enemy);
			}
		}

		private const int MAX_WIDTH = 480;

		private void InitializePosition(IMovable e)
		{
			e.SetPosition(0, 10 + this.rng.Next(0, MAX_WIDTH));
		}

		public void Draw()
		{
			foreach(var d in this.targetList)
			{
				d.Draw();
			}
		}

		public void Update()
		{
			for(int i = 0; i < this.targetList.Count; i++)
			{
				var t = this.targetList[i];

				if(!t.IsCrashing() && this.playerShotManager.IsHitted(t))
				{
					t.Crash();
				}

				t.MoveNext();

				if (t.IsFinished())
				{
					InitializePosition(t);
				}
			}
		}
	}
}
```

#### PlayerShotManager
```cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX.Direct2D1;
using System.Collections.Generic;

namespace Shooting
{
	public class PlayerShotManager : IDrawable, IMovable, IFirable, IUpdatable, IHittable
	{
		private DeviceContext d2dDeviceContext;
		private List<Shot> shotList;
		private List<Shot> drawList;
		private int y;
		private int x;
		private const int SHOT_NUM_MAX = 10;
		private const int SHOT_SPEED = -20;

		public PlayerShotManager(DeviceContext ctx)
		{
			this.d2dDeviceContext = ctx;
			this.Initialize();
		}

		private void Initialize()
		{
			this.y = 0;
			this.x = 0;

			this.shotList = new List<Shot>();

			for(int i =0;i < SHOT_NUM_MAX; i++)
			{
				this.shotList.Add(new PlayerShot(this.d2dDeviceContext));
			}
			this.drawList = new List<Shot>();
		}

		public void Fire()
		{
			if(this.drawList.Count < SHOT_NUM_MAX)
			{
				var shot = this.shotList[0];
				shot.SetPosition(this.y, this.x);
				this.drawList.Add(shot);
				this.shotList.RemoveAt(0);
			}
		}

		public void Draw()
		{
			for(int i = 0; i < this.drawList.Count; i++)
			{
				this.drawList[i].Draw();
			}
		}

		public void Update()
		{
			for(int i = 0; i < this.drawList.Count; i++)
			{
				var shot = this.drawList[i];

				if (shot.IsMovable())
				{
					shot.Move(SHOT_SPEED, 0);
				}
				else
				{
					this.shotList.Add(shot);
					this.drawList.RemoveAt(i);
				}
			}
		}

		public void Move(int dy, int dx)
		{
			this.y += dy;
			this.x += dx;
		}

		public void SetPosition(int y, int x)
		{
			this.y = y;
			this.x = x;
		}

		public bool IsMovable()
		{
			if(this.y>=0 && this.x >= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool IsHitted(IRectBounds c)
		{
			for(int i=0;i<this.drawList.Count; i++)
			{
				var d = this.drawList[i];

				if (d.IsHitted(c))
				{
					d.Crash();

					this.shotList.Add(d);

					this.drawList.RemoveAt(i);

					return true;
				}
			}

			return false;
		}
	}
}
```

#### PlayerShot
```cs
using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public class PlayerShot : Shot, IRectBounds
	{
		private Brush shotBrush;
		private const float MAX_X = 10f;
		private const float MAX_Y = 10f;
		private const float INNER_DIFF = 2f;
		private bool isVisible;

		public PlayerShot(DeviceContext ctx) : base(ctx)
		{
			this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Red);
			this.isVisible = true;
		}

		public override void Draw()
		{
			if (this.isVisible)
			{
				this.d2dDeviceContext.FillEllipse(new Ellipse(this.center, MAX_X, MAX_Y), this.shotBrush);
			}
		}

		public override void SetPosition(int y, int x)
		{
			this.center.Y = y + 25f;
			this.center.X = x + 25f;

			this.isVisible = true;
		}

		public int GetNorthEastX()
		{
			return (int)(this.center.X + MAX_X - INNER_DIFF);
		}
		public int GetNorthEastY()
		{
			return (int)(this.center.Y - (MAX_Y - INNER_DIFF));
		}
		public int GetSouthWestX()
		{
			return (int)(this.center.X - (MAX_X - INNER_DIFF));
		}
		public int GetSouthWestY()
		{
			return (int)(this.center.Y + MAX_Y - INNER_DIFF);
		}

		public override bool IsHitted(IRectBounds c)
		{
			return ShootingUtils.IsIntersected(this, c);
		}

		public override void Crash()
		{
			this.isVisible = false;
		}

		public override bool IsFinished()
		{
			return !this.isVisible;
		}

		public override bool IsCrashing()
		{
			return !this.IsCrashing();
		}
	}
}
```

#### Shot
```cs
using SharpDX;
using SharpDX.Direct2D1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public abstract class Shot : ITarget, IMovable
	{
		public abstract void Crash();
		public abstract bool IsCrashing();
		public abstract bool IsFinished();
		public abstract bool IsHitted(IRectBounds c);

		protected DeviceContext d2dDeviceContext;
		protected Vector2 center;

		public Shot(DeviceContext ctx)
		{
			this.d2dDeviceContext = ctx;
			this.center = new Vector2();
		}

		public abstract void Draw();

		public bool IsMovable()
		{
			if (this.center.X >= 0 && this.center.Y >= 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Move(int dy, int dx)
		{
			this.center.X = this.center.X + dx;
			this.center.Y = this.center.Y + dy;
		}

		public abstract void SetPosition(int y, int x);
	}
}
```

#### App
```cs
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

				//this.enemyDisplay = new SimpleEnemy(this.d2dDeviceContext);
				//this.enemyDisplay.SetPosition(50, 240);
				//this.displayList.Add(this.enemyDisplay);

				this.targetManager = new RectTargetManager(this.d2dDeviceContext, this.playerShotManager);
				this.displayList.Add(this.targetManager);
				this.updateList.Add(this.targetManager);
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
```
