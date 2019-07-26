using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpDX;
using SharpDX.Direct2D1;
using System;

namespace Shooting
{
	public class EnemyShot : Shot, IMovableRectTarget
	{
		private SolidColorBrush shotBrush;
		private int targetX;
		private int targetY;
		private double rad;
		private float dSpeedX;
		private float dSpeedY;
		private bool isVisible;
		private IMovableRectTarget player;
		private int speed;
		private SolidColorBrush debugBrush;
		private const float INNER_DIFF = 2f;

		private const float MAX_X = 5f;
		private const float MAX_Y = 5f;

		public EnemyShot(DeviceContext ctx, IMovableRectTarget player, int speed) : base(ctx)
		{
			this.shotBrush = new SolidColorBrush(this.d2dDeviceContext, Color.YellowGreen);
			this.isVisible = true;
			this.player = player;
			this.speed = speed;

			this.debugBrush = new SolidColorBrush(this.d2dDeviceContext, Color.Black);
		}

		public override void Crash()
		{
			this.isVisible = false;
		}

		public override void Draw()
		{
			if (this.isVisible)
			{
				this.d2dDeviceContext.FillEllipse(new Ellipse(this.center, MAX_X, MAX_Y), this.shotBrush);
				this.d2dDeviceContext.DrawRectangle(new RectangleF(this.GetSouthWestX(), this.GetNorthEastY(), this.GetNorthEastX() - this.GetSouthWestX(), this.GetSouthWestY() - this.GetNorthEastY()), this.debugBrush);

			}
		}

		public override bool IsFinished()
		{
			return !this.isVisible;
		}

		public override void SetPosition(int y, int x)
		{
			this.center.Y = y + 25f;
			this.center.X = x + 25f;
			this.targetX = this.player.GetCenterX();
			this.targetY = this.player.GetCenterY();

			double dY = this.targetY - this.center.Y;
			double dX = this.targetX - this.center.X;

			this.rad = Math.Atan(dX / dY);

			this.dSpeedX = -(float)(this.speed * Math.Sin(this.rad));
			this.dSpeedY = -(float)(this.speed * Math.Cos(this.rad));

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

		public override bool IsCrashing()
		{
			return !this.isVisible;
		}

		public void MoveNext()
		{
			this.center.X = this.center.X + this.dSpeedX;
			this.center.Y = this.center.Y + this.dSpeedY;
		}

		public int GetCenterX()
		{
			return (int)this.center.X;
		}

		public int GetCenterY()
		{
			return (int)this.center.Y;
		}
	}
}
