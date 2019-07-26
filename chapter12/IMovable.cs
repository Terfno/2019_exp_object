using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shooting
{
	public interface IMovable
	{
		void Move(int dy, int dx);
		void SetPosition(int y, int x);
		bool IsMovable();
	}
}
