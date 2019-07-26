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
