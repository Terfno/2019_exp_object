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

		public IMovableRectTarget GetEnemy(int index)
		{
			return this.targetList[index];
		}

		public int GetEnemyCount()
		{
			return this.targetList.Count;
		}
	}
}
