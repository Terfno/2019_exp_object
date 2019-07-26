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
